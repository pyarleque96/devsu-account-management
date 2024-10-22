using Devsu.AccountManagement.Application.Dtos;
using Devsu.AccountManagement.Application.Interfaces;
using Devsu.AccountManagement.Application.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsu.AccountManagement.ClientPersonAPI.Controllers;

[ApiController]
[Route("clients")]
public class ClientController : BaseController
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<BaseResponse<BaseResult<IEnumerable<ClientDto>>>> GetClients()
    {
        return BaseResponse<BaseResult<IEnumerable<ClientDto>>>.Ok(await _clientService.GetAllClientsAsync());
    }

    [HttpGet("{id}")]
    public async Task<BaseResponse<BaseResult<ClientDto>>> GetClient(long id)
    {
        var client = await _clientService.GetClientByIdAsync(id);

        return BaseResponse<BaseResult<ClientDto>>.Ok(client);
    }

    [HttpPost]
    public async Task<ActionResult<ClientDto>> CreateClient([FromBody] ClientDto client)
    {
        await _clientService.AddClientAsync(client);
        return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClient(long id, [FromBody] ClientDto client)
    {
        if (id != client.Id)
        {
            return BadRequest();
        }
        await _clientService.UpdateClientAsync(client);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(long id)
    {
        await _clientService.DeleteClientAsync(id);
        return NoContent();
    }
}