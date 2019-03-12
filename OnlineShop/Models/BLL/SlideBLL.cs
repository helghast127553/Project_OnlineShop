using OnlineShop.Models.DAO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.BLL
{
    public static class SlideBLL
    {
        public static List<Slide> GetAllSlide()
        {
            return SlideDAO.GetAllSlide();
        }
    }
}