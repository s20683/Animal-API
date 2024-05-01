using System.ComponentModel.DataAnnotations;

namespace Project3.model;

public class Animal
{
    public int IdAnimal { get; private set; }
    [Required]
    [MaxLength(200)]
    public String Name { get; private set; }
    [MaxLength(200)]
    public String Description { get; private set; }
    [Required]
    [MaxLength(200)]
    public String Category { get; private set; }
    [Required]
    [MaxLength(200)]
    public String Area { get; private set; }

    public Animal()
    {
        
    }
    public Animal(int idAnimal, string name, string description, string category, string area)
    {
        IdAnimal = idAnimal;
        Name = name;
        Description = description;
        Category = category;
        Area = area;
    }
}