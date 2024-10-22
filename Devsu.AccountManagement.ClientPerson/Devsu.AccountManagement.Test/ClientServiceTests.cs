using AutoMapper;
using Devsu.AccountManagement.Application.Interfaces;
using Devsu.AccountManagement.Application.Services;
using Devsu.AccountManagement.Domain.Entities;
using Devsu.AccountManagement.Domain.Repositories;
using Moq;

namespace Devsu.AccountManagement.Test;

public class ClientServiceTests
{
    private readonly Mock<IClientRepository> _clientRepositoryMock;
    private readonly IClientService _clientService;
    private readonly IMapper _mapper;

    public ClientServiceTests()
    {
        _clientRepositoryMock = new Mock<IClientRepository>();
        _clientService = new ClientService(_clientRepositoryMock.Object, _mapper);
    }

    [Fact]
    public async Task GetClientByIdAsync_ReturnsClient_WhenClientExists()
    {
        // Arrange
        long clientId = 1;
        var expectedPerson = new Person
        {
            Id = 1,
            Name = "John Doe",
            Gender = "Male",
            Age = 30,
            Identification = "ID123456",
            Address = "123 Main St",
            Phone = "555-1234"
        };

        var expectedClient = new Client
        {
            Id = clientId,
            PersonId = expectedPerson.Id,
            Password = "SecurePassword123",
            IsActive = true,
            Person = expectedPerson
        };

        _clientRepositoryMock
            .Setup(repo => repo.GetByIdAsync(clientId))
            .ReturnsAsync(expectedClient);

        // Act
        var result = await _clientService.GetClientByIdAsync(clientId);

        var client = result.Result;

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(client);
        Assert.Equal(expectedClient.Id, client.Id);
        Assert.Equal(expectedClient.PersonId, client.PersonId);
        Assert.Equal(expectedClient.Password, client.Password);
        Assert.True(client.IsActive);
        Assert.NotNull(client.Person);
        Assert.Equal(expectedPerson.Id, client.Person.Id);
        Assert.Equal(expectedPerson.Name, client.Person.Name);
        Assert.Equal(expectedPerson.Gender, client.Person.Gender);
        Assert.Equal(expectedPerson.Age, client.Person.Age);
        Assert.Equal(expectedPerson.Identification, client.Person.Identification);
        Assert.Equal(expectedPerson.Address, client.Person.Address);
        Assert.Equal(expectedPerson.Phone, client.Person.Phone);
    }

    [Fact]
    public async Task GetClientByIdAsync_ReturnsNull_WhenClientDoesNotExist()
    {
        // Arrange
        long clientId = 2;

        _clientRepositoryMock
            .Setup(repo => repo.GetByIdAsync(clientId))
            .ReturnsAsync((Client)null);

        // Act
        var result = await _clientService.GetClientByIdAsync(clientId);

        // Assert
        Assert.Null(result);
    }
}