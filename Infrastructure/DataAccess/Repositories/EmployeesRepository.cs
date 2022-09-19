using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.DataAccess.Repositories
{
    public class EmployeesRepository
    {
        public List<Employee> GetEmployees()
        {
            ///llenar con base de datos
            var Employees = new List<Employee>();
            return Employees;
        }

        public Employee GetEmployeeById(int id)
        {
            var Employees = new List<Employee>();
            var employee = Employees.FirstOrDefault(x=>x.IdEmp == id);
            return employee;
        }

        public Employee GetEmployeeByUserid(int id)
        {
            var Employees = new List<Employee>();
            var employee = Employees.FirstOrDefault(x => x.IdUser == id);
            return employee;
        }

        public List<Employee> GetEmployeeByDocumentNo(string documentNo)
        {
            var Employees = new List<Employee>();

            return Employees.Where(x=>x.DocumentNo == documentNo).ToList();
        }
    }
}
