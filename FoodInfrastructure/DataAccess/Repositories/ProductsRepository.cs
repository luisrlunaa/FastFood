using FastFood.Infrastructure.DataAccess.Contexts;
using FastFood.Infrastructure.Utils;
using FastFood.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FastFood.Infrastructure.DataAccess.Repositories
{
    public class ProductsRepository
    {
        DataManager Data = new DataManager();
        public (List<Product>, string) GetProducts()
        {
            var Products = new List<Product>();
            try
            {
                var classKeys = Data.GetObjectKeys(new Product());
                var sql = Data.SelectExpression("Product", classKeys);
                var (dtPC, message) = Data.GetList(sql, "ProductsRepository.GetProducts");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (Products, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    var s = new Product();
                    s.ProductId = reader["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ProductId"]);
                    s.Name = reader["Name"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Name"]);
                    s.Description = reader["Description"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Description"]);
                    s.Category = reader["Category"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Category"]);
                    s.Type = reader["Type"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Type"]);
                    s.Stock = reader["Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Stock"]);
                    s.Itbis = reader["Itbis"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Itbis"]);
                    s.SalesPrice = reader["SalesPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["SalesPrice"]);
                    s.BayPrice = reader["BayPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["BayPrice"]);
                    s.Created = reader["Created"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["Created"]);
                    s.Updated = reader["Updated"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["Updated"]);
                    s.ImageName = reader["ImageName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ImageName"]);

                    s = AnyNullValueHelper.AnyNullValue<Product>(s);
                    Products.Add(s);
                }

                return (Products, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Products, "Error al Cargar Data, Metodo ProductsRepository.GetProducts \n" + ex.Message.ToString());
            }
        }

        public (Product, string) GetProductById(int id)
        {
            var product = new Product();
            try
            {
                if (id == 0)
                    return (product, "Error Input Invalido, Metodo ProductsRepository.GetProductById");

                var classKeys = Data.GetObjectKeys(new Product());
                var sql = Data.SelectExpression("Product", classKeys, WhereExpresion: "WHERE ProductId = " + id);
                var (dr, message1) = Data.GetOne(sql, "ProductsRepository.GetProductById");
                if (dr is null)
                    return (product, message1);

                product.ProductId = dr.GetInt32(dr.GetOrdinal("ProductId"));
                product.Name = dr.GetString(dr.GetOrdinal("Name"));
                product.Description = dr.GetString(dr.GetOrdinal("Description"));
                product.Category = dr.GetString(dr.GetOrdinal("Category"));
                product.Type = dr.GetString(dr.GetOrdinal("Type"));
                product.Stock = dr.GetDecimal(dr.GetOrdinal("Stock"));
                product.Itbis = dr.GetDecimal(dr.GetOrdinal("Itbis"));
                product.SalesPrice = dr.GetDecimal(dr.GetOrdinal("SalesPrice"));
                product.BayPrice = dr.GetDecimal(dr.GetOrdinal("BayPrice"));
                product.Created = dr.GetDateTime(dr.GetOrdinal("Created"));
                product.Updated = dr.GetDateTime(dr.GetOrdinal("Updated"));
                product.ImageName = dr.GetString(dr.GetOrdinal("ImageName"));

                product = AnyNullValueHelper.AnyNullValue<Product>(product);
                return (product, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (product, "Error al Cargar Data, Metodo ProductsRepository.GetProductById \n" + ex.Message.ToString());
            }
        }

        public (List<Product>, string) GetProductByCategory(string category)
        {
            var Products = new List<Product>();
            try
            {
                if (string.IsNullOrWhiteSpace(category))
                    return (Products, "Error Input Invalido, Metodo ProductsRepository.GetProductByCategory");

                var classKeys = Data.GetObjectKeys(new Product());
                var sql = Data.SelectExpression("Product", classKeys, WhereExpresion: " WHERE Category = '" + category + "'");
                var (dtPC, message) = Data.GetList(sql, "ProductsRepository.GetProductByCategory");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (Products, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    var s = new Product();
                    s.ProductId = reader["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ProductId"]);
                    s.Name = reader["Name"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Name"]);
                    s.Description = reader["Description"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Description"]);
                    s.Category = reader["Category"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Category"]);
                    s.Type = reader["Type"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Type"]);
                    s.Stock = reader["Stock"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Stock"]);
                    s.Itbis = reader["Itbis"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Itbis"]);
                    s.SalesPrice = reader["SalesPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["SalesPrice"]);
                    s.BayPrice = reader["BayPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["BayPrice"]);
                    s.Created = reader["Created"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["Created"]);
                    s.Updated = reader["Updated"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["Updated"]);
                    s.ImageName = reader["ImageName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ImageName"]);

                    s = AnyNullValueHelper.AnyNullValue<Product>(s);
                    Products.Add(s);
                }

                return (Products, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Products, "Error al Cargar Data, Metodo ProductsRepository.GetProductByCategory \n" + ex.Message.ToString());
            }
        }

        public (bool, string) AddProduct(Product input)
        {
            try
            {
                if (input == null)
                    return (false, "Error Input Invalido, Metodo ProductsRepository.AddProduct");

                input = AnyNullValueHelper.AnyNullValue<Product>(input);
                var parameters = new List<string> { "'" +input.Name+"'", "'"+input.Description+"'", "'"+input.Category+"'", "'"+input.Type+"'",
                    input.Stock.ToString(), input.Itbis.ToString(), input.SalesPrice.ToString(), input.BayPrice.ToString(),
                    "'"+input.Created.ToShortDateString()+"'", "'"+input.ImageName+"'"};

                var classKeys = Data.GetObjectKeys(new Product()).Where(x => x != "ProductId" && x != "Updated").ToList();
                var sql = Data.InsertExpression("Product", classKeys, parameters);
                var (response, message) = Data.CrudAction(sql, "ProductsRepository.AddProduct");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al procesar Data, Metodo ProductsRepository.AddProduct \n" + ex.Message.ToString());
            }
        }

        public (bool, string) UpdateProduct(Product input)
        {
            try
            {
                if (input == null)
                    return (false, "Error Input Invalido, Metodo ProductsRepository.UpdateProduct");

                input = AnyNullValueHelper.AnyNullValue<Product>(input);
                var parameters = new List<string> { "'" +input.Name+"'", "'"+input.Description+"'", "'"+input.Category+"'", "'"+input.Type+"'",
                    input.Stock.ToString(), input.Itbis.ToString(), input.SalesPrice.ToString(), input.BayPrice.ToString(),
                    "'"+input.Updated.ToShortDateString()+"'", "'"+input.ImageName+"'"};

                var classKeys = Data.GetObjectKeys(new Product()).Where(x => x != "ProductId" && x != "Created").ToList();
                var sql = Data.UpdateExpression("Product", classKeys, parameters, WhereExpresion: "WHERE ProductId = " + input.ProductId);
                var (response, message) = Data.CrudAction(sql, "ProductsRepository.UpdateProduct");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al procesar Data, Metodo ProductsRepository.UpdateProduct \n" + ex.Message.ToString());
            }
        }

        public (bool, string) DeleteProductById(int id, string category)
        {
            try
            {
                if (id == 0 || string.IsNullOrWhiteSpace(category))
                    return (false, "Error Input Invalido, Metodo ProductsRepository.DeleteProductById");

                var sql = Data.DeleteExpression("Product", WhereExpresion: "WHERE ProductId = " + id + " AND Category = " + category);
                var (response, message) = Data.CrudAction(sql, "ProductsRepository.DeleteProductById");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al procesar Data, Metodo ProductsRepository.DeleteProductById \n" + ex.Message.ToString());
            }
        }
    }
}
