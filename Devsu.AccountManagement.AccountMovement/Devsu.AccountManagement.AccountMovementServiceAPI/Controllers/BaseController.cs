using Devsu.AccountManagement.AccountMovementAPI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Devsu.AccountManagement.AccountMovementAPI.Controllers;

[Authorize]
[ServiceFilter(typeof(ApiExceptionFilter))]
[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : ControllerBase
{
    public BaseController()
    {
    }
}