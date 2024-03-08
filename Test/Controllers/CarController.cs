using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Test.Repositories;

namespace Test.Controllers;

[ApiController]
[Route("cars")]
public class CarController
{
    private readonly CarRepository _carRepository;
    public CarController(CarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    [HttpGet]
    public IActionResult GetCars()
    {
        if (_carRepository.GetAll() != null)
        {
            return Ok(_carRepository.GetAll());
        }

        return NotFound();
    }
}