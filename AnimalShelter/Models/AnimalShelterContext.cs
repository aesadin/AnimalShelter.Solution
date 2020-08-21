  
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
        new Animal { AnimalId = 1, Species  = "Cat", Breed = "Calico", Name = "Mouse", Age = 3},
        new Animal { AnimalId = 2, Species  = "Dog", Breed = "Terrier", Name = "Tookie", Age = 13},
        new Animal { AnimalId = 3, Species  = "Horse", Breed = "Mini", Name = "Guy", Age = 8},
        new Animal { AnimalId = 4, Species  = "Turtle", Breed = "Diamondback", Name = "Mr. Bigglesworth", Age = 57},
        new Animal { AnimalId = 5, Species  = "Bunny", Breed = "Mini Lop", Name = "Sandy", Age = 2}
        new Animal { AnimalId = 6, Species  = "Dog", Breed = "Goldendoodle", Name = "Celine Dion", Age = 5}
        new Animal { AnimalId = 7, Species  = "Cat", Breed = "Sphynx", Name = "Nood", Age = 16}
      );
    }
  }
}