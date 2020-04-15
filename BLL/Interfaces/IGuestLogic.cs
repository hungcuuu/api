using BLL.RequestModels;
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
        List<object> GetCategoriesList();
        Category GetCategoryDetail(int id);

        bool InsertCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
        #endregion

        #region Products
        IEnumerable<Product> GetProducts();
        List<object> GetProductsList();
        List<Product> GetProductsByCategory(int CatId);
        Product GetProductDetail(int id);
        bool InsertProduct(Product category);
        bool UpdateProduct(Product category);
        bool DeleteProduct(int id);
        #endregion

        #region Table
        IEnumerable<Table> GetTables();
        List<Table> GetTablesList();
        Table GetTableDetail(int id);
        bool InsertTable(Table table);
        bool UpdateTable(Table table);
        bool DeleteTable(int id);
        #endregion
        //   public async Task<string> SignInGoogleAsync(string idToken);

        #region Customer
        IEnumerable<Customer> GetCustomers();
        #endregion

        #region Orders
        IEnumerable<Order> GetOrders();
         List<Order> GetOrdersList();
        Order GetOrderById(int id);
        bool InsertOrder(RequestOrderDetail list);
        bool UpdateOrder(Order category);
        bool DeleteOrder(int id);


        #endregion

        #region OrderDetail
          IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId);
        bool InsertOrderDetail(RequestOrderDetail orderDetail);
        bool DeleteOrderDetail(int id);
        #endregion

        #region Payments
        IEnumerable<Payment> GetPayments();
        #endregion

        public string SignInGoogle(string idToken);
    }
}
