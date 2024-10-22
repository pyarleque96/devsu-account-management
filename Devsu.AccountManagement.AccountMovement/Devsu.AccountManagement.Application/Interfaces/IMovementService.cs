using Devsu.AccountManagement.Application.Dtos;
using Devsu.AccountManagement.Application.Transport;

namespace Devsu.AccountManagement.Application.Interfaces;

public interface IMovementService
{
    Task<BaseResult<IEnumerable<MovementDto>>> GetAllMovementsAsync();
    Task<BaseResult<MovementDto>> GetMovementByIdAsync(long id);
    Task AddMovementAsync(MovementDto movementDto);
    Task UpdateMovementAsync(MovementDto movementDto);
    Task DeleteMovementAsync(long id);
}
