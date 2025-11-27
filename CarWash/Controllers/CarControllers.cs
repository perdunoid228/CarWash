using Microsoft.AspNetCore.Mvc;
using CarWash.Application.Interfaces;
using CarWash.Core.Entities;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> GetCars()
    {
        var cars = await _carService.GetAllCarsAsync();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Car>> GetCar(int id)
    {
        var car = await _carService.GetCarByIdAsync(id);
        if (car == null) return NotFound();
        return car;
    }

    [HttpPost]
    public async Task<ActionResult<Car>> PostCar(Car car)
    {
        var createdCar = await _carService.CreateCarAsync(car);
        return CreatedAtAction(nameof(GetCar), new { id = createdCar.Id }, createdCar);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCar(int id, Car car)
    {
        if (id != car.Id) return BadRequest();
        
        var updatedCar = await _carService.UpdateCarAsync(car);
        if (updatedCar == null) return NotFound();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        await _carService.DeleteCarAsync(id);
        return NoContent();
    }
}