using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models.EF;

namespace OnlineShop.Models.DAO
{
    public static class OrderDetailsDAO
    {
        public static int InsertOrderDetails(OrderDetail orderDetail)
        {
            using (var db = new OnlineShopEntities())
            {
                db.OrderDetails.Add(orderDetail);
                var result = db.SaveChanges();
                return result;
            }
        }

        public static OrderDetail GetOrderDetail(int ID)
        {
            using (var db = new OnlineShopEntities())
            {
                var orderDetail = db.OrderDetails.Find(ID);
                return orderDetail;
            }
        }

        public static List<OrderDetail> GetOrderDetails()
        {
            using (var db = new OnlineShopEntities())
            {
                var orderDetails = db.OrderDetails.ToList();
                return orderDetails;
            }
        }

        public static int UpdateOrderDetail(OrderDetail orderDetailEntity)
        {
            using (var db = new OnlineShopEntities())
            {
                var orderDetail = db.OrderDetails.Find(orderDetailEntity.ID);
                orderDetail.ProductID = orderDetailEntity.ProductID;
                orderDetail.OrderID = orderDetailEntity.OrderID;
                orderDetail.Quantity = orderDetailEntity.Quantity;
                orderDetail.Price = orderDetail.Price;
                var result = db.SaveChanges();
                return result;
            }
        }

        public static int DeleteOrderDetail(int ID)
        {
            using (var db = new OnlineShopEntities())
            {
                var orderDetail = db.OrderDetails.Find(ID);
                db.OrderDetails.Remove(orderDetail);
                var result = db.SaveChanges();
                return result;
            }
        }
    }
}