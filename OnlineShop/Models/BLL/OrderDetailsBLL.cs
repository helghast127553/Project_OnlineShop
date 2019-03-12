using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models.DAO;
using OnlineShop.Models.EF;

namespace OnlineShop.Models.BLL
{
    public static class OrderDetailsBLL
    {
        public static int InsertOrderDetails(OrderDetail orderDetail)
        {
            return OrderDetailsDAO.InsertOrderDetails(orderDetail);
        }

        public static int UpdateOrderDetaiL(OrderDetail orderDetail)
        {
            return OrderDetailsDAO.UpdateOrderDetail(orderDetail);
        }

        public static int DeleteOrderDetail(int ID)
        {
            return OrderDetailsDAO.DeleteOrderDetail(ID);
        }

        public static List<OrderDetail> GetOrderDetails()
        {
            return OrderDetailsDAO.GetOrderDetails();
        }

        public static OrderDetail GetOrderDetail(int ID)
        {
            return OrderDetailsDAO.GetOrderDetail(ID);
        }
    }
}