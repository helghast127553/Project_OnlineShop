using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class OrderDetailModel
    {
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}