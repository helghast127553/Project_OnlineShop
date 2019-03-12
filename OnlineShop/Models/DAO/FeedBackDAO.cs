using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DAO
{
    public static class FeedBackDAO
    {
        public static int InsertFeedBack(FeedBack feedback)
        {
            var result = 0;
            using (var db = new OnlineShopEntities())
            {
                db.FeedBacks.Add(feedback);
                result = db.SaveChanges();
                return result;
            }
        }
    }
}