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
    public class AnimalsController : ControllerBase
    {
        private AnimalFinderContext _db;
        public AnimalsController(AnimalFinderContext db)
        {
            _db = db;
        }
        // GET api/animals
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get(string brand, string flavor, bool blended, string type)
        {
            var query = _db.Animals.AsQueryable();

            if (brand != null)
            {
            query = query.Where(entry => entry.Brand.Contains(brand));
            }
            if (flavor != null)
            {
            query = query.Where(entry => entry.Flavor.Contains(flavor));
            }
            if (blended)
            {
            query = query.Where(entry => entry.Blended == blended);
            }
            if (type != null)
            {
            query = query.Where(entry => entry.Type.Contains(type));
            }
            return query.ToList();
        }

        // GET api/animals/5
        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
        }

        // POST api/animals
        [HttpPost]
        public void Post([FromBody] Animal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
        }

        // PUT api/animals/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Animal animal)
        {
            animal.AnimalId = id;
            _db.Entry(animal).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/animals/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var animalToDelete = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
            _db.Animals.Remove(animalToDelete);
            _db.SaveChanges();
        }
    }
}