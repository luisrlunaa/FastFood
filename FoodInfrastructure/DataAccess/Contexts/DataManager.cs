using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace FastFood.Infrastructure.DataAccess.Contexts
{
    public class DataManager
    {
        public static SqlConnection connectionStr;

        public string GetConnectionString()
        {
            return connectionStr.ConnectionString;
        }

        public void Connect()
        {
            if (connectionStr.State == ConnectionState.Closed)
                connectionStr.Open();
        }

        public void Disconnect()
        {
            if (connectionStr.State == ConnectionState.Open)
                connectionStr.Close();
        }

        #region CRUD EXPRESSIONS
        //Create ---- TableName, List ColumnsName, List ParameterValue
        public string InsertExpression(string TableName, List<string> ColumnsName, List<string> ParameterValue)
        {
            if (string.IsNullOrWhiteSpace(TableName))
                return "Nombre de tabla requerido. Metodo InsertExpression()";

            if (ColumnsName is null || ParameterValue is null)
                return "Parametros o columnas no tiene valor. Metodo InsertExpression()";

            if (ColumnsName.Count != ParameterValue.Count)
                return "Parametros y columnas no tienen la misma cantidad. Metodo InsertExpression()";

            var expression =
                "INSERT INTO "
                + TableName
                + "(" + string.Join(",", ColumnsName) + ")"
                + "VALUES"
                + "(" + string.Join(",", ParameterValue) + ")";

            return expression;
        }

        //Read ---- TableName, Top, List ColumnsName, WhereExpresion, GroupBy, OrderBy, Having, JoinExp
        public string SelectExpression(string TableName, List<string> ColumnsName, string Top = null, string WhereExpresion = null, string GroupBy = null, string OrderBy = null, string Having = null, string JoinExp = null)
        {
            if (string.IsNullOrWhiteSpace(TableName))
                return "Nombre de tabla requerido. Metodo SelectExpression()";

            if (ColumnsName is null)
                return "Columnas no tiene valor. Metodo SelectExpression()";

            var expression =
                "SELECT "
                + (string.IsNullOrWhiteSpace(Top) ? "" : " TOP " + Top)
                + (ColumnsName.Count == 0 ? "" : " " + string.Join(",", ColumnsName))
                + " FROM "
                + TableName + " "
                + (string.IsNullOrWhiteSpace(JoinExp) ? "" : JoinExp) //INNER JOIN Table2 ON Table1.ColumnName = Table2.ColumnName)
                + (string.IsNullOrWhiteSpace(WhereExpresion) ? "" : WhereExpresion.ToLower().Contains("where") ? WhereExpresion : "") //WHERE ColumnName1 = 'value' OR ColumnName2 = 'value'
                + (string.IsNullOrWhiteSpace(GroupBy) ? "" : " GROUP BY  " + GroupBy) //GROUP BY ColumnName
                + (string.IsNullOrWhiteSpace(Having) ? "" : " HAVING  " + Having) //HAVING COUNT(ColumnName) > 5
                + (string.IsNullOrWhiteSpace(OrderBy) ? "" : " ORDER BY  " + OrderBy); //ORDER BY ColumnName  ---DESC

            return expression;
        }

        //Update ---- TableName, List ColumnsName, List ParameterValue, WhereExpresion
        public string UpdateExpression(string TableName, List<string> ColumnsName, List<string> ParameterValue, string WhereExpresion)
        {
            if (string.IsNullOrWhiteSpace(TableName))
                return "Nombre de tabla requerido. Metodo UpdateExpression()";

            if (string.IsNullOrWhiteSpace(WhereExpresion))
                return "Condicional requerida. Metodo UpdateExpression()";

            if (!WhereExpresion.ToLower().Contains("where"))
                return "Condicional debe contener la palabra Where. Metodo UpdateExpression()";

            if (ColumnsName is null || ParameterValue is null)
                return "Parametros o columnas no tiene valor. Metodo UpdateExpression()";

            if (ColumnsName.Count != ParameterValue.Count)
                return "Parametros y columnas no tienen la misma cantidad. Metodo UpdateExpression()";

            var valuesExpresion = new List<string>();
            ColumnsName.ForEach(x => valuesExpresion.Add(x + "=" + ParameterValue[ColumnsName.IndexOf(x)]));

            var expression =
                "UPDATE "
                + TableName
                + " SET " +
                string.Join(",", valuesExpresion) + " " +
                WhereExpresion;

            return expression;
        }

        //Delete ---- TableName, List ColumnsName, List ParameterValue, WhereExpresion
        public string DeleteExpression(string TableName, string WhereExpresion)
        {
            if (string.IsNullOrWhiteSpace(TableName))
                return "Nombre de tabla requerido. Metodo DeleteExpression()";

            if (string.IsNullOrWhiteSpace(WhereExpresion))
                return "Condicional requerida. Metodo DeleteExpression()";

            if (!WhereExpresion.ToLower().Contains("where"))
                return "Condicional debe contener la palabra Where. Metodo DeleteExpression()";

            var expression =
                "DELETE "
                + TableName + " "
                + WhereExpresion;

            return expression;
        }

        //Join ---- Type, List Tables2, List Tables1, List ColumnRelation
        public string JoinExpression(string Type, List<string> Tables2, List<string> Tables1, List<string> ColumnRelation)
        {
            var joinExp = string.Empty;

            if (string.IsNullOrWhiteSpace(Type))
                return joinExp;

            var valuesExpresion = new List<string>();
            Tables2.ForEach(x => valuesExpresion.Add("\r\n {0} JOIN " + x + " " +
                                   "ON " + Tables1[Tables2.IndexOf(x)] + "." + ColumnRelation[Tables2.IndexOf(x)]
                                   + " = " + x + "." + ColumnRelation[Tables2.IndexOf(x)]));

            var Exp = string.Join(" ", valuesExpresion);
            joinExp = string.Format(Exp, Type.ToUpper());

            return joinExp;
        }
        #endregion

        #region ACTIONS
        //Get List ---- Sql
        public (DataTable, string) GetList(string Sql, string FromTo)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {
                Disconnect();
                Connect();
                SqlCommand cmd1 = new SqlCommand(Sql, connectionStr);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                return (null, "Error al Cargar Data, Metodo GetList(), desde el Metodo " + FromTo + " \n" + ex.Message.ToString());
            }
            Disconnect();
            return (dt, "Completado con exito");
        }

        //Get One ---- Sql
        public (SqlDataReader, string) GetOne(string Sql, string FromTo)
        {
            SqlCommand cmd1;
            try
            {
                Disconnect();
                Connect();
                cmd1 = new SqlCommand(Sql, connectionStr);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    return (dr, "Completado con exito");
                }

                return (null, "No se Encontró Data, Metodo GetOne(), desde el Metodo " + FromTo);
            }
            catch (Exception ex)
            {
                return (null, "Error al Cargar Data, Metodo GetOne() , desde el Metodo " + FromTo + " \n" + ex.Message.ToString());
            }
        }

        //Crud Action ---- Sql
        public (bool, string) CrudAction(string Sql, string FromTo)
        {
            Disconnect();
            try
            {
                using (SqlCommand cmd = new SqlCommand(Sql, connectionStr))
                {
                    Connect();
                    cmd.ExecuteNonQuery();
                    Disconnect();
                }

                return (true, "Completado con exito");
            }
            catch (Exception ex)
            {
                return (false, "Error al realizar la action, Metodo CrudAction() , desde el Metodo " + FromTo + "\n" + ex.Message.ToString());
            }
        }
        #endregion

        public List<string> GetObjectKeys<T>(T input, string tablename = null)
        {
            var propertiesName = new List<string>();
            foreach (PropertyInfo p in input.GetType().GetProperties())
            {
                string propertyName = string.Empty;
                if (!string.IsNullOrEmpty(tablename))
                    propertyName = tablename + "." + p.Name;
                else
                    propertyName = p.Name;

                propertiesName.Add(propertyName);
            }

            return propertiesName;
        }
    }
}
