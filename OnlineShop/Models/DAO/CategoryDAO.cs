using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DAO
{
    public static class CategoryDAO
    {
        public static int InsertCategory(Category category)
        {
            using (var db = new OnlineShopEntities())
            {
                db.Categories.Add(category);
                var result = db.SaveChanges();
                return result;
            }
        }
        public static List<Category> GetAllCategory()
        {
            using (var db = new OnlineShopEntities())
            {
                var categories = db.Categories.Where(x => x.Status == true).ToList();
                return categories;
            }
        }
    }
}