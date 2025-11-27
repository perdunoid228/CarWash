using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CarWash.Application.Interfaces;
using CarWash.Core.Entities;
using CarWash.Infrastructure.Contexts;

namespace CarWash.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly ApplicationContext _context;
    private readonly ILogger<UserService> _logger;

    public UserService(ApplicationContext context, ILogger<UserService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}