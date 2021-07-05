﻿using Avanade.SubTCSE.Projeto.Domain.Base.Repository;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<EmployeeRole.Entities.EmployeeRole, string>
    {

    }
}
