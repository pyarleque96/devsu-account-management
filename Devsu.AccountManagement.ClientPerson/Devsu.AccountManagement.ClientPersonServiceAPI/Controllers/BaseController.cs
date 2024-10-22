using Devsu.AccountManagement.ClientPersonAPI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Devsu.AccountManagement.ClientPersonAPI.Controllers;

[ServiceFilter(typeof(ApiExceptionFilter))]
[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : ControllerBase
{
    public BaseController()
    {
    }
}