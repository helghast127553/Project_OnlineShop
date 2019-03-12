using OnlineShop.Models.DAO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.BLL
{
    public static class FooterBLL
    {
        public static Footer GetFooter()
        {
            return FooterDAO.GetFooter();
        }
    }
}