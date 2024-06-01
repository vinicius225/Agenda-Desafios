using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using AgendaDesafios.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> Add(User obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        _context.Users.Add(obj);
        await _context.SaveChangesAsync();

        return obj;
    }

    public async Task<User> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return null;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> GetAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> Update(User obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        var user = await _context.Users.FindAsync(obj.Id);
        if (user == null)
            throw new ArgumentException();
        _context.Users.Update(obj);
        await _context.SaveChangesAsync();

        return user;
    }
}
