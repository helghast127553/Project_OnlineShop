using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int ID { get; set; }
        
        [Display(Name = "Category_Name", ResourceType = typeof(StaticResources.Resources))]
        [Required(ErrorMessageResourceName = "Category_RequiredName", ErrorMessageResourceType =typeof(StaticResources.Resources))]
        public string Name { get; set; }

        [Display(Name = "Category_MetaTitle", ResourceType = typeof(StaticResources.Resources))]
        public string MetaTitle { get; set; }

        [Display(Name = "Category_ParentId", ResourceType = typeof(StaticResources.Resources))]
        public Nullable<int> ParentID { get; set; }

        [Display(Name = "Category_DisplayOrder", ResourceType = typeof(StaticResources.Resources))]
        public Nullable<int> DisplayOrder { get; set; }

        [Display(Name = "Category_SeoTitle", ResourceType = typeof(StaticResources.Resources))]
        public string SeoTitle { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifieldDate { get; set; }
        public string ModifiedBy { get; set; }

        [Display(Name = "Category_Metakeyword", ResourceType = typeof(StaticResources.Resources))]
        public string MetaKeywords { get; set; }

        [Display(Name = "Category_MetaDescription", ResourceType = typeof(StaticResources.Resources))]
        public string MetaDescriptions { get; set; }

        [Display(Name = "Category_Status", ResourceType = typeof(StaticResources.Resources))]
        public Nullable<bool> Status { get; set; }

        [Display(Name = "Category_ShowOnHome", ResourceType = typeof(StaticResources.Resources))]
        public Nullable<bool> ShowOnHome { get; set; }
        public string Language { get; set; }
    }
}