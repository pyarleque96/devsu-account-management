using AutoMapper;
using Devsu.AccountManagement.Application.Dtos;
using Devsu.AccountManagement.Application.ExceptionHandlers;
using Devsu.AccountManagement.Application.Interfaces;
using Devsu.AccountManagement.Application.Transport;
using Devsu.AccountManagement.Domain.Entities;
using Devsu.AccountManagement.Domain.Repositories;

namespace Devsu.AccountManagement.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public ClientService(IClientRepository clientRepository,
                         IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<IEnumerable<ClientDto>>> GetAllClientsAsync()
    {
        return new BaseResult<IEnumerable<ClientDto>>
        {
            Result = _mapper.Map<IEnumerable<ClientDto>>(await _clientRepository.GetAllAsync())
        };
    }

    public async Task<BaseResult<ClientDto>> GetClientByIdAsync(long id)
    {
        return new BaseResult<ClientDto>
        {
            Result = _mapper.Map<ClientDto>(await _clientRepository.GetByIdAsync(id))
        };
    }

    public async Task AddClientAsync(ClientDto client)
    {
        await _clientRepository.AddAsync(_mapper.Map<Client>(client));
    }

    public async Task UpdateClientAsync(ClientDto client)
    {
        var clientToUpdate = await _clientRepository.GetByIdAsync(client.Id);
        if (clientToUpdate == null)
        {
            throw new DomainException($"ClientService => UpdateClientAsync() - error: Client to update not found.");
        }

        await _clientRepository.UpdateAsync(_mapper.Map<Client>(client));
    }

    public async Task DeleteClientAsync(long id)
    {
        var client = await _clientRepository.GetByIdAsync(id);
        if (client == null)
        {
            throw new DomainException($"ClientService => DeleteClientAsync() - error: Client to delete not found.");
        }

        await _clientRepository.DeleteAsync(client);
    }
}