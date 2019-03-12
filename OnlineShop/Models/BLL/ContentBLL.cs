using OnlineShop.Models.DAO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.BLL
{
    public static class ContentBLL
    {
        public static List<Content> GetAllContent()
        {
            return ContentDAO.GetAllContent();
        }

        public static Content GetContentByID(int ID)
        {
            return ContentDAO.GetContentByID(ID);
        }

        public static int InsertContent(Content content)
        {
            return ContentDAO.InsertContent(content);
        }

        public static int UpdateContent(Content content)
        {
            return ContentDAO.UpdateContent(content);
        }

        public static List<Content> ListAllPaging(int page, int pageSize)
        {
            return ContentDAO.ListAllPaging(page, pageSize);
        }

        public static List<Content> ListAllByTag(string tag, int page, int pageSize)
        {
            return ContentDAO.ListAllByTag(tag, page, pageSize);
        }
    }
}