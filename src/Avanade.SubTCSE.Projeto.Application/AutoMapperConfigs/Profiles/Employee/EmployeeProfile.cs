using AutoMapper;

namespace Avanade.SubTCSE.Projeto.Application.AutoMapperConfigs.Profiles.Employee
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Dtos.Employee.EmployeeDto, Domain.Aggregates.Employee.Entities.Employee>()
                .ForCtorParam("id", opt => opt.MapFrom(src => src.Identificador))
                .ForCtorParam("firstName", opt => opt.MapFrom(src => src.PrimeiroNome))
                .ForCtorParam("surName", opt => opt.MapFrom(src => src.Sobrenome))
                .ForCtorParam("birthday", opt => opt.MapFrom(src => src.Aniversario))
                .ForCtorParam("active", opt => opt.MapFrom(src => src.Ativo))
                .ForCtorParam("salary", opt => opt.MapFrom(src => src.Salario))
                .ForCtorParam("employeeRole", opt => opt.MapFrom(src => src.Cargo));

            CreateMap<Domain.Aggregates.Employee.Entities.Employee, Dtos.Employee.EmployeeDto>()
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PrimeiroNome, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(src => src.SurName))
                .ForMember(dest => dest.Aniversario, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Active))
                .ForMember(dest => dest.Salario, opt => opt.MapFrom(src => src.Salary))
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.EmployeeRole))
                .ForMember(dest => dest.ValidationResult, opt => opt.MapFrom(src => src.validationResult))
                .ForAllOtherMembers(i => i.Ignore());
        }
    }
}
