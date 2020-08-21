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
    public class AnimalsController : ControllerBase
    {
        private AnimalShelterContext _db;
        public AnimalsController(AnimalShelterContext db)
        {
            _db = db;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get(string species, string breed, string name, int age)
        {
            var query = _db.Animals.AsQueryable();

            if (species != null)
            {
            query = query.Where(entry => entry.Species.Contains(species));
            }
            if (breed != null)
            {
            query = query.Where(entry => entry.Breed.Contains(breed));
            }
            if (name != null)
            {
            query = query.Where(entry => entry.Name == name);
            }
            if (age != 0)
            {
            query = query.Where(entry => entry.Age.Equals(age));
            }
            return query.ToList();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public void Post([FromBody] Animal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Animal animal)
        {
            animal.AnimalId = id;
            _db.Entry(animal).State = EntityState.Modified;
            _db.SaveChanges();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var animalToDelete = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
            _db.Animals.Remove(animalToDelete);
            _db.SaveChanges();
        }
    }
}