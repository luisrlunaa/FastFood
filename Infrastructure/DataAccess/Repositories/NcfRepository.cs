using FastFood.Infrastructure.DataAccess.Contexts;
using FastFood.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FastFood.Infrastructure.DataAccess.Repositories
{
    public class NcfRepository
    {
        DataManager Data = new DataManager();

        public (List<Receipts>, string) GetReceipts()
        {
            var Receipts = new List<Receipts>();
            try
            {
                var classKeys = Data.GetObjectKeys(new Receipts());
                var sql = Data.SelectExpression("Receipts", classKeys, OrderBy: "Id_ncf");
                var (dtPC, message) = Data.GetList(sql, "NcfRepository.GetReceipts");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (Receipts, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    var s = new Receipts();
                    s.Id_ncf = reader["Id_ncf"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id_ncf"]);
                    s.Initialsequence = reader["Initialsequence"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Initialsequence"]);
                    s.Finalsequence = reader["Finalsequence"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Finalsequence"]);
                    s.DateFrom = reader["DateFrom"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateFrom"]);
                    s.DateTo = reader["DateTo"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateTo"]);

                    Receipts.Add(s);
                }

                return (Receipts, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Receipts, "Error al Cargar Data, Metodo NcfRepository.GetReceipts \n" + ex.Message.ToString());
            }
        }

        public (List<NCFDto>, string) GetNCFActives()
        {
            var Receipts = new List<NCFDto>();
            try
            {
                var join = Data.JoinExpression("INNER", new List<string>() { "Receipts" }, new List<string>() { "NCF" }, new List<string>() { "Id_ncf" });
                var classKeys = new List<string>() { "NCF.Id_ncf", "NCF.Description_ncf", "Receipts.Active" };
                var sql = Data.SelectExpression("NCF", classKeys, JoinExp: join, OrderBy: "NCF.Id_ncf");
                var (dtPC, message) = Data.GetList(sql, "NcfRepository.GetNCFActives");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (Receipts, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    var s = new NCFDto();
                    s.Id_ncf = reader["Id_ncf"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id_ncf"]);
                    s.Description_ncf = reader["Description_ncf"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Description_ncf"]);
                    s.Active = reader["Active"] == DBNull.Value ? false : Convert.ToBoolean(reader["Active"]);

                    Receipts.Add(s);
                }

                return (Receipts, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Receipts, "Error al Cargar Data, Metodo NcfRepository.GetNCFActives \n" + ex.Message.ToString());
            }
        }

        public (Receipts, string) GetReceiptsbyId(int id)
        {
            var s = new Receipts();
            try
            {
                var classKeys = Data.GetObjectKeys(new Receipts());
                var sql = Data.SelectExpression("Receipts", classKeys, WhereExpresion: "WHERE Id_ncf = " + id);
                var (dr, message1) = Data.GetOne(sql, "NcfRepository.GetReceiptsbyId");
                if (dr is null)
                    return (s, message1);

                s.Id_ncf = dr.GetInt32(dr.GetOrdinal("Id_ncf"));
                s.Initialsequence = dr.GetInt32(dr.GetOrdinal("Initialsequence"));
                s.Finalsequence = dr.GetInt32(dr.GetOrdinal("Finalsequence"));
                s.DateFrom = dr.GetDateTime(dr.GetOrdinal("DateFrom"));
                s.DateTo = dr.GetDateTime(dr.GetOrdinal("DateTo"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo NcfRepository.GetReceiptsbyId \n" + ex.Message.ToString());
            }
        }

        public (List<NCF>, string) GetNCFs()
        {
            var Receipts = new List<NCF>();
            try
            {
                var classKeys = Data.GetObjectKeys(new NCF());
                var sql = Data.SelectExpression("NCF", classKeys);
                var (dtPC, message) = Data.GetList(sql, "NcfRepository.GetNCFs");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (Receipts, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    var s = new NCF();
                    s.Id_ncf = reader["Id_ncf"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id_ncf"]);
                    s.Description_ncf = reader["Description_ncf"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Description_ncf"]);
                    s.Prefix = reader["Prefix"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Prefix"]);
                    s.Initialsequence = reader["Initialsequence"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Initialsequence"]);
                    s.Finalsequence = reader["Finalsequence"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Finalsequence"]);

                    Receipts.Add(s);
                }

                return (Receipts, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Receipts, "Error al Cargar Data, Metodo NcfRepository.GetNCFs \n" + ex.Message.ToString());
            }
        }

        public (List<NCF>, string) GetActivesNCFs()
        {
            var Receipts = new List<NCF>();
            try
            {
                var join = Data.JoinExpression("INNER", new List<string>() { "Receipts" }, new List<string>() { "NCF" }, new List<string>() { "Id_ncf" });
                var classKeys = Data.GetObjectKeys(new NCF(), "NCF");
                var sql = Data.SelectExpression("NCF", classKeys, JoinExp: join, WhereExpresion: " WHERE Receipts.Active = 1");
                var (dtPC, message) = Data.GetList(sql, "NcfRepository.GetNCFsActives");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (Receipts, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    var s = new NCF();
                    s.Id_ncf = reader["Id_ncf"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id_ncf"]);
                    s.Description_ncf = reader["Description_ncf"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Description_ncf"]);
                    s.Prefix = reader["Prefix"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Prefix"]);
                    s.Initialsequence = reader["Initialsequence"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Initialsequence"]);
                    s.Finalsequence = reader["Finalsequence"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Finalsequence"]);

                    Receipts.Add(s);
                }

                return (Receipts, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Receipts, "Error al Cargar Data, Metodo NcfRepository.GetNCFsActives \n" + ex.Message.ToString());
            }
        }

        public (NCF, string) GetNCFbyId(int id)
        {
            var s = new NCF();
            try
            {
                if (id == 0)
                    return (s, "Error Input Invalido, Metodo NcfRepository.GetNCFbyId");

                var classKeys = Data.GetObjectKeys(new NCF());
                var sql = Data.SelectExpression("NCF", classKeys, WhereExpresion: "WHERE Id_ncf = " + id);
                var (dr, message1) = Data.GetOne(sql, "NcfRepository.GetNCFbyId");
                if (dr is null)
                    return (s, message1);

                s.Id_ncf = dr.GetInt32(dr.GetOrdinal("Id_ncf"));
                s.Initialsequence = dr.GetInt32(dr.GetOrdinal("Initialsequence"));
                s.Finalsequence = dr.GetInt32(dr.GetOrdinal("Finalsequence"));
                s.Prefix = dr.GetString(dr.GetOrdinal("Prefix"));
                s.Description_ncf = dr.GetString(dr.GetOrdinal("Description_ncf"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo NcfRepository.GetNCFbyId \n" + ex.Message.ToString());
            }
        }

        public (bool, string) AddNCFGenerated(NCFGenerated input)
        {
            try
            {
                if (input == null || input.Datein == DateTime.MinValue)
                    return (false, "Error  Input Invalido, Metodo NcfRepository.AddNCFGenerated");

                var parameters = new List<string> { input.Id_sequence.ToString(), "'" + input.SequenceNCF + "'", "'" + input.Datein.ToShortDateString() + "'" };
                var classKeys = Data.GetObjectKeys(new NCFGenerated()).ToList();
                var sql = Data.InsertExpression("NCFGenerated", classKeys, parameters);
                var (response, message) = Data.CrudAction(sql, "NcfRepository.AddNCFGenerated");
                if (!response)
                    return (response, message);

                var sql1 = "Update Receipts SET Initialsequence = (Initialsequence + 1)  WHERE Id_ncf = " + input.Id_sequence;
                var (response1, message1) = Data.CrudAction(sql, "NcfRepository.AddNCFGenerated UpdateReceipts Process");
                if (!response1)
                    return (response1, message1);

                var sql2 = "Update NCF SET Initialsequence = (Initialsequence + 1)  WHERE Id_ncf = " + input.Id_sequence;
                var (response2, message2) = Data.CrudAction(sql, "NcfRepository.AddNCFGenerated UpdateNCF Process");
                if (!response1)
                    return (response1, message1);

                return (response, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo NcfRepository.AddNCFGenerated \n" + ex.Message.ToString());
            }
        }

        public (bool, string) UpdateReceipts(Receipts input)
        {
            try
            {
                if (input == null)
                    return (false, "Error Input Invalido, Metodo NcfRepository.UpdateReceipts");

                var active = input.Active ? 1 : 0;
                var parameters = new List<string> { input.Initialsequence.ToString(), "'" + input.Finalsequence + "'", "'" + input.DateFrom.ToShortDateString() + "'", "'" + input.DateTo.ToShortDateString() + "'", active.ToString() };
                var classKeys = Data.GetObjectKeys(new Receipts()).Where(x => x != "Id_ncf").ToList();
                var sql = Data.UpdateExpression("Receipts", classKeys, parameters, "WHERE Id_ncf = " + input.Id_ncf);
                var (response, message) = Data.CrudAction(sql, "NcfRepository.UpdateReceipts");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo NcfRepository.UpdateReceipts \n" + ex.Message.ToString());
            }
        }

        public (bool, string) UpdateNCF(NCF input)
        {
            try
            {
                if (input == null)
                    return (false, "Error Input Invalido, Metodo NcfRepository.UpdateNCF");

                var parameters = new List<string> { input.Initialsequence.ToString(), "'" + input.Finalsequence + "'" };
                var classKeys = Data.GetObjectKeys(new NCF()).Where(x => x != "Id_ncf" && x != "Description_ncf" && x != "Prefix").ToList();
                var sql = Data.UpdateExpression("NCF", classKeys, parameters, "WHERE Id_ncf = " + input.Id_ncf);
                var (response, message) = Data.CrudAction(sql, "NcfRepository.UpdateNCF");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo NcfRepository.UpdateNCF \n" + ex.Message.ToString());
            }
        }

        public (bool, string) CheckInActiveReceipts()
        {
            try
            {
                var parameters = new List<string> { 0.ToString() };
                var classKeys = new List<string> { "Active" };
                var sql = Data.UpdateExpression("Receipts", classKeys, parameters, "WHERE Initialsequence = Finalsequence OR DateTo <= GetDate()");
                var (response, message) = Data.CrudAction(sql, "NcfRepository.CheckActiveReceipts");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo NcfRepository.CheckActiveReceipts \n" + ex.Message.ToString());
            }
        }

        public (bool, string) CheckActiveReceipts()
        {
            try
            {
                var parameters = new List<string> { 1.ToString() };
                var classKeys = new List<string> { "Active" };
                var sql = Data.UpdateExpression("Receipts", classKeys, parameters, "WHERE Finalsequence > Initialsequence AND DateTo > GetDate()");
                var (response, message) = Data.CrudAction(sql, "NcfRepository.CheckActiveReceipts");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo NcfRepository.CheckActiveReceipts \n" + ex.Message.ToString());
            }
        }

        public (string, string) GetNextNCFbyId(int id_ncf)
        {
            var nextNcf = string.Empty;
            try
            {
                if (id_ncf == 0)
                    return (nextNcf, "Error Input Invalido, Metodo NcfRepository.UpdateReceipts");

                var (ncf, message) = GetNCFbyId(id_ncf);
                if (ncf == null)
                    return (nextNcf, message);

                nextNcf = ncf.Prefix + ncf.Initialsequence.ToString("00000000");

                return (nextNcf, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (nextNcf, "Error al Cargar Data, Metodo NcfRepository.GetNextNCFbyId \n" + ex.Message.ToString());
            }
        }
    }
}