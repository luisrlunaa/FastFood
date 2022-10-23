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

        #region Employees
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
                    s.EmployeeType = reader["EmployeeType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["EmployeeType"]);
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

        public (Employee, string) GetEmployeeById(int id)
        {
            var s = new Employee();
            try
            {
                if (id == 0)
                    return (s, "Error Input Invalido, Metodo EmployeesRepository.GetEmployeeById");

                var classKeys = Data.GetObjectKeys(new Employee());
                var sql = Data.SelectExpression("Employee", classKeys, WhereExpresion: " WHERE IdEmp = " + id);
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetEmployeeById");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));
                s.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                s.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                s.DocumentNo = dr.GetString(dr.GetOrdinal("DocumentNo"));
                s.DocumentType = dr.GetString(dr.GetOrdinal("DocumentType"));
                s.EmployeeType = dr.GetString(dr.GetOrdinal("EmployeeType"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetEmployeeById \n" + ex.Message.ToString());
            }
        }

        public (Employee, string) GetEmployeeByUserid(int id)
        {
            var s = new Employee();
            try
            {
                if (id == 0)
                    return (s, "Error Input Invalido, Metodo EmployeesRepository.GetEmployeeByUserid");

                var classKeys = Data.GetObjectKeys(new Employee());
                var sql = Data.SelectExpression("Employee", classKeys, WhereExpresion: " WHERE IdUser = " + id);
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetEmployeeByUserid");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));
                s.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                s.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                s.DocumentNo = dr.GetString(dr.GetOrdinal("DocumentNo"));
                s.DocumentType = dr.GetString(dr.GetOrdinal("DocumentType"));
                s.EmployeeType = dr.GetString(dr.GetOrdinal("EmployeeType"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetEmployeeByUserid \n" + ex.Message.ToString());
            }
        }

        public (Employee, string) GetEmployeeByDocumentNo(string documentNo)
        {
            var s = new Employee();
            try
            {
                if (string.IsNullOrWhiteSpace(documentNo))
                    return (s, "Error Input Invalido, Metodo EmployeesRepository.GetEmployeesByDocumentNo");

                var classKeys = Data.GetObjectKeys(new Employee());
                var sql = Data.SelectExpression("Employee", classKeys, WhereExpresion: " WHERE DocumentNo = '" + documentNo + "'");
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetEmployeeByDocumentNo");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));
                s.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                s.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                s.DocumentNo = dr.GetString(dr.GetOrdinal("DocumentNo"));
                s.DocumentType = dr.GetString(dr.GetOrdinal("DocumentType"));
                s.EmployeeType = dr.GetString(dr.GetOrdinal("EmployeeType"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetEmployeeByDocumentNo \n" + ex.Message.ToString());
            }
        }

        public (Employee, string) GetLastEmployee()
        {
            var s = new Employee();
            try
            {
                var classKeys = Data.GetObjectKeys(new Employee());
                var sql = Data.SelectExpression("Employee", classKeys, Top: "1", OrderBy: "DateIn DESC");
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetEmployeeByUserid");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                if(dr["IdUser"].GetType() != typeof(DBNull))
                    s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));

                s.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                s.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                s.DocumentNo = dr.GetString(dr.GetOrdinal("DocumentNo"));
                s.DocumentType = dr.GetString(dr.GetOrdinal("DocumentType"));
                s.EmployeeType = dr.GetString(dr.GetOrdinal("EmployeeType"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetLastEmployee \n" + ex.Message.ToString());
            }
        }

        public (bool, string) AddEmployee(Employee input)
        {
            try
            {
                if (input == null || input.DateIn == DateTime.MinValue)
                    return (false, "Error Input Invalido, Metodo EmployeesRepository.AddEmployee");

                var parameters = new List<string> {input.IdUser > 0 ? input.IdUser.ToString() : "NULL", "'"+input.FirstName+"'", "'"+input.LastName+"'", "'"+input.DocumentNo+"'", "'"+input.DocumentType+"'", "'"+input.EmployeeType+"'",
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

        public (bool, string) UpdateEmployee(Employee input, bool isAdmin)
        {
            try
            {
                if (input == null)
                    return (false, "Error Input Invalido, Metodo EmployeesRepository.UpdateEmployee");

                var parameters = new List<string>();
                var classKeys = new List<string>();

                if (isAdmin)
                {
                    parameters = new List<string> { input.IdUser.ToString(), "'" + input.FirstName + "'", "'" + input.LastName + "'", "'" + input.DocumentNo + "'", "'" + input.DocumentType + "'", "'" + input.EmployeeType + "'",
                    "'"+input.LastUpdate.Value.ToShortDateString()+"'"};

                    classKeys = Data.GetObjectKeys(new Employee()).Where(x => x != "IdEmp" && x != "DateIn").ToList();
                }
                else
                {
                    parameters = new List<string> { "'" + input.FirstName + "'", "'" + input.LastName + "'", "'" + input.LastUpdate.Value.ToShortDateString() + "'" };

                    classKeys = Data.GetObjectKeys(new Employee()).Where(x => x != "IdEmp" && x != "DateIn" && x != "DocumentNo" && x != "DocumentType" && x != "EmployeeType").ToList();
                }


                var sql = Data.UpdateExpression("Employee", classKeys, parameters, " WHERE IdEmp = " + input.IdEmp);
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

        public (bool, string) DeleteEmployee(int id)
        {
            try
            {
                if (id == 0)
                    return (false, "Error Input Invalido, Metodo EmployeesRepository.DeleteEmployee");

                var sql = Data.DeleteExpression("Employee", " WHERE IdEmp = " + id);
                var (response, message) = Data.CrudAction(sql, "EmployeesRepository.DeleteEmployee");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo EmployeesRepository.DeleteEmployee \n" + ex.Message.ToString());
            }
        }
        #endregion

        #region Users
        public (List<Users>, string) GetUsers()
        {
            var Userss = new List<Users>();
            try
            {
                var classKeys = Data.GetObjectKeys(new Users());
                var sql = Data.SelectExpression("Users", classKeys);
                var (dtPC, message) = Data.GetList(sql, "EmployeesRepository.GetUsers");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (Userss, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    var s = new Users();
                    s.IdEmp = reader["IdEmp"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdEmp"]);
                    s.IdUser = reader["IdUser"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdUser"]);
                    s.UserName = reader["UserName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["UserName"]);
                    s.Password = reader["Password"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Password"]);
                    s.DateIn = reader["DateIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateIn"]);
                    s.LastUpdate = reader["LastUpdate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["LastUpdate"]);

                    Userss.Add(s);
                }

                return (Userss, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Userss, "Error al Cargar Data, Metodo EmployeesRepository.GetUsers \n" + ex.Message.ToString());
            }
        }

        public (bool, string) GetExistsUser()
        {
            var parameter = new string[] { "count(*) As UserCount"};
            var sql = Data.SelectExpression("Users", parameter.ToList());
            var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetExitsUser");
            if (dr is null)
                return (false, message1);

           var count= dr.GetInt32(dr.GetOrdinal("UserCount"));
           return (count > 0, "Proceso Completado");
        }

        public (Users, string) GetUserByUserId(int id)
        {
            var s = new Users();
            try
            {
                if (id == 0)
                    return (s, "Error Input Invalido, Metodo EmployeesRepository.GetUserByUserId");

                var classKeys = Data.GetObjectKeys(new Users());
                var sql = Data.SelectExpression("Users", classKeys, WhereExpresion: " WHERE IdUser = " + id);
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetUserByUserId");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));
                s.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                s.Password = dr.GetString(dr.GetOrdinal("Password"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetUserByUserId \n" + ex.Message.ToString());
            }
        }

        public (Users, string) GetUserByEmployeeId(int id)
        {
            var s = new Users();
            try
            {
                if (id == 0)
                    return (s, "Error Input Invalido, Metodo EmployeesRepository.GetUserByEmployeeId");

                var classKeys = Data.GetObjectKeys(new Users());
                var sql = Data.SelectExpression("Users", classKeys, WhereExpresion: " WHERE IdEmp = " + id);
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetUserByUserId");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));
                s.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                s.Password = dr.GetString(dr.GetOrdinal("Password"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetUserByUserId \n" + ex.Message.ToString());
            }
        }

        public (Users, string) GetUserByUserName(string userName)
        {
            var s = new Users();
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                    return (s, "Error Input Invalido, Metodo EmployeesRepository.GetUserByUserName");

                var classKeys = Data.GetObjectKeys(new Users());
                var sql = Data.SelectExpression("Users", classKeys, WhereExpresion: " WHERE UserName = '" + userName + "'");
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetUserByUserName");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));
                s.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                s.Password = dr.GetString(dr.GetOrdinal("Password"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetUserByUserName \n" + ex.Message.ToString());
            }
        }

        public (Users, string) GetLastUser()
        {
            var s = new Users();
            try
            {
                var classKeys = Data.GetObjectKeys(new Users());
                var sql = Data.SelectExpression("Users", classKeys, Top: "1", OrderBy: "DateIn DESC");
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetUserByUserId");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));
                s.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                s.Password = dr.GetString(dr.GetOrdinal("Password"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetUserByUserId \n" + ex.Message.ToString());
            }
        }

        public (Users, string) GetUserByUserNameAndPassword(string userName, string pass)
        {
            var s = new Users();
            try
            {
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(pass))
                    return (s, "Error Input Invalido, Metodo EmployeesRepository.GetUserByUserNameAndPassword");

                var classKeys = Data.GetObjectKeys(new Users());
                var sql = Data.SelectExpression("Users", classKeys, WhereExpresion: " WHERE UserName = '" + userName + "' AND Password = '" + pass + "'");
                var (dr, message1) = Data.GetOne(sql, "EmployeesRepository.GetUserByUserName");
                if (dr is null)
                    return (s, message1);

                s.IdEmp = dr.GetInt32(dr.GetOrdinal("IdEmp"));
                s.IdUser = dr.GetInt32(dr.GetOrdinal("IdUser"));
                s.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                s.Password = dr.GetString(dr.GetOrdinal("Password"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo EmployeesRepository.GetUserByUserName \n" + ex.Message.ToString());
            }
        }

        public (bool, string) AddUser(Users input)
        {
            try
            {
                if (input == null || input.DateIn == DateTime.MinValue)
                    return (false, "Error Input Invalido, Metodo EmployeesRepository.AddSale");

                var parameters = new List<string> { input.IdEmp.ToString(), "'" + input.UserName + "'", "'" + input.Password + "'", "'" + input.DateIn.Value.ToShortDateString() + "'" };
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

        public (bool, string) UpdateUser(Users input)
        {
            try
            {
                if (input == null)
                    return (false, "Error Input Invalido, Metodo EmployeesRepository.UpdateUser");

                var parameters = new List<string> { input.IdEmp.ToString(), "'" + input.UserName + "'", "'" + input.Password + "'", "'" + input.LastUpdate.Value.ToShortDateString() + "'" };
                var classKeys = Data.GetObjectKeys(new Users()).Where(x => x != "IdUser" && x != "DateIn").ToList();
                var sql = Data.UpdateExpression("Users", classKeys, parameters, " WHERE IdUser = " + input.IdUser);
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

        public (bool, string) DeleteUser(int id)
        {
            try
            {
                if (id == 0)
                    return (false, "Error Input Invalido, Metodo EmployeesRepository.DeleteUser");

                var sql = Data.DeleteExpression("Users", " WHERE IdEmp = " + id);
                var (response, message) = Data.CrudAction(sql, "EmployeesRepository.DeleteUser");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo EmployeesRepository.DeleteUser \n" + ex.Message.ToString());
            }
        }
        #endregion
    }
}
