using TMPS_LAB4.Data;

namespace TMPS_LAB4
{
    public interface IEmployeeBuilder
    {
        IEmployeeBuilder LastName(string lastname);
        IEmployeeBuilder FirstName(string firstname);
        IEmployeeBuilder Id(int id);
        IEmployeeBuilder Role(string role);
        EmployeeService Build();
    }
}
