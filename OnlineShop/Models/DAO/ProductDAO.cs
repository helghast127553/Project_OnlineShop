using OnlineShop.Models.DTO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.DAO
{
    public static class ProductDAO
    {
        public static List<Product> GetNewProducts(int top)
        {
            using (var db = new OnlineShopEntities())
            {
                var newProducts = db.Products
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(top).ToList();
                return newProducts;
            }
        }

        public static List<Product> GetAllRelatedProduct(int ID)
        {
            using (var db = new OnlineShopEntities())
            {
                var products = db.Products.Find(ID);
                var relatedProducts = db.Products.Where(x => x.ID != ID && x.CategoryID == products.CategoryID).ToList();
                return relatedProducts;
            }
        }

        public static List<Product> GetFeatureProducts(int top)
        {
            using (var db = new OnlineShopEntities())
            {
                var featureProducts = db.Products
                    .Where(x => x.TopHot > DateTime.Now)
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(top)
                    .ToList();
                return featureProducts;
            }
        }

        public static Product GetProductDetail(int ID)
        {
            using (var db = new OnlineShopEntities())
            {
                var product = db.Products.Find(ID);
                return product;
            }
        }

        public static List<ProductDTO> GetProductByCategoryID(int categoryID, ref int totalRecord, int pageIndex, int pageSize)
        {
            var db = new OnlineShopEntities();
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var products = from a in db.Products
                           join b in db.ProductCategories
                           on a.CategoryID equals b.ID
                           where a.CategoryID == categoryID
                           select new ProductDTO
                           {
                               ID = a.ID,
                               Images = a.Image,
                               Name = a.Name,
                               Price = a.Price,
                               CategoryName = b.Name,
                               CategoryMetaTitle = b.MetaTitle,
                               MetaTitle = a.MetaTitle,
                               CreatedDate = a.CreatedDate,
                           };
            products.OrderByDescending(x => x.CreatedDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
            return products.ToList();
        }

        public static List<string> SearchProduct(string keyword)
        {
            using (var db = new OnlineShopEntities())
            {
                var products = db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
                return products;
            }
        }

        public static List<ProductDTO> SearchProduct(string keyword, ref int totalRecord, int pageIndex, int pageSize)
        {
            var db = new OnlineShopEntities();
            totalRecord = db.Products.Where(x => x.Name.Contains(keyword)).Count();
            var products = from a in db.Products
                           join b in db.ProductCategories
                           on a.CategoryID equals b.ID
                           where a.Name.Contains(keyword)
                           select new ProductDTO
                           {
                               ID = a.ID,
                               Images = a.Image,
                               Name = a.Name,
                               Price = a.Price,
                               CategoryName = b.Name,
                               CategoryMetaTitle = b.MetaTitle,
                               MetaTitle = a.MetaTitle,
                               CreatedDate = a.CreatedDate,
                           };
            products.OrderByDescending(x => x.CreatedDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
            return products.ToList();
        }
    }
}