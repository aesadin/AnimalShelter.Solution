using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheltersController : ControllerBase
    {
        private AnimalShelterContext _db;
        public SheltersController(AnimalShelterContext db)
        {
            _db = db;
        }
        // GET api/shelters
        [HttpGet]
        public ActionResult<IEnumerable<Shelter>> Get(string city, string state, string name)
        {
            var query = _db.Shelters.AsQueryable();

            if (city != null)
            {
            query = query.Where(entry => entry.City.Contains(city));
            }
            if (state != null)
            {
            query = query.Where(entry => entry.State.Contains(state));
            }
            if (name != null)
            {
            query = query.Where(entry => entry.Name.Contains(name));
            }
            return query.ToList();
          
        }

        // GET api/shelters/5
        [HttpGet("{id}")]
        public ActionResult<Shelter> Get(int id)
        {
            return _db.Shelters.FirstOrDefault(entry => entry.ShelterId == id);
        }

        // POST api/shelters
        [HttpPost]
        public void Post([FromBody] Shelter shelter)
        {
            _db.Shelters.Add(shelter);
            _db.SaveChanges();
        }

        // PUT api/shelters/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Shelter shelter)
        {
            shelter.ShelterId = id;
            _db.Entry(shelter).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/shelters/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var shelterToDelete = _db.Shelters.FirstOrDefault(entry => entry.ShelterId == id);
            _db.Shelters.Remove(shelterToDelete);
            _db.SaveChanges();
        }
    }
}