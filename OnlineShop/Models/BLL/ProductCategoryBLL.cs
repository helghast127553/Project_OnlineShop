using OnlineShop.Models.DAO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.BLL
{
    public static class ProductCategoryBLL
    {
        public static List<ProductCategory> GetAllProductCategory()
        {
            return ProductCategoryDAO.GetAllProductCategory();
        }

        public static ProductCategory GetProductDetail(int ID)
        {
            return ProductCategoryDAO.GetProductDetail(ID);
        }
    }
}