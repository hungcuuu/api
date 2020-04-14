using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGuestLogic
    {
        #region Categories
        IEnumerable<Category> GetCategories();
        List<Category> GetCategoriesList();
        Category GetCategoryDetail(int id);
        #endregion

        #region Products
        IEnumerable<Product> GetProducts();
        List<Product> GetProductsList();
        List<Product> GetProductsByCategory(int CatId);

        Product GetProductDetail(int id);

        #endregion

        #region Table
        IEnumerable<Table> GetTables();
        List<Table> GetTablesList();
        Table GetTableDetail(int id);
        #endregion
        //   public async Task<string> SignInGoogleAsync(string idToken);

        #region Customer
        IEnumerable<Customer> GetCustomers();
        #endregion
      
        #region Orders
        IEnumerable<Order> GetOrders();
        #endregion

        #region OrderDetail
        IEnumerable<OrderDetail> GetOrderDetails();
        #endregion

        #region Payments
        IEnumerable<Payment> GetPayments();
        #endregion

        public string SignInGoogle(string idToken);
    }
}
