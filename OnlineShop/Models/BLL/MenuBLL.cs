using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models.DAO;

namespace OnlineShop.Models.BLL
{
    public static class MenuBLL
    {
        public static List<Menu> GetMenuByID(int TypeID)
        {
            return MenuDAO.GetMenuByID(TypeID);
        }
    }
}