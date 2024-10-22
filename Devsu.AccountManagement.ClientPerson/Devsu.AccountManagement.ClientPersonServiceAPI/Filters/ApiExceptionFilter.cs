using Devsu.AccountManagement.Application.ExceptionHandlers;
using Devsu.AccountManagement.Application.Transport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Devsu.AccountManagement.ClientPersonAPI.Filters;

public class ApiExceptionFilter : ExceptionFilterAttribute
{
    private readonly ILogger<ApiExceptionFilter> _logger;
    private readonly Dictionary<Type, Func<Exception, BaseResponse>> _exceptionHandlers;

    public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
    {
        _logger = logger;
        _exceptionHandlers = new Dictionary<Type, Func<Exception, BaseResponse>>
        {
            { typeof(DomainException), HandleDomainException },
            { typeof(NotFoundException), HandleNotFoundException },
            { typeof(InsufficientFundsException), HandleInsufficientFundsException }
        };
    }

    public override void OnException(ExceptionContext context)
    {
        BaseResponse baseResponse = null;

        // Check if there is a handler for the exception
        var exceptionType = context.Exception.GetType();
        if (_exceptionHandlers.TryGetValue(exceptionType, out var handler))
        {
            baseResponse = handler(context.Exception);
            context.ExceptionHandled = true;
            context.Result = new JsonResult(baseResponse);
        }
        else
        {
            // Manejo de excepciones generales
            baseResponse = HandleGeneralException(context.Exception);
            context.ExceptionHandled = true;
            context.Result = new JsonResult(baseResponse);
        }

        // Optional: If you need to log the error
        _logger.LogError(context.Exception, $"{baseResponse.State.MessageDetail}");

        base.OnException(context);
    }

    private BaseResponse HandleDomainException(Exception ex)
    {
        var domainException = ex as DomainException;

        return new BaseResponse
        {
            State = new BaseStateResponse
            {
                HasError = true,
                TipoError = nameof(DomainException),
                MesageError = domainException.Message,
                MessageDetail = $"DomainException: {domainException.InnerException?.Message} --- {domainException.StackTrace}"
            }
        };
    }

    private BaseResponse HandleNotFoundException(Exception ex)
    {
        var notFoundException = ex as NotFoundException;

        return new BaseResponse
        {
            State = new BaseStateResponse
            {
                HasError = true,
                TipoError = nameof(NotFoundException),
                MesageError = notFoundException.Message,
                MessageDetail = $"NotFoundException: {notFoundException.InnerException?.Message} --- {notFoundException.StackTrace}"
            }
        };
    }

    private BaseResponse HandleInsufficientFundsException(Exception ex)
    {
        var insufficientFundsException = ex as InsufficientFundsException;

        return new BaseResponse
        {
            State = new BaseStateResponse
            {
                HasError = true,
                TipoError = nameof(InsufficientFundsException),
                MesageError = insufficientFundsException.Message,
                MessageDetail = $"InsufficientFundsException: {insufficientFundsException.InnerException?.Message} --- {insufficientFundsException.StackTrace}"
            }
        };
    }

    private BaseResponse HandleGeneralException(Exception ex)
    {
        return new BaseResponse
        {
            State = new BaseStateResponse
            {
                HasError = true,
                TipoError = "GeneralException",
                MesageError = $"{ex.Message}",
                MessageDetail = $"{ex.Message} --- {ex.StackTrace}"
            }
        };
    }
}