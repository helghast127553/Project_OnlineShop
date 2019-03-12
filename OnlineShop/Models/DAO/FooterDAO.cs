using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DAO
{
    public static class FooterDAO
    {
        public static Footer GetFooter()
        {
            using (var db = new OnlineShopEntities())
            {
                var footer = db.Footers.SingleOrDefault(x => x.Status == true);
                return footer;
            }
        }
    }
}