using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.DataAccess.Repositories
{
    public class SalesRepository
    {
        public List<SalesCheck> GetSales()
        {
            var Sales = new List<SalesCheck>();
            return Sales;
        }

        public SalesCheck GetSaleById(int id)
        {
            var Sales = new List<SalesCheck>();
            var sale = Sales.FirstOrDefault(x=>x.IdVenta == id);
            return sale;
        }

        public List<SalesCheck> GetSalesBySalesCheckType(string type)
        {
            var Sales = new List<SalesCheck>();
            return Sales.Where(x=>x.SalesCheckType == type).ToList();
        }

        public List<SalesCheck> GetSalesByDeliveryName(string delivery)
        {
            var Sales = new List<SalesCheck>();
            return Sales.Where(x => x.DeliveryName == delivery).ToList();
        }

        public decimal GetAmountByDeliveryName(string delivery)
        {
            decimal amount = 0;
            var Sales = new List<SalesCheck>();
            var amounts = Sales.Where(x => x.DeliveryName == delivery).ToList().Select(x=>x.DeliveryAmount);
            foreach (var s in amounts)
            {
                if(s.HasValue && s > 0)
                    amount = s.Value + amount;
            }

            return amount;
        }
    }
}
