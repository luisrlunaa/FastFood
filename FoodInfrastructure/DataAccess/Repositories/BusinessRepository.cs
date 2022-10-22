using FastFood.Infrastructure.DataAccess.Contexts;
using FastFood.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Infrastructure.DataAccess.Repositories
{
    public class BusinessRepository
    {
        DataManager Data = new DataManager();
        public (BusinessInfo, string) GetBusinessInfo(int id)
        {
            var BusinessInfos = new BusinessInfo();
            try
            {
                var classKeys = Data.GetObjectKeys(new BusinessInfo());
                var sql = Data.SelectExpression("BusinessInfo", classKeys, WhereExpresion: "WHERE BusinessId = " + id);
                var (dr, message1) = Data.GetOne(sql, "BusinessRepository.GetBusinessInfo");
                if (dr is null)
                    return (BusinessInfos, message1);

                BusinessInfos.BusinessId = dr.GetInt32(dr.GetOrdinal("BusinessId"));
                BusinessInfos.Name = dr.GetString(dr.GetOrdinal("Name"));
                BusinessInfos.Address = dr.GetString(dr.GetOrdinal("Address"));
                BusinessInfos.Phone1 = dr.GetString(dr.GetOrdinal("Phone1"));
                BusinessInfos.Phone2 = dr.GetString(dr.GetOrdinal("Phone2"));
                BusinessInfos.RNC = dr.GetString(dr.GetOrdinal("RNC"));
                BusinessInfos.PrinterName = dr["PrinterName"].GetType() != typeof(DBNull)
                                          ? dr.GetString(dr.GetOrdinal("PrinterName"))
                                          : "POS-80";
                if (dr["SystemColor"].GetType() != typeof(DBNull))
                    BusinessInfos.SystemColor = dr.GetString(dr.GetOrdinal("SystemColor"));
                if (dr["LicenseActual"].GetType() != typeof(DBNull))
                    BusinessInfos.LicenseActual = dr.GetString(dr.GetOrdinal("LicenseActual"));
                if (dr["ExpirationDate"].GetType() != typeof(DBNull))
                    BusinessInfos.ExpirationDate = dr.GetDateTime(dr.GetOrdinal("ExpirationDate"));

                return (BusinessInfos, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (BusinessInfos, "Error al Cargar Data, Metodo BusinessRepository.GetBusinessInfo \n" + ex.Message.ToString());
            }
        }

        public (bool, string) UpdateBusinessInfo(BusinessInfo businessInfo)
        {
            try
            {
                if (businessInfo == null)
                    return (false, "Error Input Invalido, Metodo BusinessRepository.UpdateBusinessInfo");

                var parameters = new List<string> {"'"+businessInfo.Name+"'", "'"+businessInfo.Address+"'", "'"+businessInfo.Phone1+"'", "'"+businessInfo.Phone2+"'",
                "'"+businessInfo.RNC+"'", "'"+businessInfo.PrinterName +"'","'" + businessInfo.SystemColor+"'","'" + businessInfo.LicenseActual+"'", "'"+businessInfo.ExpirationDate.Value.ToShortDateString()+"'"};

                var classKeys = Data.GetObjectKeys(new BusinessInfo()).Where(x => x != "BusinessId").ToList();
                var sql = Data.UpdateExpression("BusinessInfo", classKeys, parameters, "WHERE BusinessId = " + businessInfo.BusinessId);
                var (response, message) = Data.CrudAction(sql, "BusinessRepository.UpdateBusinessInfo");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo BusinessRepository.UpdateBusinessInfo \n" + ex.Message.ToString());
            }
        }
    }
}
