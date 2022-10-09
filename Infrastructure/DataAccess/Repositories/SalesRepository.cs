using FastFood.Infrastructure.DataAccess.Contexts;
using FastFood.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FastFood.Infrastructure.DataAccess.Repositories
{
    public class SalesRepository
    {
        DataManager Data = new DataManager();
        public (List<Sales>, string) GetSales()
        {
            var SalesList = new List<Sales>();
            try
            {
                var classKeys = Data.GetObjectKeys(new Sales());
                var sql = Data.SelectExpression("Sales", classKeys);
                var (dtPC, message) = Data.GetList(sql, "SalesRepository.GetSales");
                if (dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (SalesList, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    Sales s = new Sales();
                    s.IdSale = reader["IdSale"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdSale"]);
                    s.IdEmployee = reader["IdEmployee"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdEmployee"]);
                    s.ClientName = reader["ClientName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ClientName"]);
                    s.ClientRnc = reader["ClientRnc"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ClientRnc"]);
                    s.Address = reader["Address"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Address"]);
                    s.SalesCheckType = reader["SalesCheckType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SalesCheckType"]);
                    s.DocumentType = reader["DocumentType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["DocumentType"]);
                    s.NroComprobante = reader["NroComprobante"] == DBNull.Value ? string.Empty : Convert.ToString(reader["NroComprobante"]);
                    s.DeliveryName = reader["DeliveryName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["DeliveryName"]);
                    s.DeliveryAmount = reader["DeliveryAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DeliveryAmount"]);
                    s.Total = reader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Total"]);
                    s.Remaining = reader["Remaining"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Remaining"]);
                    s.DateIn = reader["DateIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateIn"]);

                    SalesList.Add(s);
                }

                return (SalesList, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (SalesList, "Error al Cargar Data, Metodo SalesRepository.GetSales \n" + ex.Message.ToString());
            }
        }

        public (Sales, string) GetSaleById(int id)
        {
            var s = new Sales();
            try
            {
                if (id == 0)
                    return (s, "Error Input Invalido, Metodo SalesRepository.GetSaleById");

                var classKeys = Data.GetObjectKeys(new Sales());
                var sql = Data.SelectExpression("Sales", classKeys, WhereExpresion: "WHERE IdSale = " + id);
                var (dr, message1) = Data.GetOne(sql, "SalesRepository.GetSaleById");
                if (dr is null)
                    return (s, message1);

                s.IdSale = dr.GetInt32(dr.GetOrdinal("IdSale"));
                s.IdEmployee = dr.GetInt32(dr.GetOrdinal("IdEmployee"));
                s.ClientName = dr.GetString(dr.GetOrdinal("ClientName"));
                s.ClientRnc = dr.GetString(dr.GetOrdinal("ClientRnc"));
                s.Address = dr.GetString(dr.GetOrdinal("Address"));
                s.SalesCheckType = dr.GetString(dr.GetOrdinal("SalesCheckType"));
                s.DocumentType = dr.GetString(dr.GetOrdinal("DocumentType"));
                s.NroComprobante = dr.GetString(dr.GetOrdinal("NroComprobante"));
                s.DeliveryName = dr.GetString(dr.GetOrdinal("DeliveryName"));
                s.DeliveryAmount = dr.GetDecimal(dr.GetOrdinal("DeliveryAmount"));
                s.Total = dr.GetDecimal(dr.GetOrdinal("Total"));
                s.Remaining = dr.GetDecimal(dr.GetOrdinal("Remaining"));
                s.DateIn = dr.GetDateTime(dr.GetOrdinal("DateIn"));

                return (s, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (s, "Error al Cargar Data, Metodo SalesRepository.GetSaleById \n" + ex.Message.ToString());
            }
        }

        public (List<Sales>, string) GetSalesBySalesCheckType(string type)
        {
            var SalesList = new List<Sales>();
            try
            {
                if (string.IsNullOrWhiteSpace(type))
                    return (SalesList, "Error Input Invalido, Metodo SalesRepository.GetSalesBySalesCheckType");

                var classKeys = Data.GetObjectKeys(new Sales());
                var sql = Data.SelectExpression("Sales", classKeys, WhereExpresion: " WHERE SalesCheckType = '" + type + "'");
                var (dtPC, message) = Data.GetList(sql, "SalesRepository.GetSalesBySalesCheckType");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (SalesList, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    Sales s = new Sales();
                    s.IdSale = reader["IdSale"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdSale"]);
                    s.IdEmployee = reader["IdEmployee"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdEmployee"]);
                    s.ClientName = reader["ClientName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ClientName"]);
                    s.ClientRnc = reader["ClientRnc"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ClientRnc"]);
                    s.Address = reader["Address"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Address"]);
                    s.SalesCheckType = reader["SalesCheckType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SalesCheckType"]);
                    s.DocumentType = reader["DocumentType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["DocumentType"]);
                    s.NroComprobante = reader["NroComprobante"] == DBNull.Value ? string.Empty : Convert.ToString(reader["NroComprobante"]);
                    s.DeliveryName = reader["DeliveryName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["DeliveryName"]);
                    s.DeliveryAmount = reader["DeliveryAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DeliveryAmount"]);
                    s.Total = reader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Total"]);
                    s.Remaining = reader["Remaining"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Remaining"]);
                    s.DateIn = reader["DateIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateIn"]);

                    SalesList.Add(s);
                }

                return (SalesList, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (SalesList, "Error al Cargar Data, Metodo SalesRepository.GetSalesBySalesCheckType \n" + ex.Message.ToString());
            }
        }

        public (List<Sales>, string) GetSalesByDeliveryName(string delivery, DateTime dateFrom, DateTime dateTo)
        {
            var SalesList = new List<Sales>();
            try
            {
                if (dateFrom == DateTime.MinValue || dateTo == DateTime.MinValue || string.IsNullOrWhiteSpace(delivery))
                    return (SalesList, "Error Input Invalido debe seleccionar la fecha en la que desea buscar, Metodo SalesRepository.GetSaleDetailsByDate");

                var isSameDate = false;
                if (dateTo == dateFrom)
                    isSameDate = true;

                var classKeys = Data.GetObjectKeys(new Sales());
                var sql = Data.SelectExpression("Sales", classKeys,
                    WhereExpresion:
                    isSameDate
                    ? " WHERE DateIn = '" + dateFrom.ToString("MM/dd/yyyy") + "' AND DeliveryName = '" + delivery + "'"
                    : " WHERE DateIn BETWEEN '" + dateFrom.ToString("MM/dd/yyyy") + "' AND '" + dateTo.ToString("MM/dd/yyyy") + "' AND DeliveryName = '" + delivery + "'");
                var (dtPC, message) = Data.GetList(sql, "SalesRepository.GetSalesByDeliveryName");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (SalesList, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    Sales s = new Sales();
                    s.IdSale = reader["IdSale"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdSale"]);
                    s.IdEmployee = reader["IdEmployee"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdEmployee"]);
                    s.ClientName = reader["ClientName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ClientName"]);
                    s.ClientRnc = reader["ClientRnc"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ClientRnc"]);
                    s.Address = reader["Address"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Address"]);
                    s.SalesCheckType = reader["SalesCheckType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SalesCheckType"]);
                    s.DocumentType = reader["DocumentType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["DocumentType"]);
                    s.NroComprobante = reader["NroComprobante"] == DBNull.Value ? string.Empty : Convert.ToString(reader["NroComprobante"]);
                    s.DeliveryName = reader["DeliveryName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["DeliveryName"]);
                    s.DeliveryAmount = reader["DeliveryAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DeliveryAmount"]);
                    s.Total = reader["Total"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Total"]);
                    s.Remaining = reader["Remaining"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Remaining"]);
                    s.DateIn = reader["DateIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateIn"]);

                    SalesList.Add(s);
                }

                return (SalesList, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (SalesList, "Error al Cargar Data, Metodo SalesRepository.GetSalesByDeliveryName \n" + ex.Message.ToString());
            }
        }

        public (decimal, string) GetAmountByDeliveryName(string delivery, DateTime dateFrom, DateTime dateTo)
        {
            decimal amount = 0;
            try
            {
                if (dateFrom == DateTime.MinValue || dateTo == DateTime.MinValue || string.IsNullOrWhiteSpace(delivery))
                    return (0, "Error Input Invalido debe seleccionar la fecha en la que desea buscar, Metodo SalesRepository.GetSaleDetailsByDate");

                var isSameDate = false;
                if (dateTo == dateFrom)
                    isSameDate = true;

                var sql = Data.SelectExpression("Sales", new List<string>() { "SUM(DeliveryAmount) as DeliveryAmount" },
                    WhereExpresion:
                    isSameDate
                    ? " WHERE DateIn = '" + dateFrom.ToString("MM/dd/yyyy") + "' AND DeliveryName = '" + delivery + "'"
                    : " WHERE DateIn BETWEEN '" + dateFrom.ToString("MM/dd/yyyy") + "' AND '" + dateTo.ToString("MM/dd/yyyy") + "' AND DeliveryName = '" + delivery + "'");

                var (dr, message) = Data.GetOne(sql, "SalesRepository.GetAmountByDeliveryName");
                if (dr is null)
                    return (0, message);

                amount = dr.GetDecimal(dr.GetOrdinal("DeliveryAmount"));
                return (amount, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (amount, "Error al Cargar Data, Metodo SalesRepository.GetAmountByDeliveryName \n" + ex.Message.ToString());
            }
        }

        public (decimal, string) GetAmountByDate(DateTime dateIn)
        {
            decimal amount = 0;
            try
            {
                if (dateIn == DateTime.MinValue)
                    return (0, "Error Input Invalido debe seleccionar la fecha en la que desea buscar, Metodo SalesRepository.GetAmountByDate");

                var sql = Data.SelectExpression("Sales", new List<string>() { "SUM(Total) as Total" }, WhereExpresion: " WHERE DateIn = '" + dateIn.ToString("MM/dd/yyyy")+"'");
                var (dr, message) = Data.GetOne(sql, "SalesRepository.GetAmountByDate");
                if (dr is null)
                    return (0, message);

                if (dr["Total"].GetType() == typeof(DBNull))
                {
                    return (0, message);
                }

                amount = dr.GetDecimal(dr.GetOrdinal("Total"));
                return (amount, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (amount, "Error al Cargar Data, Metodo SalesRepository.GetAmountByDate \n" + ex.Message.ToString());
            }
        }

        public (List<SalesDetails>, string) GetSaleDetails()
        {
            var Sales = new List<SalesDetails>();
            try
            {
                var classKeys = Data.GetObjectKeys(new SalesDetails());
                var sql = Data.SelectExpression("SalesDetails", classKeys);
                var (dtPC, message) = Data.GetList(sql, "SalesRepository.GetSaleDetails");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (Sales, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    SalesDetails s = new SalesDetails();
                    s.IdSale = reader["IdSale"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdSale"]);
                    s.IdDetail = reader["IdDetail"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdDetail"]);
                    s.IdProduct = reader["IdProduct"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdProduct"]);
                    s.ProductName = reader["ProductName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProductName"]);
                    s.Category = reader["Category"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Category"]);
                    s.Quantity = reader["Quantity"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Quantity"]);
                    s.Prices = reader["Prices"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Prices"]);
                    s.Itbis = reader["Itbis"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Itbis"]);
                    s.Subtotal = reader["Subtotal"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Subtotal"]);
                    s.Earnings = reader["Earnings"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Earnings"]);
                    s.DateIn = reader["DateIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateIn"]);

                    Sales.Add(s);
                }

                return (Sales, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Sales, "Error al Cargar Data, Metodo SalesRepository.GetSaleDetails \n" + ex.Message.ToString());
            }
        }

        public (List<SalesDetails>, string) GetSaleDetailsByDate(DateTime dateFrom, DateTime dateTo)
        {
            var salesDetailbyDates = new List<SalesDetails>();
            try
            {
                if (dateFrom == DateTime.MinValue || dateTo == DateTime.MinValue)
                    return (salesDetailbyDates, "Error Input Invalido, Metodo SalesRepository.GetSaleDetailsByDate");

                var isSameDate = false;
                if (dateTo == dateFrom)
                    isSameDate = true;

                var classKeys = Data.GetObjectKeys(new SalesDetails());
                var sql = Data.SelectExpression("SalesDetails", classKeys,
                    WhereExpresion:
                    isSameDate
                    ? " WHERE DateIn = '" + dateFrom.ToString("MM/dd/yyyy") + "'"
                    : " WHERE DateIn BETWEEN '" + dateFrom.ToString("MM/dd/yyyy") + "' AND '" + dateTo.ToString("MM/dd/yyyy") + "'");

                var (dtPC, message) = Data.GetList(sql, "SalesRepository.GetSaleDetailsByDate");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (salesDetailbyDates, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    SalesDetails s = new SalesDetails();
                    s.IdSale = reader["IdSale"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdSale"]);
                    s.IdDetail = reader["IdDetail"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdDetail"]);
                    s.IdProduct = reader["IdProduct"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdProduct"]);
                    s.ProductName = reader["ProductName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProductName"]);
                    s.Category = reader["Category"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Category"]);
                    s.Quantity = reader["Quantity"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Quantity"]);
                    s.Prices = reader["Prices"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Prices"]);
                    s.Itbis = reader["Itbis"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Itbis"]);
                    s.Subtotal = reader["Subtotal"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Subtotal"]);
                    s.Earnings = reader["Earnings"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Earnings"]);
                    s.DateIn = reader["DateIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateIn"]);

                    salesDetailbyDates.Add(s);
                }

                return (salesDetailbyDates, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (salesDetailbyDates, "Error al Cargar Data, Metodo SalesRepository.GetSaleDetailsByDate \n" + ex.Message.ToString());
            }
        }

        public (List<SalesDetails>, string) GetSaleDetailsByDescriptionOrClientName(string description)
        {
            var salesDetailbyDates = new List<SalesDetails>();
            try
            {
                if (string.IsNullOrWhiteSpace(description))
                    return (salesDetailbyDates, "Error Input Invalido, Metodo SalesRepository.GetSaleDetailsByDescription");

                var join = Data.JoinExpression("INNER", new List<string>() { "Sales" }, new List<string>() { "SalesDetails" }, new List<string>() { "IdSale" });
                var classKeys = Data.GetObjectKeys(new SalesDetails(), "SalesDetails").Where(x => x != "Id").ToList();
                var sql = Data.SelectExpression("SalesDetails", classKeys, JoinExp: join,
                    WhereExpresion: " WHERE ProductName like '%" + description + "%' OR Sales.ClientName like '%" + description + "%'");

                var (dtPC, message) = Data.GetList(sql, "SalesRepository.GetSaleDetailsByDescription");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (salesDetailbyDates, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    SalesDetails s = new SalesDetails();
                    s.IdSale = reader["IdSale"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdSale"]);
                    s.IdDetail = reader["IdDetail"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdDetail"]);
                    s.IdProduct = reader["IdProduct"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdProduct"]);
                    s.ProductName = reader["ProductName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProductName"]);
                    s.Category = reader["Category"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Category"]);
                    s.Quantity = reader["Quantity"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Quantity"]);
                    s.Prices = reader["Prices"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Prices"]);
                    s.Itbis = reader["Itbis"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Itbis"]);
                    s.Subtotal = reader["Subtotal"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Subtotal"]);
                    s.Earnings = reader["Earnings"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Earnings"]);
                    s.DateIn = reader["DateIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateIn"]);

                    salesDetailbyDates.Add(s);
                }

                return (salesDetailbyDates, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (salesDetailbyDates, "Error al Cargar Data, Metodo SalesRepository.GetSaleDetailsByDescription \n" + ex.Message.ToString());
            }
        }

        public (List<SalesDetails>, string) GetSaleDetailsByDeliveryName(string delivery, DateTime dateFrom, DateTime dateTo)
        {
            var SalesList = new List<SalesDetails>();
            try
            {
                if (dateFrom == DateTime.MinValue || dateTo == DateTime.MinValue || string.IsNullOrWhiteSpace(delivery))
                    return (SalesList, "Error Input Invalido debe seleccionar la fecha en la que desea buscar, Metodo SalesRepository.GetSaleDetailsByDate");

                var isSameDate = false;
                if (dateTo == dateFrom)
                    isSameDate = true;

                var join = Data.JoinExpression("INNER", new List<string>() { "Sales" }, new List<string>() { "SalesDetails" }, new List<string>() { "IdSale" });
                var classKeys = Data.GetObjectKeys(new SalesDetails(), "SalesDetails");
                var sql = Data.SelectExpression("SalesDetails", classKeys, JoinExp: join,
                    WhereExpresion:
                    isSameDate
                    ? " WHERE SalesDetails.DateIn = '" + dateFrom.ToString("MM/dd/yyyy") + "' AND Sales.DeliveryName = '" + delivery + "'"
                    : " WHERE SalesDetails.DateIn BETWEEN '" + dateFrom.ToString("MM/dd/yyyy") + "' AND '" + dateTo.ToString("MM/dd/yyyy") + "' AND Sales.DeliveryName = '" + delivery + "'");
                var (dtPC, message) = Data.GetList(sql, "SalesRepository.GetSaleDetailsByDeliveryName");
                if (dtPC is null || dtPC.Rows is null || dtPC.Rows.Count == 0)
                    return (SalesList, message);

                foreach (DataRow reader in dtPC.Rows)
                {
                    SalesDetails s = new SalesDetails();
                    s.IdSale = reader["IdSale"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdSale"]);
                    s.IdDetail = reader["IdDetail"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdDetail"]);
                    s.IdProduct = reader["IdProduct"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdProduct"]);
                    s.ProductName = reader["ProductName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProductName"]);
                    s.Category = reader["Category"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Category"]);
                    s.Quantity = reader["Quantity"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Quantity"]);
                    s.Prices = reader["Prices"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Prices"]);
                    s.Itbis = reader["Itbis"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Itbis"]);
                    s.Subtotal = reader["Subtotal"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Subtotal"]);
                    s.Earnings = reader["Earnings"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Earnings"]);
                    s.DateIn = reader["DateIn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DateIn"]);

                    SalesList.Add(s);
                }

                return (SalesList, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (SalesList, "Error al Cargar Data, Metodo SalesRepository.GetSalesByDeliveryName \n" + ex.Message.ToString());
            }
        }

        public (decimal, string) GetEarningsToSaleByDate(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                if (dateFrom == DateTime.MinValue || dateTo == DateTime.MinValue)
                    return (0, "Error Input Invalido, Metodo SalesRepository.GetEarningsToSaleByDate");

                var isSameDate = false;
                if (dateTo == dateFrom)
                    isSameDate = true;

                decimal amount = 0;
                var sql = Data.SelectExpression("SalesDetails", new List<string>() { "SUM(Earnings)" }, WhereExpresion: isSameDate
                    ? " WHERE DateIn = convert(" + dateFrom + ", CONVERT(varchar(10), @fecha, 103), 103)"
                    : " WHERE DateIn BETWEEN convert(" + dateFrom + ", CONVERT(varchar(10), @fecha, 103),103) AND convert(" + dateTo + ", CONVERT(varchar(10), @fecha1, 103),103)");

                var (dr, message) = Data.GetOne(sql, "SalesRepository.GetEarningsToSaleByDate");
                if (dr is null)
                    return (0, message);

                amount = dr.GetDecimal(dr.GetOrdinal("Earnings"));

                return (amount, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (0, "Error al Cargar Data, Metodo SalesRepository.GetEarningsToSaleByDate \n" + ex.Message.ToString());
            }
        }

        public (bool, string) AddSale(Sales sales)
        {
            try
            {
                if (sales == null || sales.DateIn == DateTime.MinValue)
                    return (false, "Error Input Invalido, Metodo SalesRepository.AddSale");

                var parameters = new List<string> { sales.IdEmployee.ToString(), "'"+sales.ClientName+"'", "'"+sales.ClientRnc+"'", "'"+sales.Address+"'", "'"+sales.SalesCheckType+"'", "'"+sales.DocumentType+"'",
                "'"+sales.NroComprobante+"'", string.IsNullOrWhiteSpace(sales.DeliveryName) ? "'"+ string.Empty +"'" : "'" +sales.DeliveryName+"'", sales.DeliveryAmount.ToString(),
                sales.Total.ToString(), sales.Remaining.ToString(), "'"+sales.DateIn.Value.ToShortDateString()+"'"};

                var classKeys = Data.GetObjectKeys(new Sales()).Where(x => x != "IdSale").ToList();
                var sql = Data.InsertExpression("Sales", classKeys, parameters);
                var (response, message) = Data.CrudAction(sql, "SalesRepository.AddSale");
                if (!response)
                    return (response, message);

                return (response, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo SalesRepository.AddSale \n" + ex.Message.ToString());
            }
        }

        public (bool, string) AddSaleDetails(List<SalesDetails> sales)
        {
            try
            {
                if (sales == null || !sales.Any())
                    return (false, "Error Input Invalido, Metodo SalesRepository.AddSaleDetails");

                foreach (var item in sales)
                {
                    var parameters = new List<string> { item.IdSale.ToString(), item.IdDetail.ToString(), item.IdProduct.ToString(), "'"+item.ProductName+"'",
                    "'"+item.Category+"'",item.Quantity.ToString(), item.Prices.ToString(), item.Itbis.ToString(), item.Subtotal.ToString(), item.Earnings.ToString(),
                    "'"+item.DateIn.Value.ToShortDateString()+"'"};

                    var classKeys = Data.GetObjectKeys(new SalesDetails()).Where(x => x != "Id").ToList();
                    var sql = Data.InsertExpression("SalesDetails", classKeys, parameters);
                    var (response, message) = Data.CrudAction(sql, "SalesRepository.AddSaleDetails");
                    if (!response)
                        return (response, message);
                }

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo SalesRepository.AddSaleDetails \n" + ex.Message.ToString());
            }
        }

        public (bool, string) UpdateSales(Sales sales)
        {
            try
            {
                if (sales == null)
                    return (false, "Error Input Invalido, Metodo SalesRepository.UpdateSales");

                var parameters = new List<string> { sales.IdEmployee.ToString(), "'"+sales.ClientName+"'", "'"+sales.Address+"'", "'"+sales.SalesCheckType+"'", "'"+sales.DocumentType+"'",
                "'"+sales.NroComprobante+"'", string.IsNullOrWhiteSpace(sales.DeliveryName) ? "'"+ string.Empty +"'" : "'" + sales.DeliveryName+"'", sales.DeliveryAmount.ToString(),
                sales.Total.ToString(), sales.Remaining.ToString(), "'"+sales.DateIn.Value.ToShortDateString()+"'"};

                var classKeys = Data.GetObjectKeys(new Sales()).Where(x => x != "IdSale").ToList();
                var sql = Data.UpdateExpression("Sales", classKeys, parameters, "WHERE IdSale = " + sales.IdSale);
                var (response, message) = Data.CrudAction(sql, "SalesRepository.UpdateSales");
                if (!response)
                    return (response, message);

                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo SalesRepository.UpdateSales \n" + ex.Message.ToString());
            }
        }

        public (bool, string) DeleteSales(Sales sales)
        {
            try
            {
                if (sales == null)
                    return (false, "Error Input Invalido, Metodo SalesRepository.DeleteSales");

                var sql = Data.DeleteExpression("Sales", "WHERE IdSale = " + sales.IdSale);
                var (response, message) = Data.CrudAction(sql, "SalesRepository.DeleteSales");
                if (!response)
                    return (response, message);

                return (response, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo SalesRepository.DeleteSales \n" + ex.Message.ToString());
            }
        }

        public (int, string) GetNextSalesId()
        {
            try
            {
                var classKeys = Data.GetObjectKeys(new Sales());
                var sql = Data.SelectExpression("Sales", new List<string>() { "IdSale" }, Top: 1.ToString(), OrderBy: "IdSale DESC");
                var (dr, message) = Data.GetOne(sql, "SalesRepository.GetNextSalesId");
                if (dr is null)
                    return (0, message);

                int id = dr.GetInt32(dr.GetOrdinal("IdSale")) + 1;
                return (id > 0 ? id : 1, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (0, "Error al Cargar Data, Metodo SalesRepository.GetNextSalesId \n" + ex.Message.ToString());
            }
        }
    }
}
