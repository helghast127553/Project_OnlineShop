using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models.DAO;

namespace OnlineShop.Models.BLL
{
    public static class FeedBackBLL
    {
        public static int InsertFeedback(FeedBack feedback)
        {
            return FeedBackDAO.InsertFeedBack(feedback);
        }
    }
}