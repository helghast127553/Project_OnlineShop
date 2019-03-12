using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DTO
{
    public class OrderDTO
    {
        public int ID { get; set; }

        [Display(Name = "Người nhận:")]
        [Required(ErrorMessage = "Người nhận không được để trống")]
        public string ShipName { get; set; }

        [Display(Name = "Điện thoại:")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại phải nhập đúng")]
        [RegularExpression(@"^([0-9]{10,11})$",
            ErrorMessage = "Số điện thoại phải từ 10 tới 11 số")]
        public string ShipMobile { get; set; }

        [Display(Name = "Địa chỉ:")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string ShipAddress { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email phải nhập đúng")]
        public string ShipEmail { get; set; }
    }
}