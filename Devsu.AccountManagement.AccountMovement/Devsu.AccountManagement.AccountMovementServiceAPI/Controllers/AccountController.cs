using Devsu.AccountManagement.Application.Dtos;
using Devsu.AccountManagement.Application.Interfaces;
using Devsu.AccountManagement.Application.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsu.AccountManagement.AccountMovementAPI.Controllers;

[ApiController]
[Route("accounts")]
public class AccountController : BaseController
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public async Task<BaseResponse<BaseResult<IEnumerable<AccountDto>>>> GetAllAccounts()
    {
        return BaseResponse<BaseResult<IEnumerable<AccountDto>>>.Ok(await _accountService.GetAllAccountsAsync());
    }

    [HttpGet("{id}")]
    public async Task<BaseResponse<BaseResult<AccountDto>>> GetAccount(long id)
    {
        var client = await _accountService.GetAccountByIdAsync(id);

        return BaseResponse<BaseResult<AccountDto>>.Ok(client);
    }

    [HttpPost]
    public async Task<ActionResult<AccountDto>> CreateAccount([FromBody] AccountDto account)
    {
        await _accountService.AddAccountAsync(account);
        return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAccount(long id, [FromBody] AccountDto account)
    {
        if (id != account.Id)
        {
            return BadRequest();
        }
        await _accountService.UpdateAccountAsync(account);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(long id)
    {
        await _accountService.DeleteAccountAsync(id);
        return NoContent();
    }
}