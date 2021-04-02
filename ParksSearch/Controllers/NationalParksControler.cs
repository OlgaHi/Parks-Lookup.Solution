using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksSearch.Models;

namespace ParksSearch.Controllers
{
  [Route("api/national")]
  [ApiController]
  public class NationalParksController : ControllerBase
  {
    private readonly ParksSearchContext _db;

    public NationalParksController(ParksSearchContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<NationalPark>> Get(string name, string address, bool? wheelchairAccess)
    {
      var query = _db.NationalParks.AsQueryable();
      if (name != null)
        {
          query = query.Where(entry => entry.Name == name);
        }
      if (address != null)
        {
          query = query.Where(entry => entry.Address == address);
        }
      if (wheelchairAccess.HasValue)
      {
        query = query.Where(entry => entry.WheelchairAccess == wheelchairAccess);
      }
      return query.ToList();
    }