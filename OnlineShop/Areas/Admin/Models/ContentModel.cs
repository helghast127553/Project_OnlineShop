using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class ContentModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Detail { get; set; }
        public Nullable<int> Warrantly { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifieldDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> TopHot { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public string Tags { get; set; }
        public string Language { get; set; }
    }
}