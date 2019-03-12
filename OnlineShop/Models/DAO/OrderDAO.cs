using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DAO
{
    public static class OrderDAO
    {
        public static int InsertOrder(Order order)
        {
            var result = 0;
            using (var db = new OnlineShopEntities())
            {
                db.Orders.Add(order);
                result = db.SaveChanges();
                return result;
            }
        }
    }
}