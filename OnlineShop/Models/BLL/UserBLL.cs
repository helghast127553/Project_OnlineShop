using OnlineShop.Models.DAO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.BLL
{
    public static class UserBLL
    {
        public static int InsertUser(User user)
        {
            return UserDAO.InsertUser(user);
        }

        public static int InsertForFacebook(User user)
        {
            return UserDAO.InsertForFacebook(user);
        }

        public static int UpdateUser(User userEntity)
        {
            return UserDAO.UpdateUser(userEntity);
        }

        public static int DeleteUser(int ID)
        {
            return UserDAO.DeleteUser(ID);
        }

        public static User GetDetail(int ID)
        {
            return UserDAO.GetDetail(ID);
        }

        public static int CheckUser(string userName, string password, bool IsLoginAdmin = false)
        {
            return UserDAO.CheckUser(userName, password, IsLoginAdmin);
        }

        public static User GetUserByID(string userName)
        {
            return UserDAO.GetUserByID(userName);
        }

        public static List<User> GetAllUser()
        {
            return UserDAO.GetAllUser();
        }

        public static bool CheckUser(string userName)
        {
            return UserDAO.CheckUser(userName);
        }

        public static bool CheckEmail(string email)
        {
            return UserDAO.CheckUser(email);
        }

        public static bool ChangeStatus(int ID)
        {
            return UserDAO.ChangeStatus(ID);
        }

        public static List<string> GetListCredential(string userName)
        {
            return UserDAO.GetListCredential(userName);
        }
    }
}