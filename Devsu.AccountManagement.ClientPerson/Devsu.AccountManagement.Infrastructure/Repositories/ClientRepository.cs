using Devsu.AccountManagement.Domain.Entities;
using Devsu.AccountManagement.Domain.Repositories;
using Devsu.AccountManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Devsu.AccountManagement.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ClientPersonDbContext _context;

    public ClientRepository(ClientPersonDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> GetByIdAsync(long id)
    {
        return await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Client client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Client client)
    {
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
    }
}