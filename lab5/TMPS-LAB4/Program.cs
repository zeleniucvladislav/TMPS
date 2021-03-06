using System;
using TMPS_LAB4.Core;
using TMPS_LAB4.Data;
using TMPS_LAB4.Decorator;
using TMPS_LAB4.Interfaces;

namespace TMPS_LAB4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
       
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Alegeti optiunea:");
            Console.WriteLine("1) Vizualizati erarhia angajatilor");
            Console.WriteLine("2) Adaugati un nou angajat");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nOptiunea: \n");

            //Employee data
            EmployeeService Director = new EmployeeService { EmployeId = 1, FirstName = "Yolotli", LastName = "Tasunka", Role = "Director general" };

            EmployeeService Manager1 = new EmployeeService { EmployeId = 2, FirstName = "Onangwatgo", LastName = "Amaru", Role = "Departamentului de production" };
            EmployeeService Manager2 = new EmployeeService { EmployeId = 3, FirstName = "Metztli", LastName = "Lalawethika", Role = "Departamentului de camera si lumina" };
            Director.AddSubordinate(Manager1);
            Director.AddSubordinate(Manager2);

            EmployeeService productionEmployee1 = new EmployeeService { EmployeId = 4, FirstName = "Yolotli", LastName = "Talako", Role = "Production manager" };
            EmployeeService productionEmployee2 = new EmployeeService { EmployeId = 5, FirstName = "Antiman", LastName = "Nuka", Role = "Assistant production manager" };
            Manager1.AddSubordinate(productionEmployee1);
            Manager1.AddSubordinate(productionEmployee2);

            EmployeeService cameraEmployee1 = new EmployeeService { EmployeId = 6, FirstName = "Tatanka", LastName = "Kaneonuskatew", Role = "Camera Operator" };
            EmployeeService cameraEmployee2 = new EmployeeService { EmployeId = 7, FirstName = "Tiriaq", LastName = "Tlaloc", Role = "Film loader" };
            SimpleEmployee assistantCamera1 = new SimpleEmployee { EmployeId = 8, FirstName = "Tasunka", LastName = "Wawatam", Role = "First Assistant Camera" };
            SimpleEmployee assistantCamera2 = new SimpleEmployee { EmployeId = 9, FirstName = "Yaxkin", LastName = "Maquinna", Role = "Second assistant camera" };
            SimpleEmployee motionEmployee = new SimpleEmployee { EmployeId = 9, FirstName = "Qillaq", LastName = "Malik", Role = "Motion control technician" };

            Manager2.AddSubordinate(cameraEmployee1);
            Manager2.AddSubordinate(cameraEmployee2);

            cameraEmployee1.AddSubordinate(assistantCamera1);
            cameraEmployee1.AddSubordinate(assistantCamera2);
            cameraEmployee2.AddSubordinate(motionEmployee);

            IEmployeeBuilder employe = new NewEmployeeBuilder();
            Director director = new Director();
            ISalarySpecification salary = new SimpleEmployee();
            var counterSalary = new CounterSpecification(salary);
            var managerSalary = new ManagerSpecification(counterSalary);
            var departmentSalary = new DepartmentDirectorSpecification(managerSalary);
            var ownerSalary = new OwnerSpecification(departmentSalary);

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();

                    Console.WriteLine("Director general: {1} {2} - {3} cu salariul {4}$", Director.EmployeId,
                        Director.FirstName, Director.LastName, Director.Role, Math.Round(ownerSalary.CountSalary(), 2));

                    foreach (EmployeeService manager in Director)
                    {
                        Console.WriteLine("\n\n\t{0}\n", manager.Role);
                        Console.WriteLine("\n\t SEF DEPARTAMENT: {1}  {2} - Managerul al {3} cu salariul {4}$", manager.EmployeId,
                            manager.FirstName, manager.LastName, manager.Role, Math.Round(departmentSalary.CountSalary(), 2));

                        foreach (EmployeeService employee in manager)
                        {
                            Console.WriteLine(" \t\t ID Angajat: {0}  {1}  {2} - {3} cu salariul {4}$", employee.EmployeId, employee.FirstName,
                                employee.LastName, employee.Role, Math.Round(managerSalary.CountSalary(), 2));

                            foreach (var simpleEmployee in employee)
                            {
                                Console.WriteLine("\t\t\t ID Angajat: {0}  {1}  {2} - {3} cu salariul {4}$\n", simpleEmployee.EmployeId, simpleEmployee.FirstName,
                                    simpleEmployee.LastName, simpleEmployee.Role, Math.Round(salary.CountSalary(), 2));
                            }
                        }
                    }
                    Console.ReadKey();
                    return true;
                case "2":
                    IEmployed choices = new EmployeeService();
                    Console.Clear();
                    Console.WriteLine("\n Introduceti prenumele: ");
                    choices.FirstName = Console.ReadLine();
                    Console.WriteLine("\n Introduceti numele: ");
                    choices.LastName = Console.ReadLine();
                    Console.WriteLine("\n Introduceti rolul: ");
                    choices.Role = Console.ReadLine();
                    director.Construct(employe, 1111, choices.FirstName, choices.LastName, choices.Role);
                    EmployeeService newEmployee = employe.Build();

                    Console.WriteLine("\n In ce departament va activa noul angajat?");
                    Console.WriteLine("1) Departament contabilitate");
                    Console.WriteLine("2) Departament productie");
                    var choice = Console.ReadLine();

                    if(choice == "1")
                    {
                        Manager1.AddSubordinate(newEmployee);
                    }
                    if(choice == "2")
                    {
                        Manager2.AddSubordinate(newEmployee);
                    }
                    Console.ReadKey();

                    Console.WriteLine("Director general: {1} {2} - {3} cu salariul {4}$", Director.EmployeId,
                       Director.FirstName, Director.LastName, Director.Role, Math.Round(ownerSalary.CountSalary(), 2));

                    foreach (EmployeeService manager in Director)
                    {
                        Console.WriteLine("\n\n\t{0}\n", manager.Role);
                        Console.WriteLine("\n\t SEF DEPARTAMENT: {1}  {2} - Managerul al {3} cu salariul {4}$", manager.EmployeId,
                            manager.FirstName, manager.LastName, manager.Role, Math.Round(departmentSalary.CountSalary(), 2));

                        foreach (EmployeeService employee in manager)
                        {
                            Console.WriteLine(" \t\t ID Angajat: {0}  {1}  {2} - {3} cu salariul {4}$", employee.EmployeId, employee.FirstName,
                                employee.LastName, employee.Role, Math.Round(managerSalary.CountSalary(), 2));

                            foreach (var simpleEmployee in employee)
                            {
                                Console.WriteLine("\t\t\t ID Angajat: {0}  {1}  {2} - {3} cu salariul {4}$\n", simpleEmployee.EmployeId, simpleEmployee.FirstName,
                                    simpleEmployee.LastName, simpleEmployee.Role, Math.Round(salary.CountSalary(), 2));
                            }
                        }
                    }
                    Console.ReadKey();
                    return true;

                default:
                    return false;
            }
        }
    }
}
