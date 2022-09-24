using FastFood.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Infrastructure.DataAccess.Repositories
{
    public class EmployeesRepository
    {
        public (List<Employee>, string) GetEmployees()
        {
            var Employees = new List<Employee>();
            try
            {
                return (Employees, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Employees, "Error al Cargar Data, Metodo EmployeesRepository.GetEmployees \n" + ex.Message.ToString());
            }
        }

        public (Employee, string) GetEmployeeById(int id)
        {
            try
            {
                var (Employees, message) = GetEmployees();
                if (Employees is null || Employees.Any())
                    return (new Employee(), message);

                var employee = Employees.FirstOrDefault(x => x.IdEmp == id);
                return (employee, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (new Employee(), "Error al Cargar Data, Metodo EmployeesRepository.GetEmployeeById \n" + ex.Message.ToString());
            }
        }

        public (Employee, string) GetEmployeeByUserid(int id)
        {
            try
            {
                var (Employees, message) = GetEmployees();
                if (Employees is null || Employees.Any())
                    return (new Employee(), message);

                var employee = Employees.FirstOrDefault(x => x.IdUser == id);
                return (employee, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (new Employee(), "Error al Cargar Data, Metodo EmployeesRepository.GetEmployeeByUserid \n" + ex.Message.ToString());
            }
        }

        public (List<Employee>, string) GetEmployeeByDocumentNo(string documentNo)
        {
            try
            {
                var (Employees, message) = GetEmployees();
                if (Employees is null || Employees.Any())
                    return (Employees, message);

                return (Employees.Where(x => x.DocumentNo == documentNo).ToList(), "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (new List<Employee>(), "Error al Cargar Data, Metodo EmployeesRepository.GetEmployeeByDocumentNo \n" + ex.Message.ToString());
            }
        }
    }
}
