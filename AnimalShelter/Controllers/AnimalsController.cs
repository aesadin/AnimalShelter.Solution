using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalFinder.Models;

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
        // GET api/yogurts
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

        // GET api/yogurts/5
        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
        }

        // POST api/yogurts
        [HttpPost]
        public void Post([FromBody] Animal yogurt)
        {
            _db.Animals.Add(yogurt);
            _db.SaveChanges();
        }

        // PUT api/yogurts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Animal yogurt)
        {
            yogurt.AnimalId = id;
            _db.Entry(yogurt).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/yogurts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var yogurtToDelete = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
            _db.Animals.Remove(yogurtToDelete);
            _db.SaveChanges();
        }
    }
}