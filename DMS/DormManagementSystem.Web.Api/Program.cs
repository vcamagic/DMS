using DormManagementSystem.BLL.Services;
using DormManagementSystem.BLL.Services.Implementations;
using DormManagementSystem.BLL.Services.Interfaces;
using DormManagementSystem.DAL.Models;
using DormManagementSystem.DAL.Models.Models;
using DormManagementSystem.DAL.Repositories.Implementations;
using DormManagementSystem.DAL.Repositories.Interfaces;
using DormManagementSystem.Web.Api.Authorization;
using DormManagementSystem.Web.Api.Extensions;
using DormManagementSystem.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.ConfigureDbConnection(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddSingleton<IPasswordHasher<Account>, PasswordHasher<Account>>();
//Repositories
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

//Services
builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAccountsService, AccountsService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IShiftsService, ShiftsService>();
builder.Services.AddScoped<IMalfunctionsService, MalfunctionsService>();
builder.Services.AddScoped<IDormStructureService, DormStructureService>();
builder.Services.AddScoped<IWashingMachinesService, WashingMachinesService>();
builder.Services.AddScoped<IProgramsService, ProgramsService>();
builder.Services.AddIdentity<Account, Role>()
    .AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddScoped<IAuthorizationHandler, OwnsAccountPolicyHandler>();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.ConfigureAuthentication();
builder.Services.ConfigureAuthorization();

var app = builder.Build();

app.ConfigureGlobalExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.ConfigureApplicationRoles(builder.Configuration);
app.Run();