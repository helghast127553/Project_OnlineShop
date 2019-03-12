using OnlineShop.Common;
using OnlineShop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DAO
{
    public static class ContentDAO
    {
        public static Content GetContentByID(int ID)
        {
            using (var db = new OnlineShopEntities())
            {
                var result = db.Contents.Find(ID);
                return result;
            }
        }

        public static List<Content> GetAllContent()
        {
            using (var db = new OnlineShopEntities())
            {
                var contents = db.Contents.ToList();
                return contents;
            }
        }

        public static int InsertContent(Content content)
        {
            using (var db = new OnlineShopEntities())
            {
                if (string.IsNullOrEmpty(content.MetaTitle))
                {
                    content.MetaTitle = StringHelper.ToUnsignString(content.Name);
                }
                db.Contents.Add(content);
                var result = db.SaveChanges();
                if (!string.IsNullOrEmpty(content.Tags))
                {
                    string[] tags = content.Tags.Split('-').ToArray();
                    for (int i = 0; i < tags.Length; i++)
                    {
                        var tagID = StringHelper.ToUnsignString(tags[i]);
                        var existedTag = CheckTag(tagID);
                        if (!existedTag)
                        {
                            InsertTag(tagID, tags[i]);
                        }
                        InsertContentTag(content.ID, tagID);
                    }
                }
                return result;
            }
        }

        public static int UpdateContent(Content content)
        {
            using (var db = new OnlineShopEntities())
            {
                if (string.IsNullOrEmpty(content.MetaTitle))
                {
                    content.MetaTitle = StringHelper.ToUnsignString(content.Name);
                }
                var contentUpdate = db.Contents.Find(content.ID);
                contentUpdate.Name = content.Name;
                contentUpdate.MetaTitle = content.MetaTitle;
                contentUpdate.Description = content.Description;
                contentUpdate.Image = content.Image;
                contentUpdate.CategoryID = content.CategoryID;
                contentUpdate.Detail = content.Detail;
                contentUpdate.Warrantly = content.Warrantly;
                contentUpdate.MetaKeywords = content.MetaKeywords;
                contentUpdate.MetaDescriptions = content.MetaDescriptions;
                contentUpdate.Status = content.Status;
                var result = db.SaveChanges();
                if (!string.IsNullOrEmpty(content.Tags))
                {
                    string[] tags = content.Tags.Split('-').ToArray();
                    for (int i = 0; i < tags.Length; i++)
                    {
                        var tagID = StringHelper.ToUnsignString(tags[i]);
                        var existedTag = CheckTag(tagID);
                        if (!existedTag)
                        {
                            InsertTag(tagID, tags[i]);
                        }
                        InsertContentTag(content.ID, tagID);
                    }
                }
                return result;
            }
        }

        public static void RemoveAllContentTag(long contentId)
        {
            using (var db = new OnlineShopEntities())
            {
                db.ContentTags.RemoveRange(db.ContentTags.Where(x => x.ContentID == contentId));
                db.SaveChanges();
            }         
        }

        private static void InsertTag(string id, string name)
        {
            using (var db = new OnlineShopEntities())
            {
                var tag = new Tag { ID = id, Name = name };
                db.Tags.Add(tag);
                db.SaveChanges();
            }
        }

        private static void InsertContentTag(int contentID, string tagID)
        {
            using (var db = new OnlineShopEntities())
            {
                var contentTag = new ContentTag { ContentID = contentID, TagID = tagID };
                db.ContentTags.Add(contentTag);
                db.SaveChanges();
            }
        }

        private static bool CheckTag(string id)
        {
            using (var db = new OnlineShopEntities())
            {
                return db.Tags.Count(x => x.ID == id) > 0;
            }
        }

        /// <summary>
        /// List all content for client
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static List<Content> ListAllPaging(int page, int pageSize)
        {
            using (var db = new OnlineShopEntities())
            {
                var model = db.Contents;
                return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize).ToList();
            }      
        }

        public static List<Content> ListAllByTag(string tag, int page, int pageSize)
        {
            var db = new OnlineShopEntities();
            var model = (from a in db.Contents
                         join b in db.ContentTags
                         on a.ID equals b.ContentID
                         where b.TagID == tag
                         select new Content
                         {
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Image = a.Image,
                             Description = a.Description,
                             CreatedDate = a.CreatedDate,
                             CreatedBy = a.CreatedBy,
                             ID = a.ID

                         })
                         .OrderByDescending(x => x.CreatedDate)
                         .ToPagedList(page, pageSize)
                         .ToList();
            return model;
        }
    }
}