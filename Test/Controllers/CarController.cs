using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repositories;

namespace Test.Controllers;

[ApiController]
[Route("cars")]
public class CarController: ControllerBase
{
    private readonly CarRepository _carRepository;
    public CarController(CarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetCars()
    {
        return Ok(await _carRepository.GetAll());        
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetCar(int id)
    {
        if (await _carRepository.GetCar(id) != null)
        {
            return Ok(await _carRepository.GetCar(id));
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddCar(Car car)
    {
        if (await _carRepository.GetCar(car.Id) == null)
        {
            _carRepository.Add(car);
            return Ok();
        }
        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar(Car car)
    {
        if (_carRepository.GetCar(car.Id) != null)
        {
            _carRepository.Update(car);
            return Ok();
        }
        return NotFound();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCar(int id)
    {
        if (_carRepository.GetCar(id) != null)
        {
            _carRepository.Delete(id);
            return Ok();
        }
        return NotFound();
    }
}