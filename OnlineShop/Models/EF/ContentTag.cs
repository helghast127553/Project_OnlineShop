//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShop.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContentTag
    {
        public int ID { get; set; }
        public int ContentID { get; set; }
        public string TagID { get; set; }
    
        public virtual Content Content { get; set; }
        public virtual Tag Tag { get; set; }
    }
}