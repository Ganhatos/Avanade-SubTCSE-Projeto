using AutoMapper;
using Avanade.SubTCSE.Projeto.Application.Dtos.Employee;
using Avanade.SubTCSE.Projeto.Application.Interfaces.Employee;
using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Application.Services.Employee
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IMapper _mapper;

        private readonly IEmployeeService _employeeService;

        public EmployeeAppService(IMapper mapper, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public async Task<EmployeeDto> AddAsync(EmployeeDto employeeDto)
        {
            //mapear
            var itemDomain = _mapper.Map<EmployeeDto, Domain.Aggregates.Employee.Entities.Employee>(employeeDto);

            //chamar metodo
            var item = await _employeeService.AddEmployeeRoleAsync(itemDomain);

            //mapear
            var itemDto = _mapper.Map<Domain.Aggregates.Employee.Entities.Employee, EmployeeDto>(item);

            //devolver
            return itemDto;
        }

        public async Task DeleteById(string Id)
        {
            await _employeeService.DeleteById(Id);
        }

        public async Task<List<EmployeeDto>> FindAllAsync()
        {
            var item = await _employeeService.GetAllAsync();

            return _mapper.Map<List<Domain.Aggregates.Employee.Entities.Employee>, List<EmployeeDto>>(item);
        }

        public async Task<EmployeeDto> GetByIdAsync(string Id)
        {
            var item = await _employeeService.GetByIdAsync(Id);

            return _mapper.Map<Domain.Aggregates.Employee.Entities.Employee, EmployeeDto>(item);
        }

        public async Task UpdateByIdAsync(EmployeeDto employeeDto)
        {
            var itemDomain = _mapper.Map<EmployeeDto, Domain.Aggregates.Employee.Entities.Employee>(employeeDto);

            await _employeeService.UpdateByIdAsync(itemDomain);
        }
    }
}