using DormManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.Web.Api.Extensions;
public static class DbExtensions
{
    public static IServiceCollection ConfigureDbConnection(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<ApplicationContext>(options => 
            options
            .UseSqlServer(configuration
                .GetConnectionString("DefaultConnection")));
}
