using System;
using System.Collections.Generic;

namespace TMPS_LAB4.Data
{
    public class NewEmployee : IEmployed
    {
        private readonly List<string> _parts = new List<string>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeId { get; set; }
        public string Role { get; set; }

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nAngajatul adaugat:");
            foreach (var part in _parts)
                Console.WriteLine(part);
        }
    }
}
