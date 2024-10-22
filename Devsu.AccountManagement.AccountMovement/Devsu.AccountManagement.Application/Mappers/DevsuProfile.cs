using AutoMapper;
using Devsu.AccountManagement.Application.Dtos;
using Devsu.AccountManagement.Domain.Entities;

namespace Devsu.AccountManagement.Application.Mappers;

public class DevsuProfile : Profile
{
    public DevsuProfile()
    {
        CreateMap<Movement, MovementDto>().ReverseMap();
        CreateMap<Account, AccountDto>().ReverseMap();
    }
}