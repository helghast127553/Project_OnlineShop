using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models.EF;

namespace OnlineShop.Models.DAO
{
    public static class ContactDAO
    {
        public static Contact GetActiveContact()
        {
            using (var db = new OnlineShopEntities())
            {
                var contact = db.Contacts.SingleOrDefault(x => x.Status == true);
                return contact;
            }
        }
    }
}