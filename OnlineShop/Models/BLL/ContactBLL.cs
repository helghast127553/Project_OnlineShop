using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models.DAO;

namespace OnlineShop.Models.BLL
{
    public static class ContactBLL
    {
        public static Contact GetActiveContact()
        {
            return ContactDAO.GetActiveContact();
        }

       
    }
}