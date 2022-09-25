using FastFood.Infrastructure.DataAccess.Contexts;
using FastFood.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;

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
                var (dtPC, message) = Data.GetList(sql);
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

        public (Employee, string) GetEmployeeById(int id)
        {
            var s = new Employee();
            try
            {
                var classKeys = Data.GetObjectKeys(new Employee());
                var sql = Data.SelectExpression("Employee", classKeys, WhereExpresion: "WHERE IdEmp = " + id);
                var (dr, message1) = Data.GetOne(sql);
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

        public (Employee, string) GetEmployeeByUserid(int id)
        {
            var s = new Employee();
            try
            {
                var classKeys = Data.GetObjectKeys(new Employee());
                var sql = Data.SelectExpression("Employee", classKeys, WhereExpresion: "WHERE IdUser = " + id);
                var (dr, message1) = Data.GetOne(sql);
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
                var (dtPC, message) = Data.GetList(sql);
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
    }
}
