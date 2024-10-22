using AutoMapper;
using Devsu.AccountManagement.Application.Dtos;
using Devsu.AccountManagement.Application.ExceptionHandlers;
using Devsu.AccountManagement.Application.Interfaces;
using Devsu.AccountManagement.Application.Transport;
using Devsu.AccountManagement.Domain.Entities;
using Devsu.AccountManagement.Domain.Repositories;

namespace Devsu.AccountManagement.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public AccountService(IAccountRepository accountRepository,
                         IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<IEnumerable<AccountDto>>> GetAllAccountsAsync()
    {
        return new BaseResult<IEnumerable<AccountDto>>
        {
            Result = _mapper.Map<IEnumerable<AccountDto>>(await _accountRepository.GetAllAsync())
        };
    }

    public async Task<BaseResult<AccountDto>> GetAccountByIdAsync(long id)
    {
        return new BaseResult<AccountDto>
        {
            Result = _mapper.Map<AccountDto>(await _accountRepository.GetByIdAsync(id))
        };
    }

    public async Task AddAccountAsync(AccountDto accountDto)
    {
        await _accountRepository.AddAsync(_mapper.Map<Account>(accountDto));
    }

    public async Task UpdateAccountAsync(AccountDto accountDto)
    {
        var account = await _accountRepository.GetByIdAsync(accountDto.Id);
        if (account == null)
        {
            throw new NotFoundException($"AccountService => UpdateAccountAsync() - error: Account to update not found.");
        }

        await _accountRepository.UpdateAsync(_mapper.Map<Account>(accountDto));
    }

    public async Task DeleteAccountAsync(long id)
    {
        var account = await _accountRepository.GetByIdAsync(id);
        if (account == null)
        {
            throw new NotFoundException($"AccountService => DeleteAccountAsync() - error: Account to delete not found.");
        }

        await _accountRepository.DeleteAsync(account);
    }
}