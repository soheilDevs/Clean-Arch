﻿using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Persistent.Ef.Users;

public class UserRepository:IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Add(User user)
    {
        _context.Add(user);
    }

    public async Task<User> GetById(long id)
    {
        return await _context.Users.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(User user)
    {
        _context.Update(user);
    }
}