using Avanade.SubTCSE.Projeto.Application.Dtos.EmployeeRole;
using Avanade.SubTCSE.Projeto.Domain.Base.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Application.Interfaces.EmployeeRole
{
    public interface IEmployeeRoleAppService
    {
        Task<EmployeeRoleDto> AddEmployeeRoleAsync(EmployeeRoleDto employeeRoleDto);

        Task<List<EmployeeRoleDto>> FindAllEmployeeRoleAsync();

        Task<EmployeeRoleDto> GetByIdAsync(string id); //TODO: Generics

        Task DeleteById(string id);

        Task UpdateByIdAsync(EmployeeRoleDto employeeRoleDto);
    }
}