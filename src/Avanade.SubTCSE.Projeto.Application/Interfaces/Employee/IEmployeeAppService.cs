using Avanade.SubTCSE.Projeto.Application.Base.Interfaces;
using Avanade.SubTCSE.Projeto.Application.Dtos.Employee;

namespace Avanade.SubTCSE.Projeto.Application.Interfaces.Employee
{
    public interface IEmployeeAppService : IBaseAppService<EmployeeDto, string>
    {
    }
}