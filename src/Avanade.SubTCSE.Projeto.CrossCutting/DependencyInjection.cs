using Avanade.SubTCSE.Projeto.Application.Interfaces.Employee;
using Avanade.SubTCSE.Projeto.Application.Interfaces.EmployeeRole;
using Avanade.SubTCSE.Projeto.Application.Services.Employee;
using Avanade.SubTCSE.Projeto.Application.Services.EmployeeRole;
using Avanade.SubTCSE.Projeto.Data.Repositories.Base.MongoDB;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Entities;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Repositories;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Services;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Services;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Validators;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Entities;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Repository;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Services;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Services;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Validators;
using Avanade.SubTCSE.Projeto.Domain.Base.Repository.MongoDB;
using Avanade.SubTCSE.Projeto.Infra.Data.Repositories.Employee;
using Avanade.SubTCSE.Projeto.Infra.Data.Repositories.EmployeeRole;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.SubTCSE.Projeto.Infra.CrossCutting
{
    public static class DependencyInjection
    {
        public static void AddRegisterDependenciesInjections(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Application.AutoMapperConfigs.Profiles.Configs));

            services.AddSingleton<IMongoDBContext, MongoDBContext>();

            services.AddScoped<IEmployeeRoleAppService, EmployeeRoleAppService>();

            services.AddScoped<IEmployeeRoleService, EmployeeRoleService>();

            services.AddScoped<IEmployeeRoleRepository, EmployeeRoleRespository>();

            services.AddTransient<IValidator<EmployeeRole>, EmployeeRoleValidator>();

            services.AddScoped<IEmployeeAppService, EmployeeAppService>();

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IValidator<Employee>, EmployeeValidator>();
        }
    }
}
