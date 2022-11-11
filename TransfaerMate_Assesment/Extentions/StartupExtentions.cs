using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using TranserMateAsssment.Core.Task.Implementation;
using TranserMateAsssment.Core.Task.Interfaces;
using TranserMateAsssment.Core.UtilityObjects;
using TransfermateAssesment.Infrastructure.DatabaseContext;
using TransfermateAssesment.Infrastructure.Task;
using TransfermateAssesment.Infrastructure.Task.Interfaces;

namespace TransfaerMateAssesment.API.Extentions
{
    internal static class StartupExtentions
    {
        internal static IServiceCollection AddTaskServies(this IServiceCollection services)
        {
            
            services.AddTransient<ITaskDAL, TaskDAL>();
            services.AddTransient<ITask, TaskBehaviour>();
            services.AddScoped<HTTPHeader>();
            return services;

        }
        internal static IServiceCollection AddTaskInMemmoryDbContext(this IServiceCollection services)
        {
            services.AddDbContext<TaskContext>(options =>
            options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)),
            ServiceLifetime.Singleton);
            return services;
        }
    } 
}
