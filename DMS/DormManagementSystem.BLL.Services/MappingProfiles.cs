using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Account, AccountDTO>();
        CreateMap<CreateAccountDTO, Account>();
        CreateMap<Claim, ClaimDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<CreateUserDTO, User>();
        CreateMap<UpdateUserDTO, User>();
        CreateMap<CreateJanitorDTO, Janitor>();
        CreateMap<EmployeeDTO, Employee>().ReverseMap();
        CreateMap<Shift, ShiftDTO>().ReverseMap();
        CreateMap<CreateShiftDTO, Shift>().ForMember(x => x.Employees, opt => opt.MapFrom(y => new List<Employee>()));

        CreateMap<Page<Account>, Page<AccountDTO>>();
        CreateMap<Page<User>, Page<UserDTO>>();
    }
}
