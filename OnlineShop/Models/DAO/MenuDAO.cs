using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DAO
{
    public static class MenuDAO
    {
        public static List<Menu> GetMenuByID(int TypeID)
        {
            using (var db = new OnlineShopEntities())
            {
                var menus = db.Menus.Where(x => (x.TypeID == TypeID) && (x.Status == true) ).OrderBy(x => x.DisplayOrder).ToList();
                return menus;
            }         
        }
    }
}