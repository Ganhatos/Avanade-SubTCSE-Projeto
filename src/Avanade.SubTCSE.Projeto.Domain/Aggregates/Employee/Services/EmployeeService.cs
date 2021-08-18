using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Repositories;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Services;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IValidator<Entities.Employee> _validator;

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
            IValidator<Entities.Employee> validator,
            IEmployeeRepository employeeRepository)
        {
            _validator = validator;
            _employeeRepository = employeeRepository;
        }

        public async Task<Entities.Employee> AddEmployeeRoleAsync(Entities.Employee employee)
        {
            var validated = await _validator.ValidateAsync(employee, opt =>
            {
                opt.IncludeRuleSets("new");
            });

            employee.validationResult = validated;

            if (!employee.validationResult.IsValid)
            {
                return employee;
            }

            await _employeeRepository.AddAsync(employee);

            return employee;
        }

        public virtual async Task DeleteById(string Id)
        {
            await _employeeRepository.DeleteByIdAsync(Id);
        }

        public async Task<List<Entities.Employee>> GetAllAsync()
        {
            return await _employeeRepository.FindAllAsync();
        }

        public async Task<Entities.Employee> GetByIdAsync(string Id)
        {
            return await _employeeRepository.FindByIdAsync(Id);
        }

        public virtual async Task UpdateByIdAsync(Entities.Employee employee)
        {
            await _employeeRepository.UpdateByIdAsync(employee);
        }
    }
}
