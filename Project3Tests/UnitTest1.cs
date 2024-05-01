using Microsoft.AspNetCore.Mvc;
using Project3.controllers;
using Project3.model;
using Project3.services;
using Moq;
namespace Project3Tests;

public class UnitTest1
{
    [Fact]
    public void GetAnimals_ReturnsListOfAnimals()
    {
        // Arrange
        var mockService = new Mock<IAnimalsService>();
        mockService.Setup(service => service.GetAnimals()).Returns(new List<Animal>
        {
            new Animal(1, "Lion", "Large feline", "Mammal", "Africa"),
            new Animal(2, "Eagle", "Bird of prey", "Bird", "North America")
        });

        var controller = new AnimalsController(mockService.Object);

        // Act
        var result = controller.GetAnimals();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var animals = Assert.IsType<List<Animal>>(okResult.Value);
        Assert.Equal(2, animals.Count);
    }
}