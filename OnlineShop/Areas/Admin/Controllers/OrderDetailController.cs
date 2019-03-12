using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using OnlineShop.Models.BLL;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class OrderDetailController : BaseController
    {
        [HttpGet]
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index()
        {
            var orderDetails = OrderDetailsBLL.GetOrderDetails();
            return View(orderDetails);
        }

        [HttpGet]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(int ID)
        {
            var orderDetail = OrderDetailsBLL.GetOrderDetail(ID);
            var orderDetailModel = new OrderDetailModel
            {
               ID = orderDetail.ID,
               ProductID = orderDetail.ProductID,
               OrderID = orderDetail.OrderID,
               Quantity = orderDetail.Quantity,
               Price = orderDetail.Price
            };
            return View(orderDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderDetailModel orderDetailModel)
        {
            if (ModelState.IsValid)
            {
                var orderDetail = new OrderDetail
                {
                    ID = orderDetailModel.ID,
                    ProductID = orderDetailModel.ProductID,
                    OrderID = orderDetailModel.OrderID,
                    Quantity = orderDetailModel.Quantity,
                    Price = orderDetailModel.Price
                };
                var result = OrderDetailsBLL.UpdateOrderDetaiL(orderDetail);
                if (result > 0)
                {
                    SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View(orderDetailModel);
        }

        [HttpDelete]
        [HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int ID)
        {
            OrderDetailsBLL.DeleteOrderDetail(ID);
            return RedirectToAction("Index");
        }
    }
}