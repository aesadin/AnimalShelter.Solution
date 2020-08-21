using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
  public class Animal
  {

    public int AnimalId { get; set; }
    [Required]
    public string Species { get; set; }
    [Required]
    public string Breed { get; set; }
    [Required]
    public bool Name { get; set; }
    
    [Range(0, 500, ErrorMessage = "Must be between 1 and 500.")]
    public int Age { get; set; }
  }
}