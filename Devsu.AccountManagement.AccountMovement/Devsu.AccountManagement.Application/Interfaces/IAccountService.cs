using Devsu.AccountManagement.Application.Dtos;
using Devsu.AccountManagement.Application.Transport;

namespace Devsu.AccountManagement.Application.Interfaces;

public interface IAccountService
{
    Task<BaseResult<IEnumerable<AccountDto>>> GetAllAccountsAsync();
    Task<BaseResult<AccountDto>> GetAccountByIdAsync(long id);
    Task AddAccountAsync(AccountDto accountDto);
    Task UpdateAccountAsync(AccountDto accountDto);
    Task DeleteAccountAsync(long id);
}
