namespace Problem4.Salaries
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class EnrtyPoint
    {
        private static Dictionary<int, int> salaries;
        private static Dictionary<int, HashSet<int>> managers; 
         
        public static void Main()
        {
            var employeesCount = int.Parse(Console.ReadLine());
            var employees = new string[employeesCount];
            for (int i = 0; i < employeesCount; i++)
            {
                employees[i] = Console.ReadLine();
            }

            // Sample input
            // var employeesCount = 6;
            // var employees = new string[]
            // {
            //     "NNNNNN",
            //     "YNYNNY",
            //     "YNNNNY",
            //     "NNNNNN",
            //     "YNYNNN",
            //     "YNNYNN"
            // };

            managers = new Dictionary<int, HashSet<int>>();
            salaries = new Dictionary<int, int>();

            for (int employee = 0; employee < employeesCount; employee++)
            {
                for (int symbolIndex = 0; symbolIndex < employees[employee].Length; symbolIndex++)
                {
                    if (employees[employee][symbolIndex] == 'Y')
                    {
                        if (!managers.ContainsKey(employee))
                        {
                            managers[employee] = new HashSet<int>();
                        }

                        managers[employee].Add(symbolIndex);
                    }
                }
            }

            for (int employee = 0; employee < employees.Length; employee++)
            {
                EstimateSalary(employee);
            }

            Console.WriteLine(salaries.Sum(s => s.Value));
        }

        private static void EstimateSalary(int employee)
        {
            if (!managers.ContainsKey(employee))
            {
                salaries[employee] = 1;
            }
            else
            {
                if (!salaries.ContainsKey(employee))
                {
                    foreach (var managedEmployee in managers[employee])
                    {
                        EstimateSalary(managedEmployee);
                        if (!salaries.ContainsKey(employee))
                        {
                            salaries[employee] = 0;
                        }

                        salaries[employee] += salaries[managedEmployee];
                    }
                }
            }
        }
    }
}
