using Microsoft.AspNetCore.Mvc;
using Project3.model;
using Project3.services;

namespace Project3.controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = _animalsService.GetAnimals();
        return Ok(animals);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animalsService.GetAnimal(id);

        if (animal==null)
        {
            return NotFound("Animal not found");
        }
        
        return Ok(animal);
    }
    
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var affectedCount = _animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var affectedCount = _animalsService.UpdateAnimal(animal);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var affectedCount = _animalsService.DeleteAnimal(id);
        return NoContent();
    }
}