using Devsu.AccountManagement.Domain.Entities;
using Devsu.AccountManagement.Domain.Repositories;
using Devsu.AccountManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Devsu.AccountManagement.Infrastructure.Repositories;

public class MovementRepository : IMovementRepository
{
    private readonly AccountMovementDbContext _context;

    public MovementRepository(AccountMovementDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movement>> GetAllAsync()
    {
        return await _context.Movements.ToListAsync();
    }

    public async Task<Movement> GetByIdAsync(long id)
    {
        return await _context.Movements.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Movement movement)
    {
        await _context.Movements.AddAsync(movement);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Movement movement)
    {
        _context.Movements.Update(movement);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Movement movement)
    {
        _context.Movements.Remove(movement);
        await _context.SaveChangesAsync();
    }
}
