using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMPS_LAB4.Data
{
    public class NewEmployeeBuilder : IEmployeeBuilder
    {

        private readonly EmployeeService _newEmployee = new EmployeeService();

        public IEmployeeBuilder FirstName(string firstname)
        {
            _newEmployee.FirstName = firstname;
            return this;
        }

        public IEmployeeBuilder Id(int id)
        {
            _newEmployee.EmployeId = id;
            return this;
        }

        public IEmployeeBuilder LastName(string lastname)
        {
            _newEmployee.LastName = lastname;
            return this;
        }

        public IEmployeeBuilder Role(string role)
        {
            _newEmployee.Role = role;
            return this;
        }

        public EmployeeService Build()
        {
            EmployeeService result = _newEmployee;
            return result;
        }
    }
}
