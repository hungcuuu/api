﻿using BLL.RequestModels;
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
        List<object> GetProductsSearchList(string search,int pageItems, int currentPage);
        List<Product> GetProductsByCategory(int CatId);
        Product GetProductDetail(int id);
        bool InsertProduct(Product category);
        bool UpdateProduct(Product category);
        bool UpdateImageProduct(int id, string url);
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
        List<Customer> GetCustomersList();
        Customer GetCustomerDetail(int id);
        bool DeleteCustomer(int id);
        bool UpdateCustomer(Customer customer);
        bool InsertCustomer(Customer customer);
        #endregion

        #region Orders
        IEnumerable<Order> GetOrders();
        List<Order> GetOrdersList();
        Order GetOrderById(int id);
        bool InsertOrder(string orderCode, int numOfcustomer);
        bool UpdateOrder(Order category);
        bool DeleteOrder(int id);


        #endregion

        #region OrderDetail
        List<OrderDetail> GetOrderDetailsByOrderId(int orderId);
        bool InsertOrderDetail(List<ProductOrder> orderDetail, string orderCode);
        bool DeleteOrderDetail(int id);
        #endregion

        #region Payments
        IEnumerable<Payment> GetPayments();
        #endregion

        public string SignInGoogle(string idToken);
    }
}
