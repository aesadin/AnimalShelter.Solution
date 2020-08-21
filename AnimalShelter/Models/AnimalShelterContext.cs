  
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
        : base(options)
        {

        }

  public DbSet<Animal> Animals { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Animal>()
      .HasData(
        new Animal { AnimalId = 1, Species  = "Ellenos", Breed = "key lime", Name = false, Age = "greek"},
        new Animal { AnimalId = 2, Species  = "Brown Cow", Breed = "plain", Name = false, Age = "cream top"},
        new Animal { AnimalId = 3, Species  = "Siggi", Breed = "coffee", Name = true, Age = "icelandic"},
        new Animal { AnimalId = 4, Species  = "CoCoYo", Breed = "vanilla", Name = false, Age = "dairy free"},
        new Animal { AnimalId = 5, Species  = "Chobani Flip", Breed = "cookie dough", Name = false, Age = "dessert, greek"}
      );
    }
  }
}