using OnlineShop.Models.DAO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.BLL
{
    public static class TagBLL
    {
        public static List<Tag> GetAllTag(int contentID)
        {
            return TagDAO.GetAllTag(contentID);
        }

        public static Tag GetTag(string ID)
        {
            return TagDAO.GetTag(ID);
        }
    }
}