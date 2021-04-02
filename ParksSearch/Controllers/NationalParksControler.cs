using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksSearch.Models;
using System.Linq;

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

    [HttpGet("{id}")]
    public ActionResult<National> GetNationalPark(int id)
    {
      return _db.NationalParks.FirstOrDefault(entry => entry.Id == id);
    }

    [HttpPost]
    public void Post([FromBody] NationalPark nationalPark)
    {
      _db.NationalParks.Add(nationalPark);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] NationalParks nationalPark)
    {
      nationalPark.Id = id;
      _db.Entry(nationalPark).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var deletedPark = _db.NationalParks.FirstOrDefault(entry => entry.Id == id);
      _db.NationalParks.Remove(deletedPark);
      _db.SaveChanges();
    } 
  }
}