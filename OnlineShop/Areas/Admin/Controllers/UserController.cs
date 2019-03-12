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
    public class UserController : BaseController
    {
        [HttpGet]
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index()
        {           
            var users = UserBLL.GetAllUser();
            return View(users);
        }

        [HttpGet]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = userModel.Name,
                    UserName = userModel.UserName,
                    Password = Encryptor.MD5Hash(userModel.Password),
                    Address = userModel.Address,
                    Email = userModel.Email,
                    Phone = userModel.Phone,
                    Status = userModel.Status
                };
                var result = UserBLL.InsertUser(user);
                if (result > 0)
                {
                    SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View("Create");
        }


        [HttpGet]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(int ID)
        {
            var userDetail = UserBLL.GetDetail(ID);
            var userModel = new UserModel
            {
                ID = userDetail.ID,
                Name = userDetail.Name,
                UserName = userDetail.UserName,
                Password = userDetail.Password,
                Address = userDetail.Address,
                Email = userDetail.Email,
                Phone = userDetail.Phone,
                Status = userDetail.Status
            };
            return View(userModel);
         }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    ID = userModel.ID,
                    Name = userModel.Name,
                    UserName = userModel.UserName,
                    Password = Encryptor.MD5Hash(userModel.Password),
                    Address = userModel.Address,
                    Email = userModel.Email,
                    Phone = userModel.Phone,
                    Status = userModel.Status
                };
                var result = UserBLL.UpdateUser(user);
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
            return View(userModel);
        }
      
        [HttpDelete]
        [HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int ID)
        {
            UserBLL.DeleteUser(ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChangeStatus(int ID)
        {
            var result = UserBLL.ChangeStatus(ID);
            return RedirectToAction("Index");
        }
    }
}