using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Account, AccountDTO>();
        CreateMap<Claim, ClaimDTO>();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<CreateUserDTO, User>();
        CreateMap<UpdateUserDTO, User>();

        CreateMap<Page<Account>, Page<AccountDTO>>();
        CreateMap<Page<User>, Page<UserDTO>>();
    }
}
