using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksSearch.Models;
using System.Linq;

namespace ParksSearch.Controllers
{
  [Route("api/state")]
  [ApiController]
  public class StateParksController : ControllerBase
  {
    private readonly ParksSearchContext _db;

    public StateParksController(ParksSearchContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<StatePark>> Get(string name, string address, bool? wheelchairAccess)
    {
      var query = _db.StateParks.AsQueryable();
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
    public ActionResult<StatePark> GetStatePark(int id)
    {
      return _db.StateParks.FirstOrDefault(entry => entry.Id == id);
    }

    [HttpPost]
    public void Post([FromBody] StatePark statePark)
    {
      _db.StateParks.Add(statePark);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] StatePark statePark)
    {
      statePark.Id = id;
      _db.Entry(statePark).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var deletedPark = _db.StateParks.FirstOrDefault(entry => entry.Id == id);
      _db.StateParks.Remove(deletedPark);
      _db.SaveChanges();
    } 
  }
}