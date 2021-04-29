using TMPS_LAB4.Interfaces;

namespace TMPS_LAB4.Core
{
    public class SimpleEmployee : IEmployed, ISalarySpecification
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeId { get; set; }
        public string Role { get; set; }

        public decimal CountSalary()
        {
            return 5000m;
        }
    }

}
