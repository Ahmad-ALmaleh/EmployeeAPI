using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        static List<Employee> employeesList { get; }
        static int nextEmpId = 3;

        static EmployeeService()
        {
            employeesList = new List<Employee>()
            {
               // new Employee{Id=0,Name="",Salary=0,Title=""},
                new Employee{Id=1,Name="Ahmad",Salary=15000,Title="Software Engineer"},
                new Employee{Id=2,Name="Alaa",Salary=10000,Title="AI Engineer"}
            };
        }

        public static List<Employee> GetAll() => employeesList;
        public static Employee GetEmployee(int Id) => employeesList.FirstOrDefault(e => e.Id == Id);
        public static void Add(Employee employee)
        {
            employee.Id= nextEmpId++;
            employeesList.Add(employee);
        }
        public static void Update(Employee employee)
        {
            var index = employeesList.FindIndex(e => e.Id==employee.Id);
            if (index == -1)
                return;
            employeesList[index] = employee;
        }
        public static void Delete(int Id)
        {
            var employee = GetEmployee(Id);
            if (employee == null)
                return;
            employeesList.Remove(employee);
        }

    }
}
