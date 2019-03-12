using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DAO
{
    public static class ProductCategoryDAO
    {
        public static List<ProductCategory> GetAllProductCategory()
        {
            using (var db = new OnlineShopEntities())
            {
                var productCategories = db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
                return productCategories;
            }
        }

        public static ProductCategory GetProductDetail(int ID)
        {
            using (var db = new OnlineShopEntities())
            {
                var productCategory = db.ProductCategories.Find(ID);
                return productCategory;
            }
        }

       
    }
}