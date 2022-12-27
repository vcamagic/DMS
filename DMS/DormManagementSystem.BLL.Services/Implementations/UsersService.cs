using System.Linq.Expressions;
using AutoMapper;
using DormManagementSystem.BLL.Services.DTOs;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.GlobalExceptionHandler.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.BLL.Services.Implementations;

public class UsersService : ServiceBase<User>, IUsersService
{
    public UsersService(
        IRepositoryManager repositoryManager,
        IMapper mapper,
        IAccountsService accountsService) : base(repositoryManager.UserRepository, repositoryManager, mapper)
    {
        _accountsService = accountsService;
    }

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
        await CheckUserData(createStudentDTO.JMBG, createStudentDTO.AccountId, ("Role", "Student"));
        return await CreateUser<Student, CreateStudentDTO, StudentDTO>(RepositoryManager.StudentRepository, createStudentDTO);
    }

    public async Task<WardenDTO> CreateWarden(CreateWardenDTO createWardenDTO)
    {
        await CheckUserData(createWardenDTO.JMBG, createWardenDTO.AccountId, ("Role", "Warden"));
        return await CreateUser<Warden, CreateWardenDTO, WardenDTO>(RepositoryManager.WardenRepository, createWardenDTO);
    }

    public async Task<EmployeeDTO> CreateJanitor(CreateJanitorDTO createJanitorDTO)
    {
        await CheckUserData(createJanitorDTO.JMBG, createJanitorDTO.AccountId, ("Role", "Janitor"));
        return await CreateUser<Janitor, CreateJanitorDTO, EmployeeDTO>(RepositoryManager.JanitorRepository, createJanitorDTO);
    }

    public async Task<EmployeeDTO> CreateMaid(CreateMaidDTO createMaidDTO)
    {
        await CheckUserData(createMaidDTO.JMBG, createMaidDTO.AccountId, ("Role", "Maid"));
        return await CreateUser<Maid, CreateMaidDTO, EmployeeDTO>(RepositoryManager.MaidRepository, createMaidDTO);
    }

    public async Task<EmployeeDTO> CreateDoorkeeper(CreateDoorkeeperDTO createDoorkeeperDTO)
    {
        await CheckUserData(createDoorkeeperDTO.JMBG, createDoorkeeperDTO.AccountId, (name: "Role", value: "Doorkeeper"));
        return await CreateUser<Doorkeeper, CreateDoorkeeperDTO, EmployeeDTO>(RepositoryManager.DoorkeeperRepository, createDoorkeeperDTO);
    }


    private async Task CheckUserData(string jmbg, Guid accountId, (string name, string value) requiredClaim)
    {
        var user = await GetEntity(x => x.JMBG == jmbg, true);

        if (user != null)
        {
            throw new BadRequestException($"{nameof(User)} with JMBG {jmbg} already exists.");
        }

        var account = await _accountsService.GetAccount(accountId);

        if (!account.Claims.Any(x => x.Name == requiredClaim.name && x.Value == requiredClaim.value))
        {
            throw new BadRequestException($"{nameof(Account)} with id {accountId} has no {requiredClaim.value} claim.");
        }
    }

    private async Task<TReturnDTO> CreateUser<T, TCreateDTO, TReturnDTO>(IRepositoryBase<T> repository, TCreateDTO createDTO) where T : class
    {
        var user = Mapper.Map<T>(createDTO);
        repository.Create(user);

        await RepositoryManager.SaveAsync();

        return Mapper.Map<TReturnDTO>(user);
    }

    private async Task<TReturn> GetUser<T, TReturn>(IRepositoryBase<T> repository, Expression<Func<T, bool>> expression) where T : class
    {
        var user = await repository.FindByCondition(expression, false).FirstOrDefaultAsync() ??
            throw new BadRequestException($"{typeof(T).Name} does not exist.");

        return Mapper.Map<TReturn>(user);
    }

    private readonly IAccountsService _accountsService;
}
