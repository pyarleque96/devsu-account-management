using Devsu.AccountManagement.Domain.Entities;
using Devsu.AccountManagement.Domain.Repositories;
using Devsu.AccountManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Devsu.AccountManagement.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AccountMovementDbContext _context;

    public AccountRepository(AccountMovementDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account> GetByIdAsync(long id)
    {
        return await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Account account)
    {
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Account account)
    {
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }
}
