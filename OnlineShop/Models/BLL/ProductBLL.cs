using OnlineShop.Models.DAO;
using OnlineShop.Models.DTO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.BLL
{
    public static class ProductBLL
    {
        public static List<Product> GetNewProducts(int top)
        {
            return ProductDAO.GetNewProducts(top);
        }

        public static List<Product> GetFeatureProducts(int top)
        {
            return ProductDAO.GetFeatureProducts(top);
        }

        public static Product GetProductDetail(int ID)
        {
            return ProductDAO.GetProductDetail(ID);
        }
        
        public static List<Product> GetAllRelatedProduct(int ID)
        {
            return ProductDAO.GetAllRelatedProduct(ID);
        }

        public static List<ProductDTO> GetProductByCategoryID(int categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            return ProductDAO.GetProductByCategoryID(categoryID, ref totalRecord, pageIndex, pageSize);
        }

        public static List<string> SearchProduct(string keyword)
        {
            return ProductDAO.SearchProduct(keyword);
        }

        public static List<ProductDTO> SearchProduct(string keyword, ref int totalRecord, int pageIndex, int pageSize)
        {
            return ProductDAO.SearchProduct(keyword, ref totalRecord, pageIndex, pageSize);
        }
    }
}