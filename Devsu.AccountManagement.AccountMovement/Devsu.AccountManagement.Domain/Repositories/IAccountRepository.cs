using Devsu.AccountManagement.Domain.Entities;

namespace Devsu.AccountManagement.Domain.Repositories;

public interface IAccountRepository : IRepository<Account>
{
    // Additional client-specific methods
}
