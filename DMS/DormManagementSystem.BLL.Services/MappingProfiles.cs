using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Account, AccountDTO>();
        CreateMap<Claim, ClaimDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Doorkeeper, DoorkeeperDTO>().ReverseMap();
        CreateMap<EmployeeDTO, Employee>().ReverseMap();
        CreateMap<Shift, ShiftDTO>().ReverseMap();


        CreateMap<CreateAccountDTO, Account>();
        CreateMap<CreateUserDTO, User>();
        CreateMap<CreateJanitorDTO, Janitor>();
        CreateMap<CreateDoorkeeperDTO, Doorkeeper>();
        CreateMap<CreateShiftDTO, Shift>().ForMember(x => x.Employees, opt => opt.MapFrom(y => new List<Employee>()));


        CreateMap<UpdateUserDTO, User>();
        CreateMap<UpdateShiftDTO, Shift>().ForMember(x => x.Employees, opt => opt.MapFrom(y => new List<Employee>()));


        CreateMap<Page<Account>, Page<AccountDTO>>();
        CreateMap<Page<User>, Page<UserDTO>>();
        CreateMap<Page<Shift>, Page<ShiftDTO>>();
        CreateMap<Page<Doorkeeper>, Page<DoorkeeperDTO>>();
    }
}
