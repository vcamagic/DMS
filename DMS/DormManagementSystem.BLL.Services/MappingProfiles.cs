using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.DAL.Models.Models;

namespace DormManagementSystem.BLL.Services;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Account, AccountDTO>();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Doorkeeper, DoorkeeperDTO>().ReverseMap();
        CreateMap<Doorkeeper, EmployeeDTO>().ReverseMap();
        CreateMap<Maid, EmployeeDTO>().ReverseMap();
        CreateMap<Janitor, EmployeeDTO>().ReverseMap();
        CreateMap<EmployeeDTO, Employee>().ReverseMap();
        CreateMap<Shift, ShiftDTO>().ReverseMap();
        CreateMap<Student, StudentDTO>().ReverseMap();
        CreateMap<Malfunction, MalfunctionDTO>().ForMember(x => x.Janitors, opt => opt.MapFrom(x => x.Janitors.Select(y => y.Id))).ReverseMap();
        CreateMap<Warden, WardenDTO>().ReverseMap();
        CreateMap<RoomDTO, Room>().ReverseMap();
        CreateMap<FloorDTO, Floor>().ReverseMap();
        CreateMap<ResidencyDTO, Residency>().ReverseMap();
        CreateMap<LaundryDTO, Laundry>().ReverseMap();
        CreateMap<EntertainmentDTO, Entertainment>().ReverseMap();
        CreateMap<WashingMachine, ResponseWashingMachineDTO>().ReverseMap();


        CreateMap<CreateAccountDTO, Account>();
        CreateMap<CreateUserDTO, User>();
        CreateMap<CreateJanitorDTO, Janitor>();
        CreateMap<CreateDoorkeeperDTO, Doorkeeper>();
        CreateMap<CreateShiftDTO, Shift>().ForMember(x => x.Employees, opt => opt.MapFrom(y => new List<Employee>()));
        CreateMap<CreateMalfunctionDTO, Malfunction>();
        CreateMap<CreateStudentDTO, Student>();
        CreateMap<CreateFloorDTO, Floor>().ForMember(x => x.Id, opt => opt.MapFrom(x => Guid.NewGuid()));
        CreateMap<CreateResidencyDTO, Residency>();
        CreateMap<CreateLaundryDTO, Laundry>();
        CreateMap<CreateEntertainmentDTO, Entertainment>();
        CreateMap<RequestWashingMachineDTO, WashingMachine>();


        CreateMap<UpdateUserDTO, User>();
        CreateMap<UpdateStudentDTO, Student>();
        CreateMap<UpdateWardenDTO, Warden>();
        CreateMap<UpdateMaidDTO, Maid>();
        CreateMap<UpdateJanitorDTO, Janitor>();
        CreateMap<UpdateDoorkeeperDTO, Doorkeeper>();
        CreateMap<UpdateMalfunctionDTO, Malfunction>()
            .ForMember(x => x.Janitors, opt => opt.Ignore())
            .ReverseMap().ForMember(x => x.Janitors, opt => opt.MapFrom(x => x.Janitors.Select(y => y.Id)));
        CreateMap<UpdateShiftDTO, Shift>().ForMember(x => x.Employees, opt => opt.MapFrom(y => new List<Employee>()));


        CreateMap<Page<Account>, Page<AccountDTO>>();
        CreateMap<Page<User>, Page<UserDTO>>();
        CreateMap<Page<Shift>, Page<ShiftDTO>>();
        CreateMap<Page<Doorkeeper>, Page<DoorkeeperDTO>>();
        CreateMap<Page<Malfunction>, Page<MalfunctionDTO>>();
        CreateMap<Page<Student>, Page<StudentDTO>>();
    }
}
