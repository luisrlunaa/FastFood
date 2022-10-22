using FastFood.Infrastructure.DataAccess.Contexts;
using FastFood.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FastFood.Infrastructure.DataAccess.Repositories
{
    public class ClientsRepository
    {
        DataManager Data = new DataManager();

        public (List<Client>, string) GetClients()
        {
            var Clients = new List<Client>();
            try
            {
                var classKeys = Data.GetObjectKeys(new Client());
                var sql = Data.SelectExpression("Client", classKeys);
                var (dtPC, message) = Data.GetList(sql, "ClientsRepository.GetClients");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (Clients, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    var s = new Client();
                    s.FirstName = reader["FirstName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FirstName"]);
                    s.LastName = reader["LastName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["LastName"]);
                    s.DocumentNo = reader["DocumentNo"] == DBNull.Value ? string.Empty : Convert.ToString(reader["DocumentNo"]);

                    Clients.Add(s);
                }

                return (Clients, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Clients, "Error al Cargar Data, Metodo ClientsRepository.GetClients \n" + ex.Message.ToString());
            }
        }

        public (Client, string) GetClientByDocumentNoOrName(string str)
        {
            var s = new Client();
            try
            {
                if (string.IsNullOrWhiteSpace(str))
                    return (s, "Error Input Invalido, Metodo ClientsRepository.GetClientsByDocumentNo");

                var classKeys = Data.GetObjectKeys(new Client());
                var sql = Data.SelectExpression("Client", classKeys, WhereExpresion: " WHERE DocumentNo = '" + str + "' OR FirstName LIKE '%" + str + "%' OR LastName LIKE '%" + str + "%'");
                var (dr, message1) = Data.GetOne(sql, "ClientsRepository.GetClientByDocumentNoOrName");
                if (dr is null)
                    return (s, message1);

                s.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                s.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                s.DocumentNo = dr.GetString(dr.GetOrdinal("DocumentNo"));
                s.DocumentType = dr.GetString(dr.GetOrdinal("DocumentType"));
                s.Birthday = dr.GetDateTime(dr.GetOrdinal("Birthday"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo ClientsRepository.GetClientByDocumentNoOrName \n" + ex.Message.ToString());
            }
        }

        public (bool, string) AddClient(Client input)
        {
            try
            {
                if (input == null || input.DateIn == DateTime.MinValue)
                    return (false, "Error Input Invalido, Metodo ClientsRepository.AddClient");

                var parameters = new List<string> { "'" + input.DocumentNo + "'", "'" + input.FirstName + "'", "'" + input.LastName + "'", "'" + input.DocumentType + "'", "'" + input.Birthday.ToShortDateString() + "'", "'" + input.DateIn.Value.ToShortDateString() + "'" };
                var classKeys = Data.GetObjectKeys(new Client()).Where(x => x != "LastUpdate").ToList();
                var sql = Data.InsertExpression("Client", classKeys, parameters);
                var (response, message) = Data.CrudAction(sql, "ClientsRepository.AddClient");
                if (!response)
                    return (response, message);

                return (response, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo ClientsRepository.AddClient \n" + ex.Message.ToString());
            }
        }

        public (bool, string) UpdateClient(Client input, string lastID = null)
        {
            try
            {
                if (input == null)
                    return (false, "Error Input Invalido, Metodo ClientsRepository.UpdateClient");

                var id = string.IsNullOrWhiteSpace(lastID) ? input.DocumentNo : lastID;
                var parameters = new List<string> { "'" + input.DocumentNo + "'", "'" + input.FirstName + "'", "'" + input.LastName + "'", "'" + input.DocumentType + "'", "'" + input.Birthday.ToShortDateString() + "'", "'" + input.LastUpdate.Value.ToShortDateString() + "'" };
                var classKeys = Data.GetObjectKeys(new Client()).Where(x => x != "DateIn").ToList();
                var sql = Data.UpdateExpression("Client", classKeys, parameters, " WHERE DocumentNo = '" + id + "'");
                var (response, message) = Data.CrudAction(sql, "ClientsRepository.UpdateClient");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo ClientsRepository.UpdateClient \n" + ex.Message.ToString());
            }
        }

        public (bool, string) DeleteClient(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    return (false, "Error Input Invalido, Metodo ClientsRepository.DeleteClient");

                var sql = Data.DeleteExpression("Client", " WHERE DocumentNo = " + id);
                var (response, message) = Data.CrudAction(sql, "ClientsRepository.DeleteClient");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo ClientsRepository.DeleteClient \n" + ex.Message.ToString());
            }
        }
    }
}
