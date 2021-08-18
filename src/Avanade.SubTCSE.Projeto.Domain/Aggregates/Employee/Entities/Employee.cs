using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Entities
{
    public record Employee : BaseEntity<string>
    {
        [BsonConstructor]
        public Employee(
            string id,
            string firstName, 
            string surName, 
            DateTime birthday, 
            bool active, 
            decimal salary, 
            EmployeeRole.Entities.EmployeeRole employeeRole)
        {
            Id = id;
            FirstName = firstName;
            SurName = surName;
            Birthday = birthday;
            Active = active;
            Salary = salary;
            EmployeeRole = employeeRole;
        }

        public Employee(
            string firstName,
            string surName,
            DateTime birthday,
            bool active,
            decimal salary,
            EmployeeRole.Entities.EmployeeRole employeeRole)
        {
            FirstName = firstName;
            SurName = surName;
            Birthday = birthday;
            Active = active;
            Salary = salary;
            EmployeeRole = employeeRole;
        }

        [BsonElement("firstName")]
        public string FirstName { get; init; }

        [BsonElement("surName")]
        public string SurName { get; init; }

        [BsonElement("birthday")]
        public DateTime Birthday { get; init; }

        [BsonElement("active")]
        public bool Active { get; init; }

        [BsonElement("salary")]
        public decimal Salary { get; init; }

        [BsonElement("employeeRole")]
        public EmployeeRole.Entities.EmployeeRole EmployeeRole { get; init; }
    }
}
