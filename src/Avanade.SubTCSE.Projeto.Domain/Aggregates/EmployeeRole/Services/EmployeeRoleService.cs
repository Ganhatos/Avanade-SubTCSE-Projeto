using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Repository;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Services;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Services
{
    public class EmployeeRoleService : IEmployeeRoleService
    {
        private readonly IValidator<Entities.EmployeeRole> _validator;

        private readonly IEmployeeRoleRepository _employeeRoleRepository;

        public EmployeeRoleService(
            IValidator<Entities.EmployeeRole> validator, 
            IEmployeeRoleRepository employeeRoleRepository)
        {
            _validator = validator;
            _employeeRoleRepository = employeeRoleRepository;
        }

        public async Task<Entities.EmployeeRole> AddEmployeeRoleAsync(Entities.EmployeeRole employeeRole)
        {
            var validated = await _validator.ValidateAsync(employeeRole, opt =>
            {
                opt.IncludeRuleSets("new");
            });

            employeeRole.validationResult = validated;

            if (!employeeRole.validationResult.IsValid)
            {
                return employeeRole;
            }

            await _employeeRoleRepository.AddAsync(employeeRole);

            return employeeRole;
        }

        public virtual async Task DeleteById(string Id)
        {
            await _employeeRoleRepository.DeleteByIdAsync(Id);
        }

        public async Task<List<Entities.EmployeeRole>> GetAllAsync()
        {
            return await _employeeRoleRepository.FindAllAsync();
        }

        public async Task<Entities.EmployeeRole> GetByIdAsync(string Id)
        {
            return await _employeeRoleRepository.FindByIdAsync(Id);
        }

        public virtual async Task UpdateByIdAsync(Entities.EmployeeRole employeeRole)
        {
            await _employeeRoleRepository.UpdateByIdAsync(employeeRole);
        }
    }
}
