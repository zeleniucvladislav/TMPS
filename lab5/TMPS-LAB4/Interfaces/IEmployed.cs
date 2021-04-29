using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMPS_LAB4
{
    public interface IEmployed
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int EmployeId { get; set; }
        string Role { get; set; }
    }
}
