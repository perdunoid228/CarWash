using CarWash.Domain.Entities;
using CarWash.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly CarWashDbContext _context;

    public ClientsController(CarWashDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Client>> Get()
        => await _context.Clients.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> Get(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        return client == null ? NotFound() : client;
    }

    [HttpPost]
    public async Task<ActionResult<Client>> Post(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Client client)
    {
        if (id != client.Id) return BadRequest();

        _context.Entry(client).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null) return NotFound();

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
