using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using AnimalShelter.Entities;
using Microsoft.AspNetCore.Authorization;

namespace AnimalShelter.Controllers
{
    [Authorize(Roles = Role.Admin)]
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

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{id}")]
        public ActionResult<Shelter> Get(int id)
        {
            return _db.Shelters.FirstOrDefault(entry => entry.ShelterId == id);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public void Post([FromBody] Shelter shelter)
        {
            _db.Shelters.Add(shelter);
            _db.SaveChanges();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Shelter shelter)
        {
            shelter.ShelterId = id;
            _db.Entry(shelter).State = EntityState.Modified;
            _db.SaveChanges();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var shelterToDelete = _db.Shelters.FirstOrDefault(entry => entry.ShelterId == id);
            _db.Shelters.Remove(shelterToDelete);
            _db.SaveChanges();
        }
    }
}