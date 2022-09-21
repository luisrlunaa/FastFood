using Models.Entities;
using Models.ViewModels.GenericLists;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.DataAccess.Repositories
{
    public class SalesRepository
    {
        public (List<SalesCheck>, string) GetSales()
        {
            var Sales = new List<SalesCheck>();
            try
            {
                return (Sales, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (Sales, "Error al Cargar Data, Metodo SalesRepository.GetSales \n" + ex.Message.ToString());
            }
        }

        public (SalesCheck, string) GetSaleById(int id)
        {
            var sale = new SalesCheck();
            try
            {
                var (sales, message) = GetSales();
                if (sales != null && sales.Any())
                    return (sale, message);

                sale = sales.FirstOrDefault(x => x.IdVenta == id);
                return (sale, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (sale, "Error al Cargar Data, Metodo SalesRepository.GetSaleById \n" + ex.Message.ToString());
            }
        }

        public (List<SalesCheck>, string) GetSalesBySalesCheckType(string type)
        {
            try
            {
                var (sales, message) = GetSales();
                if (sales != null && sales.Any())
                    return (sales, message);

                return (sales.Where(x => x.SalesCheckType == type).ToList(), "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (new List<SalesCheck>(), "Error al Cargar Data, Metodo SalesRepository.GetSalesBySalesCheckType \n" + ex.Message.ToString());
            }
        }

        public (List<SalesCheck>, string) GetSalesByDeliveryName(string delivery)
        {
            try
            {
                var (sales, message) = GetSales();
                if (sales != null && sales.Any())
                    return (sales, message);

                return (sales.Where(x => x.DeliveryName == delivery).ToList(), "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (new List<SalesCheck>(), "Error al Cargar Data, Metodo SalesRepository.GetSalesByDeliveryName \n" + ex.Message.ToString());
            }
        }

        public (decimal, string) GetAmountByDeliveryName(string delivery)
        {
            decimal amount = 0;
            try
            {
                var (sales, message) = GetSales();
                if (sales != null && sales.Any())
                    return (amount, message);

                var amounts = sales.Where(x => x.DeliveryName == delivery).ToList().Select(x => x.DeliveryAmount);
                foreach (var s in amounts)
                {
                    if (s.HasValue && s > 0)
                        amount = s.Value + amount;
                }

                return (amount, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (amount, "Error al Cargar Data, Metodo SalesRepository.GetAmountByDeliveryName \n" + ex.Message.ToString());
            }
        }

        public (bool, string) AddSale(SalesCheck sales)
        {
            try
            {
                if (sales == null)
                    return (false, "Input Invalido, Metodo SalesRepository.AddSale");

                if (GenericLists.SalesChecks.FirstOrDefault(x => x.IdVenta == sales.IdVenta) != null)
                    return (false, "Elemento existente en la lista Temporal, Metodo SalesRepository.AddSale");

                GenericLists.SalesChecks.Add(sales);
                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo SalesRepository.AddSale \n" + ex.Message.ToString());
            }
        }

        public (bool, string) UpdateSales(SalesCheck sales)
        {
            try
            {
                if (sales == null)
                    return (false, "Input Invalido, Metodo SalesRepository.UpdateSales");

                var old = GenericLists.SalesChecks.FirstOrDefault(x => x.IdVenta == sales.IdVenta);
                if (old is null)
                    return (false, "Elemento no existente en la lista Temporal, Metodo SalesRepository.UpdateSales");

                GenericLists.SalesChecks.Remove(old);
                GenericLists.SalesChecks.Add(sales);
                return (true, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (false, "Error al Cargar Data, Metodo SalesRepository.UpdateSales \n" + ex.Message.ToString());
            }
        }

        public (bool, string) DeleteSales(SalesCheck sales)
        {
            try
            {
                if (sales == null)
                    return (false, "Input Invalido, Metodo SalesRepository.DeleteSales");

                var old = GenericLists.SalesChecks.FirstOrDefault(x => x.IdVenta == sales.IdVenta);
                if (old is null)
                    return (false, "Elemento no existente en la lista Temporal, Metodo SalesRepository.DeleteSales");

                GenericLists.SalesChecks.Remove(old);
                return (true, "Proceso Completado");
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
                var (sales, message) = GetSales();
                if (sales != null && sales.Any())
                    return (0, message);

                return (sales.Count > 0 ? sales.Max(x => x.IdVenta) + 1 : 1, "Proceso Completado");
            }
            catch (Exception ex)
            {
                return (0, "Error al Cargar Data, Metodo SalesRepository.GetNextSalesId \n" + ex.Message.ToString());
            }
        }
    }
}
