using AutoMapper;
using Devsu.AccountManagement.Application.Dtos;
using Devsu.AccountManagement.Application.ExceptionHandlers;
using Devsu.AccountManagement.Application.Interfaces;
using Devsu.AccountManagement.Application.Transport;
using Devsu.AccountManagement.Domain.Entities;
using Devsu.AccountManagement.Domain.Repositories;

namespace Devsu.AccountManagement.Application.Services;

public class MovementService : IMovementService
{
    private readonly IMovementRepository _movementRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public MovementService(IMovementRepository movementRepository,
                           IAccountRepository accountRepository,
                           IMapper mapper)
    {
        _movementRepository = movementRepository;
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<BaseResult<IEnumerable<MovementDto>>> GetAllMovementsAsync()
    {
        return new BaseResult<IEnumerable<MovementDto>>
        {
            Result = _mapper.Map<IEnumerable<MovementDto>>(await _movementRepository.GetAllAsync())
        };
    }

    public async Task<BaseResult<MovementDto>> GetMovementByIdAsync(long id)
    {
        return new BaseResult<MovementDto>
        {
            Result = _mapper.Map<MovementDto>(await _movementRepository.GetByIdAsync(id))
        };
    }

    public async Task AddMovementAsync(MovementDto movementDto)
    {
        var account = await _accountRepository.GetByIdAsync(movementDto.AccountId);

        if (account == null)
            throw new NotFoundException("MovementService => AddMovementAsync(): Account not found.");

        var newBalance = account.InitialBalance + movementDto.Value;

        // Validates that the account does not have a negative balance
        if (newBalance < 0)
            throw new InsufficientFundsException("MovementService => AddMovementAsync(): Insufficient funds.");

        // Update account balance
        account.InitialBalance = newBalance;
        await _accountRepository.UpdateAsync(account);

        // Save the movement
        await _movementRepository.AddAsync(_mapper.Map<Movement>(movementDto));
    }

    public async Task UpdateMovementAsync(MovementDto movementDto)
    {
        var movement = await _movementRepository.GetByIdAsync(movementDto.Id);
        if (movement == null)
            throw new NotFoundException($"AccountService => UpdateMovementAsync() - error: Movement to update not found.");

        // Update the movement
        await _movementRepository.UpdateAsync(_mapper.Map<Movement>(movementDto));
    }

    public async Task DeleteMovementAsync(long id)
    {
        var movement = await _movementRepository.GetByIdAsync(id);
        if (movement == null)
            throw new NotFoundException($"AccountService => DeleteAccountAsync() - error: Movement to delete not found.");

        // Delete the movement
        await _movementRepository.DeleteAsync(movement);
    }
}