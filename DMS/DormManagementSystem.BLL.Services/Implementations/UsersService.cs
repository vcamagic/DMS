using System.Linq.Expressions;
using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.BLL.Services.Implementations;

public class UsersService : ServiceBase<User>, IUsersService
{
    public UsersService(
        IRepositoryManager repositoryManager,
        IMapper mapper,
        IAccountsService accountsService,
        UserManager<Account> accountManager,
        IServiceBase<Student> studentsServiceBase,
        IServiceBase<Warden> wardensServiceBase,
        IServiceBase<Maid> maidsServiceBase,
        IServiceBase<Doorkeeper> doorkeepersServiceBase,
        IServiceBase<Janitor> janitorsServiceBase
        ) : base(repositoryManager.UserRepository, repositoryManager, mapper)
    {
        _accountsService = accountsService;
        _accountManager = accountManager;
        _studentsServiceBase = studentsServiceBase;
        _wardensServiceBase = wardensServiceBase;
        _maidsServiceBase = maidsServiceBase;
        _janitorsServiceBase = janitorsServiceBase;
        _doorkeepersServiceBase = doorkeepersServiceBase;
    }

    public async Task<Page<StudentDTO>> GetStudents(PaginationDTO paginationDTO) =>
        Mapper.Map<Page<StudentDTO>>(await _studentsServiceBase.GetEntityPage(paginationDTO, false));

    public async Task<IReadOnlyList<WardenDTO>> GetWardens() =>
        Mapper.Map<IReadOnlyList<WardenDTO>>(await _wardensServiceBase.GetEntities());

    public async Task<IReadOnlyList<EmployeeDTO>> GetJanitors() =>
        Mapper.Map<IReadOnlyList<EmployeeDTO>>(await _janitorsServiceBase.GetEntities());

    public async Task<IReadOnlyList<EmployeeDTO>> GetMaids() =>
        Mapper.Map<IReadOnlyList<EmployeeDTO>>(await _maidsServiceBase.GetEntities());

    public async Task<IReadOnlyList<EmployeeDTO>> GetDoorkeepers() =>
        Mapper.Map<IReadOnlyList<EmployeeDTO>>(await _doorkeepersServiceBase.GetEntities());

    public async Task<StudentDTO> GetStudent(Guid id) =>
        await GetUser<Student, StudentDTO>(RepositoryManager.StudentRepository, x => x.Id == id);


    public async Task<WardenDTO> GetWarden(Guid id) =>
        await GetUser<Warden, WardenDTO>(RepositoryManager.WardenRepository, x => x.Id == id);


    public async Task<EmployeeDTO> GetJanitor(Guid id) =>
        await GetUser<Janitor, EmployeeDTO>(RepositoryManager.JanitorRepository, x => x.Id == id);

    public async Task<EmployeeDTO> GetMaid(Guid id) =>
        await GetUser<Maid, EmployeeDTO>(RepositoryManager.MaidRepository, x => x.Id == id);

    public async Task<EmployeeDTO> GetDoorkeeper(Guid id) =>
        await GetUser<Doorkeeper, EmployeeDTO>(RepositoryManager.DoorkeeperRepository, x => x.Id == id);


    public async Task<StudentDTO> CreateStudent(CreateStudentDTO createStudentDTO)
    {
        await CheckUserData(createStudentDTO.JMBG, createStudentDTO.AccountId, "Student");
        return await CreateUser<Student, CreateStudentDTO, StudentDTO>(RepositoryManager.StudentRepository, createStudentDTO);
    }

    public async Task<WardenDTO> CreateWarden(CreateWardenDTO createWardenDTO)
    {
        await CheckUserData(createWardenDTO.JMBG, createWardenDTO.AccountId, "Warden");
        return await CreateUser<Warden, CreateWardenDTO, WardenDTO>(RepositoryManager.WardenRepository, createWardenDTO);
    }

    public async Task<EmployeeDTO> CreateJanitor(CreateJanitorDTO createJanitorDTO)
    {
        await CheckUserData(createJanitorDTO.JMBG, createJanitorDTO.AccountId, "Janitor");
        return await CreateUser<Janitor, CreateJanitorDTO, EmployeeDTO>(RepositoryManager.JanitorRepository, createJanitorDTO);
    }

    public async Task<EmployeeDTO> CreateMaid(CreateMaidDTO createMaidDTO)
    {
        await CheckUserData(createMaidDTO.JMBG, createMaidDTO.AccountId, "Maid");
        return await CreateUser<Maid, CreateMaidDTO, EmployeeDTO>(RepositoryManager.MaidRepository, createMaidDTO);
    }

    public async Task<EmployeeDTO> CreateDoorkeeper(CreateDoorkeeperDTO createDoorkeeperDTO)
    {
        await CheckUserData(createDoorkeeperDTO.JMBG, createDoorkeeperDTO.AccountId, "Doorkeeper");
        return await CreateUser<Doorkeeper, CreateDoorkeeperDTO, EmployeeDTO>(RepositoryManager.DoorkeeperRepository, createDoorkeeperDTO);
    }

    public async Task<StudentDTO> UpdateStudent(Guid id, UpdateStudentDTO updateStudentDTO) =>
        await UpdateUser<Student, UpdateStudentDTO, StudentDTO>(_studentsServiceBase, x => x.Id == id, updateStudentDTO);

    public async Task<WardenDTO> UpdateWarden(Guid id, UpdateWardenDTO updateStudentDTO) =>
        await UpdateUser<Warden, UpdateWardenDTO, WardenDTO>(_wardensServiceBase, x => x.Id == id, updateStudentDTO);

    public async Task<EmployeeDTO> UpdateMaid(Guid id, UpdateMaidDTO updateStudentDTO) =>
        await UpdateUser<Maid, UpdateMaidDTO, EmployeeDTO>(_maidsServiceBase, x => x.Id == id, updateStudentDTO);

    public async Task<EmployeeDTO> UpdateJanitor(Guid id, UpdateJanitorDTO updateStudentDTO) =>
        await UpdateUser<Janitor, UpdateJanitorDTO, EmployeeDTO>(_janitorsServiceBase, x => x.Id == id, updateStudentDTO);

    public async Task<EmployeeDTO> UpdateDoorkeeper(Guid id, UpdateDoorkeeperDTO updateStudentDTO) =>
        await UpdateUser<Doorkeeper, UpdateDoorkeeperDTO, EmployeeDTO>(_doorkeepersServiceBase, x => x.Id == id, updateStudentDTO);

    private async Task CheckUserData(string jmbg, Guid accountId, string requiredRole)
    {
        var user = await GetEntity(x => x.JMBG == jmbg, true);

        if (user != null)
        {
            throw new BadRequestException($"{nameof(User)} with JMBG {jmbg} already exists.");
        }

        var account = await _accountManager.FindByIdAsync(accountId.ToString()) ??
            throw new BadRequestException($"{nameof(Account)} with id {accountId} does not exist");
        
        var roles = await _accountManager.GetRolesAsync(account);

        if (!roles.Contains(requiredRole))
        {
            throw new BadRequestException($"{nameof(Account)} with id {accountId} has no {requiredRole} role.");
        }
    }

    private async Task<TReturn> GetUser<T, TReturn>(IRepositoryBase<T> repository, Expression<Func<T, bool>> expression) where T : class where TReturn : class
    {
        var user = await repository.FindByCondition(expression, false).FirstOrDefaultAsync() ??
            throw new BadRequestException($"{typeof(T).Name} does not exist.");

        return Mapper.Map<TReturn>(user);
    }

    private async Task<Page<TReturn>> GetUsers<T, TReturn>(IRepositoryBase<T> repository, Expression<Func<T, bool>> expression) where T : class where TReturn : class
    {
        var users = await repository.FindByCondition(expression, false).ToListAsync();

        return Mapper.Map<Page<TReturn>>(users);
    }

    private async Task<TReturnDTO> CreateUser<T, TCreateDTO, TReturnDTO>(IRepositoryBase<T> repository, TCreateDTO createDTO) where T : class
    {
        var user = Mapper.Map<T>(createDTO);
        repository.Create(user);

        await RepositoryManager.SaveAsync();

        return Mapper.Map<TReturnDTO>(user);
    }

    private async Task<TEntityDTO> UpdateUser<T, TEntityUpdateDTO, TEntityDTO>(IServiceBase<T> serviceBase, Expression<Func<T, bool>> expression, TEntityUpdateDTO updateDTO)
        where T : class
        where TEntityDTO : class
        where TEntityUpdateDTO : class
    {
        var user = await serviceBase.GetEntity(expression, true) ??
                throw new BadRequestException($"{typeof(T).Name} does not exist.");

        Mapper.Map(updateDTO, user);

        await serviceBase.Update(user);

        return Mapper.Map<TEntityDTO>(user);
    }


    private readonly IAccountsService _accountsService;
    private readonly UserManager<Account> _accountManager;
    private readonly IServiceBase<Student> _studentsServiceBase;
    private readonly IServiceBase<Warden> _wardensServiceBase;
    private readonly IServiceBase<Maid> _maidsServiceBase;
    private readonly IServiceBase<Doorkeeper> _doorkeepersServiceBase;
    private readonly IServiceBase<Janitor> _janitorsServiceBase;
}
