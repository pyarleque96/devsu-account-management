using Devsu.AccountManagement.Application.Transport;
using Devsu.AccountManagement.Application.Dtos;

namespace Devsu.AccountManagement.Application.Interfaces;

public interface IClientService
{
    Task<BaseResult<IEnumerable<ClientDto>>> GetAllClientsAsync();
    Task<BaseResult<ClientDto>> GetClientByIdAsync(long id);
    Task AddClientAsync(ClientDto clientDto);
    Task UpdateClientAsync(ClientDto clientDto);
    Task DeleteClientAsync(long id);
}
