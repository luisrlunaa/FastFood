using FastFood.Infrastructure.DataAccess.Contexts;
using FastFood.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FastFood.Infrastructure.DataAccess.Repositories
{
    public class EmployeesRepository
    {
        DataManager Data = new DataManager();
        public (List<Employee>, string) GetEmployees()
        {
            var Employees = new List<Employee>();
            try
            {
                var classKeys = Data.GetObjectKeys(new Employee());
                var sql = Data.SelectExpression("Employee", classKeys);
                var (dtPC, message) = Data.GetList(sql, "EmployeesRepository.GetEmployees");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (Employees, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    var s = new Employee();
                    s.IdEmp = reader["IdEmp"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdEmp"]);
                    s.IdUser = reader["IdUser"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdUser"]);
                    s.FirstName = reader["FirstName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FirstName"]);
                    s.LastName = reader["LastName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["LastName"]);
                    s.DocumentNo = reader["DocumentNo"] == DBNull.Value ? string.Empty : Convert.ToString(reader["DocumentNo"]);
                    s.DocumentType = reader["DocumentType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["DocumentType"]);
                    s.DateIn = reader["DateIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateIn"]);
                    s.LastUpdate = reader["LastUpdate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["LastUpdate"]);

                    Employees.Add(s);
                }

                return (Employees, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Employees, "Error al Cargar Data, Metodo EmployeesRepository.GetEmployees \n" + ex.Message.ToString());
            }
        }

        public (Users, string) GetUserByUserId(int id)
        {
            var s = new Users();
            try
            {
                var classKeys = Data.GetObjectKeys(new Users());
                var sql = Data.SelectExpression("Employee", classKeys, WhereExpresion: "WHERE IdUser = " + id);
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetUserByUserId");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));
                s.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                s.Password = dr.GetString(dr.GetOrdinal("Password"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));
                s.LastUpdate = dr.GetDateTime(dr.GetOrdinal("LastUpdate"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetUserByUserId \n" + ex.Message.ToString());
            }
        }

        public (Employee, string) GetEmployeeById(int id)
        {
            var s = new Employee();
            try
            {
                var classKeys = Data.GetObjectKeys(new Employee());
                var sql = Data.SelectExpression("Employee", classKeys, WhereExpresion: "WHERE IdEmp = " + id);
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetEmployeeById");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));
                s.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                s.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                s.DocumentNo = dr.GetString(dr.GetOrdinal("DocumentNo"));
                s.DocumentType = dr.GetString(dr.GetOrdinal("DocumentType"));
                s.DocumentType = dr.GetString(dr.GetOrdinal("DocumentType"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));
                s.LastUpdate = dr.GetDateTime(dr.GetOrdinal("LastUpdate"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetEmployeeById \n" + ex.Message.ToString());
            }
        }

        public (Users, string) GetUserByUserName(int userName)
        {
            var s = new Users();
            try
            {
                var classKeys = Data.GetObjectKeys(new Users());
                var sql = Data.SelectExpression("Employee", classKeys, WhereExpresion: "WHERE UserName = " + userName);
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetUserByUserName");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));
                s.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                s.Password = dr.GetString(dr.GetOrdinal("Password"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));
                s.LastUpdate = dr.GetDateTime(dr.GetOrdinal("LastUpdate"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetUserByUserName \n" + ex.Message.ToString());
            }
        }

        public (Employee, string) GetEmployeeByUserid(int id)
        {
            var s = new Employee();
            try
            {
                var classKeys = Data.GetObjectKeys(new Employee());
                var sql = Data.SelectExpression("Employee", classKeys, WhereExpresion: "WHERE IdUser = " + id);
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetEmployeeByUserid");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));
                s.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                s.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                s.DocumentNo = dr.GetString(dr.GetOrdinal("DocumentNo"));
                s.DocumentType = dr.GetString(dr.GetOrdinal("DocumentType"));
                s.DocumentType = dr.GetString(dr.GetOrdinal("DocumentType"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));
                s.LastUpdate = dr.GetDateTime(dr.GetOrdinal("LastUpdate"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetEmployeeByUserid \n" + ex.Message.ToString());
            }
        }

        public (List<Employee>, string) GetEmployeeByDocumentNo(string documentNo)
        {
            var Employees = new List<Employee>();
            try
            {
                var classKeys = Data.GetObjectKeys(new Employee());
                var sql = Data.SelectExpression("Employee", classKeys, WhereExpresion: " WHERE DocumentNo = '" + documentNo + "'");
                var (dtPC, message) = Data.GetList(sql, "EmployeesRepository.GetEmployeeByDocumentNo");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (Employees, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    var s = new Employee();
                    s.IdEmp = reader["IdEmp"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdEmp"]);
                    s.IdUser = reader["IdUser"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdUser"]);
                    s.FirstName = reader["FirstName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FirstName"]);
                    s.LastName = reader["LastName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["LastName"]);
                    s.DocumentNo = reader["DocumentNo"] == DBNull.Value ? string.Empty : Convert.ToString(reader["DocumentNo"]);
                    s.DocumentType = reader["DocumentType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["DocumentType"]);
                    s.DateIn = reader["DateIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateIn"]);
                    s.LastUpdate = reader["LastUpdate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["LastUpdate"]);

                    Employees.Add(s);
                }

                return (Employees, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Employees, "Error al Cargar Data, Metodo EmployeesRepository.GetEmployeeByDocumentNo \n" + ex.Message.ToString());
            }
        }

        public (bool, string) AddEmployee(Employee input)
        {
            try
            {
                if (input == null || input.DateIn == DateTime.MinValue)
                    return (false, "Input Invalido, Metodo EmployeesRepository.AddEmployee");

                var parameters = new List<string> { input.IdUser.ToString(), "'"+input.FirstName+"'", "'"+input.LastName+"'", "'"+input.DocumentNo+"'", "'"+input.DocumentType+"'",
                    "'"+input.DateIn.Value.ToShortDateString()+"'"};

                var classKeys = Data.GetObjectKeys(new Employee()).Where(x => x != "IdEmp" && x != "LastUpdate").ToList();
                var sql = Data.InsertExpression("Employee", classKeys, parameters);
                var (response, message) = Data.CrudAction(sql, "EmployeesRepository.AddEmployee");
                if (!response)
                    return (response, message);

                return (response, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo EmployeesRepository.AddEmployee \n" + ex.Message.ToString());
            }
        }

        public (bool, string) AddUser(Users input)
        {
            try
            {
                if (input == null || input.DateIn == DateTime.MinValue)
                    return (false, "Input Invalido, Metodo EmployeesRepository.AddSale");

                var parameters = new List<string> { input.IdEmp.ToString(), "'"+input.UserName+"'", "'"+input.Password+"'", "'"+input.DateIn.Value.ToShortDateString()+"'"};
                var classKeys = Data.GetObjectKeys(new Users()).Where(x => x != "IdUser" && x != "LastUpdate").ToList();
                var sql = Data.InsertExpression("Users", classKeys, parameters);
                var (response, message) = Data.CrudAction(sql, "EmployeesRepository.AddUser");
                if (!response)
                    return (response, message);

                return (response, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo EmployeesRepository.AddUser \n" + ex.Message.ToString());
            }
        }

        public (bool, string) UpdateEmployee(Employee input)
        {
            try
            {
                if (input == null)
                    return (false, "Input Invalido, Metodo EmployeesRepository.UpdateEmployee");

                var parameters = new List<string> { input.IdUser.ToString(), "'" + input.FirstName + "'", "'" + input.LastName + "'", "'" + input.DocumentNo + "'", "'" + input.DocumentType + "'",
                    "'"+input.LastUpdate.Value.ToShortDateString()+"'"};

                var classKeys = Data.GetObjectKeys(new Employee()).Where(x => x != "IdEmp" && x != "DateIn").ToList();
                var sql = Data.UpdateExpression("Employee", classKeys, parameters, "WHERE IdEmp = " + input.IdEmp);
                var (response, message) = Data.CrudAction(sql, "EmployeesRepository.UpdateEmployee");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo EmployeesRepository.UpdateEmployee \n" + ex.Message.ToString());
            }
        }

        public (bool, string) UpdateUser(Users input)
        {
            try
            {
                if (input == null)
                    return (false, "Input Invalido, Metodo EmployeesRepository.UpdateUser");

                var parameters = new List<string> { input.IdEmp.ToString(), "'" + input.UserName + "'", "'" + input.Password + "'", "'" + input.LastUpdate.Value.ToShortDateString() + "'" };
                var classKeys = Data.GetObjectKeys(new Users()).Where(x => x != "IdUser" && x != "DateIn").ToList();
                var sql = Data.UpdateExpression("Users", classKeys, parameters, "WHERE IdUser = " + input.IdUser);
                var (response, message) = Data.CrudAction(sql, "EmployeesRepository.UpdateUser");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo EmployeesRepository.UpdateUser \n" + ex.Message.ToString());
            }
        }
    }
}
