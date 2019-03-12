using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DAO
{
    public static class TagDAO
    {
        public static List<Tag> GetAllTag(int contentID)
        {
            var db = new OnlineShopEntities();
            var tag = from a in db.Tags
                      join b in db.ContentTags
                      on a.ID equals b.TagID
                      where b.ContentID == contentID
                      select new Tag
                      {
                          ID = b.TagID,
                          Name = a.Name
                      };
            return tag.ToList();
        }

        public static Tag GetTag(string ID)
        {
            using (var db = new OnlineShopEntities())
            {
                var tag = db.Tags.Find(ID);
                return tag;
            }
        }
    }
}