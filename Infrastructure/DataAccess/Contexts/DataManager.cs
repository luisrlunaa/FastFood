using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace FastFood.Infrastructure.DataAccess.Contexts
{
    public class DataManager
    {
        public (SqlConnection, string) GetConection()
        {
            try
            {
                var conn = new SqlConnection("Data Source=.;Initial Catalog=FastFoodDB; Integrated Security=true");
                return (conn, "Completado con exito");
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return (new SqlConnection(), "Error No se ha encontrado Conexion, Metodo GetConection()");
            }
        }

        public void Conectar()
        {
            var (conexion, message) = GetConection();
            if (message.Contains("Error"))
                MessageBox.Show(message);

            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
        }

        public void Desconectar()
        {
            var (conexion, message) = GetConection();
            if (message.Contains("Error"))
                MessageBox.Show(message);

            if (conexion.State == ConnectionState.Open)
                conexion.Close();
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
                + (string.IsNullOrWhiteSpace(Top) ? "" : Top)
                + (ColumnsName.Count == 0 ? "" : string.Join(",", ColumnsName))
                + " FROM "
                + TableName + " "
                + (string.IsNullOrWhiteSpace(JoinExp) ? "" : JoinExp) //INNER JOIN Table2 ON Table1.ColumnName = Table2.ColumnName)
                + (string.IsNullOrWhiteSpace(WhereExpresion) ? "" : WhereExpresion.ToLower().Contains("where") ? WhereExpresion : "") //WHERE ColumnName1 = 'value' OR ColumnName2 = 'value'
                + (string.IsNullOrWhiteSpace(GroupBy) ? "" : "GROUP BY  " + GroupBy) //GROUP BY ColumnName
                + (string.IsNullOrWhiteSpace(Having) ? "" : "HAVING  " + Having) //HAVING COUNT(ColumnName) > 5
                + (string.IsNullOrWhiteSpace(OrderBy) ? "" : "ORDER BY  " + OrderBy); //ORDER BY ColumnName  ---DESC

            return expression;
        }

        //Update ---- TableName, List ColumnsName, List ParameterValue, ConditionExpresion
        public string UpdateExpression(string TableName, List<string> ColumnsName, List<string> ParameterValue, string ConditionExpresion)
        {
            if (string.IsNullOrWhiteSpace(TableName))
                return "Nombre de tabla requerido. Metodo UpdateExpression()";

            if (string.IsNullOrWhiteSpace(ConditionExpresion))
                return "Condicional requerida. Metodo UpdateExpression()";

            if (!ConditionExpresion.ToLower().Contains("where"))
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
                ConditionExpresion;

            return expression;
        }

        //Delete ---- TableName, List ColumnsName, List ParameterValue, ConditionExpresion
        public string DeleteExpression(string TableName, string ConditionExpresion)
        {
            if (string.IsNullOrWhiteSpace(TableName))
                return "Nombre de tabla requerido. Metodo DeleteExpression()";

            if (string.IsNullOrWhiteSpace(ConditionExpresion))
                return "Condicional requerida. Metodo DeleteExpression()";

            if (!ConditionExpresion.ToLower().Contains("where"))
                return "Condicional debe contener la palabra Where. Metodo DeleteExpression()";

            var expression =
                "DELETE "
                + TableName + " "
                + ConditionExpresion;

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
        public (DataTable, string) GetList(string Sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {
                var (conexion, message) = GetConection();
                if (message.Contains("Error"))
                    MessageBox.Show(message);

                Conectar();
                SqlCommand cmd1 = new SqlCommand(Sql, conexion);
                da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                return (null, "Error al Cargar Data, Metodo GetListado() \n" + ex.Message.ToString());
            }
            Desconectar();
            return (dt, "Completado con exito");
        }

        //Get One ---- Sql
        public (SqlDataReader, string) GetOne(string Sql)
        {
            SqlCommand cmd1;
            try
            {
                var (conexion, message) = GetConection();
                if (message.Contains("Error"))
                    MessageBox.Show(message);

                Conectar();
                cmd1 = new SqlCommand(Sql, conexion);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    Desconectar();
                    return (dr, "Completado con exito");
                }

                Desconectar();
                return (null, "No se Encontró Data, Metodo GetOne()");
            }
            catch (Exception ex)
            {
                return (null, "Error al Cargar Data, Metodo GetOne() \n" + ex.Message.ToString());
            }
        }

        //Crud Action ---- Sql
        public (bool, string) CrudAction(string Sql)
        {
            try
            {
                var (conexion, message) = GetConection();
                if (message.Contains("Error"))
                    MessageBox.Show(message);

                using (SqlCommand cmd = new SqlCommand(Sql, conexion))
                {
                    Conectar();
                    cmd.ExecuteNonQuery();
                    Desconectar();
                }

                return (true, "Completado con exito");
            }
            catch (Exception ex)
            {
                return (false, "Error al realizar la action, Metodo CrudAction() \n" + ex.Message.ToString());
            }
        }
        #endregion

        public List<string> GetObjectKeys<T>(T input)
        {
            var propertiesName = new List<string>();
            foreach (PropertyInfo p in input.GetType().GetProperties())
            {
                string propertyName = p.Name;
                propertiesName.Add(propertyName);
            }

            return propertiesName;
        }
    }
}
