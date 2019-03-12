using OnlineShop.Models.DAO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DTO
{
    [Serializable]
    public class CartItem
    {
        public CartItem(int productID, int quantity)
        {
            var product = ProductDAO.GetProductDetail(productID);
            ProductID = productID;
            Name = product.Name;
            Image = product.Image;
            Quantity = quantity;
            Price = product.Price.Value;
        }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }    
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total
        {
            get { return Quantity * Price; }
        }
    }
}