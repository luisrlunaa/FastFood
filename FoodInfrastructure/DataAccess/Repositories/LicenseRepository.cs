using FastFood.Infrastructure.DataAccess.Contexts;
using FastFood.Infrastructure.Utils;
using FastFood.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood.Infrastructure.DataAccess.Repositories
{
    public class LicenseRepository
    {
        DataManager Data = new DataManager();
        public (License, string) GetLicense()
        {
            var Licenses = new License();
            try
            {
                var classKeys = Data.GetObjectKeys(new License());
                var sql = Data.SelectExpression("License", classKeys, Top: "1", OrderBy: "LastUpdate DESC");
                var (dr, message1) = Data.GetOne(sql, "LicenseRepository.GetLicense");
                if (dr is null)
                    return (Licenses, message1);

                Licenses.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                Licenses.Business = dr.GetString(dr.GetOrdinal("Business"));
                Licenses.InitialSequence = dr.GetInt32(dr.GetOrdinal("InitialSequence"));
                Licenses.CentralSequence = dr.GetInt32(dr.GetOrdinal("CentralSequence"));
                Licenses.FinalSequence = dr.GetInt32(dr.GetOrdinal("FinalSequence"));
                Licenses.Provider = dr.GetString(dr.GetOrdinal("Provider"));
                if (dr["SecretWord"].GetType() != typeof(DBNull))
                    Licenses.SecretWord = dr.GetString(dr.GetOrdinal("SecretWord"));
                if (dr["LastUpdate"].GetType() != typeof(DBNull))
                    Licenses.LastUpdate = dr.GetDateTime(dr.GetOrdinal("LastUpdate"));

                Licenses = AnyNullValueHelper.AnyNullValue<License>(Licenses);
                return (Licenses, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Licenses, "Error al Cargar Data, Metodo LicenseRepository.GetLicense \n" + ex.Message.ToString());
            }
        }

        public (bool, string) UpdateLicense(License License)
        {
            try
            {
                if (License == null)
                    return (false, "Error Input Invalido, Metodo LicenseRepository.UpdateLicense");

                License = AnyNullValueHelper.AnyNullValue<License>(License);
                var parameters = new List<string> {"'"+License.Business+"'", "'"+License.InitialSequence+"'", "'"+License.CentralSequence+"'", "'"+License.FinalSequence+"'",
                "'"+License.Provider+"'", "'"+License.SecretWord +"'", "'"+License.LastUpdate.Value.ToShortDateString()+"'"};

                var classKeys = Data.GetObjectKeys(new License()).Where(x => x != "Id").ToList();
                var sql = Data.UpdateExpression("License", classKeys, parameters, " WHERE Id = " + License.Id);
                var (response, message) = Data.CrudAction(sql, "LicenseRepository.UpdateLicense");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo LicenseRepository.UpdateLicense \n" + ex.Message.ToString());
            }
        }
    }
}
