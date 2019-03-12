using OnlineShop.Common;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DAO
{
    public static class UserDAO
    {
        public static int InsertUser(User user)
        {
            var result = 0;
            using (var db = new OnlineShopEntities())
            {
                db.Users.Add(user);
                result = db.SaveChanges();
                return result;
            }
        }

        public static int InsertForFacebook(User user)
        {
            using (var db = new OnlineShopEntities())
            {
                var result = db.Users.SingleOrDefault(x => x.UserName.Equals(user.UserName));
                if (result == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return result.ID;
                }
                else
                {
                    return user.ID;
                }
            }
        }

        public static int UpdateUser(User userEntity)
        {
            using (var db = new OnlineShopEntities())
            {
                var user = db.Users.Find(userEntity.ID);
                user.Name = userEntity.Name;
                user.UserName = userEntity.UserName;
                user.Address = userEntity.Address;
                user.Email = userEntity.Email;
                user.Phone = userEntity.Phone;
                user.ModifiedBy = userEntity.ModifiedBy;
                user.ModifieldDate = userEntity.ModifieldDate;
                var result = db.SaveChanges();
                return result;
            }
        }

        public static int DeleteUser(int ID)
        {
            using (var db = new OnlineShopEntities())
            {
                var user = db.Users.Find(ID);
                db.Users.Remove(user);
                var result = db.SaveChanges();
                return result;
            }
        }

        public static bool ChangeStatus(int ID)
        {
            using (var db = new OnlineShopEntities())
            {
                var user = db.Users.Find(ID);
                user.Status = !user.Status;
                db.SaveChanges();
                return user.Status;
            }
        }
        public static User GetDetail(int ID)
        {
            using (var db = new OnlineShopEntities())
            {
                var result = db.Users.Find(ID);
                return result;
            }
        }

        public static User GetUserByID(string UserName)
        {
            using (var db = new OnlineShopEntities())
            {
                return db.Users.SingleOrDefault(x => x.UserName.Equals(UserName));
            }
        }

        public static int CheckUser(string userName, string password, bool IsLoginAdmin = false)
        {
            using (var db = new OnlineShopEntities())
            {
                var user = db.Users.SingleOrDefault(x => (x.UserName.Equals(userName)));
                if (user == null)
                {
                    return 0;
                }
                else
                {
                    if (IsLoginAdmin == true)
                    {
                        if (user.UserGroupID.Equals(CommonConstants.ADMIN_GROUP)
                        || user.UserGroupID.Equals(CommonConstants.MOD_GROUP))
                        {
                            if (user.Status == false)
                            {
                                return -1;
                            }
                            else
                            {
                                if (user.Password == password)
                                    return 1;
                                else
                                    return -2;
                            }
                        }
                        else
                        {
                            return -3;
                        }
                    }
                    else
                    {
                        if (user.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (user.Password == password)
                            {
                                return 1;
                            }
                            else
                            {
                                return -2;
                            }
                        }
                    }
                }
            }
        }

        public static List<User> GetAllUser()
        {
            using (var db = new OnlineShopEntities())
            {
                var users = db.Users.ToList();
                return users;
            }
        }

        public static bool CheckUser(string userName)
        {
            using (var db = new OnlineShopEntities())
            {
                return db.Users.Count(x => x.UserName.Equals(userName)) > 0;
            }
        }

        public static bool CheckEmail(string email)
        {
            using (var db = new OnlineShopEntities())
            {
                return db.Users.Count(x => x.Email.Equals(email)) > 0;
            }
        }

        public static List<string> GetListCredential(string userName)
        {
            var db = new OnlineShopEntities();
            var user = db.Users.SingleOrDefault(x => x.UserName.Equals(userName));
            var data = (from a in db.Credentials
                       join b in db.UserGroups on a.UserGroupID equals b.ID
                       join c in db.Roles on a.RoleID equals c.ID
                       where b.ID == user.UserGroupID
                       select new 
                       {
                           RoleID = a.RoleID,
                           UserGroupID = a.UserGroupID
                       }).AsEnumerable().Select(x => new Credential
                       {
                           RoleID = x.RoleID,
                           UserGroupID = x.UserGroupID
                       });
            return data.Select(x => x.RoleID).ToList();
        }
    }
}