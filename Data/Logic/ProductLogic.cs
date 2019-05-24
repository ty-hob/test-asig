using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Data.Models;
using Data.DataAccess;

namespace Data.Logic
{
    public class ProductLogic
    {
        public static int AddProduct(string title, int quantity, float price)
        {
            ProductDataModel data = new ProductDataModel
            {
                Title = title,
                Quantity = quantity,
                Price = price
            };
            string sql = @"INSERT INTO dbo.Products (Title, Quantity, Price)
                           VALUES (@Title, @Quantity, @Price);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<ProductDataModel> LoadProducts()
        {
            string sql = @"select Title, Quantity, Price from dbo.Products;";
            return SqlDataAccess.LoadData<ProductDataModel>(sql);
        }
    }
}
