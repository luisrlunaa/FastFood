using FastFood.Infrastructure.DataAccess.Contexts;
using FastFood.Models.Entities;
using System;

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

                return (BusinessInfos, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (BusinessInfos, "Error al Cargar Data, Metodo BusinessRepository.GetBusinessInfo \n" + ex.Message.ToString());
            }
        }
    }
}
