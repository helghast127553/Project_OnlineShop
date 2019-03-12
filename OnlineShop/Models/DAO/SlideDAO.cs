using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DAO
{
    public static class SlideDAO
    {
        public static List<Slide> GetAllSlide()
        {
            using (var db = new OnlineShopEntities())
            {
                var slides = db.Slides.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
                return slides;
            }
        }
    }
}