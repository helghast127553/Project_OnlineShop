using OnlineShop.Models.DAO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.BLL
{
    public static class CategoryBLL
    {
        public static List<Category> GetAllCategory()
        {
            return CategoryDAO.GetAllCategory();
        }

        public static int InsertCategory(Category category)
        {
            return CategoryDAO.InsertCategory(category);
        }
    }
}