using Devsu.AccountManagement.Application.Dtos;
using Devsu.AccountManagement.Application.Interfaces;
using Devsu.AccountManagement.Application.Transport;
using Microsoft.AspNetCore.Mvc;

namespace Devsu.AccountManagement.AccountMovementAPI.Controllers;

[ApiController]
[Route("movements")]
public class MovementController : BaseController
{
    private readonly IMovementService _movementService;

    public MovementController(IMovementService movementService)
    {
        _movementService = movementService;
    }

    [HttpGet]
    public async Task<BaseResponse<BaseResult<IEnumerable<MovementDto>>>> GetAllMovements()
    {
        return BaseResponse<BaseResult<IEnumerable<MovementDto>>>.Ok(await _movementService.GetAllMovementsAsync());
    }

    [HttpGet("{id}")]
    public async Task<BaseResponse<BaseResult<MovementDto>>> GetMovement(long id)
    {
        var movement = await _movementService.GetMovementByIdAsync(id);

        return BaseResponse<BaseResult<MovementDto>>.Ok(movement);
    }

    [HttpPost]
    public async Task<ActionResult<MovementDto>> CreateMovement([FromBody] MovementDto movement)
    {
        await _movementService.AddMovementAsync(movement);
        return CreatedAtAction(nameof(GetMovement), new { id = movement.Id }, movement);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovement(long id, [FromBody] MovementDto movement)
    {
        if (id != movement.Id)
        {
            return BadRequest();
        }
        await _movementService.UpdateMovementAsync(movement);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovement(long id)
    {
        await _movementService.DeleteMovementAsync(id);
        return NoContent();
    }
}