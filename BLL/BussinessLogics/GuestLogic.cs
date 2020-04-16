using BLL.Helpers;
using BLL.Interfaces;
using BLL.RequestModels;
using DAL.Models;
using DAL.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BLL.BussinessLogics
{
    public class GuestLogic : IGuestLogic
    {

        protected readonly IUnitOfWork _uow;
        protected readonly IOptions<AppSetting> _options;
        // protected readonly IOptions<AdminGuide> _help;
        public GuestLogic(IUnitOfWork uow, IOptions<AppSetting> options)
        {
            _uow = uow;
        }

        #region Categories
        public IEnumerable<Category> GetCategories()
        {
            try
            {
                IEnumerable<Category> list = _uow
                .GetRepository<Category>()
                .GetAll()
                .Where(c => c.IsDisplayed == true);


                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<object> GetCategoriesList()
        {
            try
            {

                var result = GetCategories()
                .OrderBy(c => c.DisplayOrder)
                .Select(c => new { c.Id, c.Name, c.AdjustmentNote })
                .ToList();
                return new List<object>(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Category GetCategoryDetail(int id)
        {
            // var category = _uow.GetRepository<Category>().GetAll().FirstOrDefault(c => c.Id == id);
            var category = GetCategories()
                .FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                throw new ArgumentNullException();
            }


            return category;
        }


        public bool InsertCategory(Category category)
        {
            try
            {
                bool rs = false;
                category.IsDisplayed = true;
                _uow.GetRepository<Category>()
                   .Insert(category);
                rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool UpdateCategory(Category category)
        {
            try
            {
                bool rs = false;
                _uow.GetRepository<Category>()
                   .Update(category);
                rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool DeleteCategory(int id)
        {
            try
            {
                bool rs = false;
                var category = GetCategories().FirstOrDefault(c => c.Id == id);
                _uow.GetRepository<Category>().Delete(category);
                rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Products
        public IEnumerable<Product> GetProducts()
        {
            try
            {
                IEnumerable<Product> list = _uow
                .GetRepository<Product>()
                .GetAll()
                .Where(c => c.IsAvailable == true);

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<object> GetProductsList()
        {
            try
            {
                var result = GetProducts()
                .OrderBy(c => c.DisplayOrder)
                .Select(c => new { c.ProductId, c.ProductName, c.Price, c.PicUrl, c.CatId, c.IsMostOrder })
                .ToList();
                return new List<object>(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Product> GetProductsByCategory(int CatId)
        {
            try
            {
                List<Product> result = GetProducts()
                    .Where(p => p.CatId == CatId)
                    .OrderBy(c => c.DisplayOrder)
                .ToList();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Product GetProductDetail(int proId)
        {
            try
            {
                Product result = GetProducts()
                .FirstOrDefault(p => p.ProductId == proId);
                if (result == null)
                {
                    throw new ArgumentNullException();
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool InsertProduct(Product product)
        {
            try
            {
                product.IsAvailable = true;
                bool rs = false;
                _uow.GetRepository<Product>()
                   .Insert(product);
                rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool UpdateProduct(Product product)
        {
            try
            {
                bool rs = false;
                _uow.GetRepository<Product>()
                   .Update(product);
                rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool DeleteProduct(int id)
        {
            try
            {
                bool rs = false;
                var product = GetProducts().FirstOrDefault(c => c.ProductId == id);
                _uow.GetRepository<Product>().Delete(product);
                rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion



        #region Login
        public string SignInGoogle(string idToken)
        {
            ////  NetHttpTransport sp = GoogleNetHttpTransport
            //var v = await GoogleJsonWebSignature


            //var rs = validPayload.Email;
            //return rs;
            return "";
        }

        #endregion
        #region Tables
        public IEnumerable<Table> GetTables()
        {
            try
            {
                IEnumerable<Table> list = _uow
                .GetRepository<Table>()
                .GetAll();


                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Table> GetTablesList()
        {
            try
            {
                List<Table> result = GetTables()
                .OrderBy(c => c.DisplayOrder)
                .Where(c => c.Status == 0)
                .ToList();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Table GetTableDetail(int id)
        {
            // var category = _uow.GetRepository<Category>().GetAll().FirstOrDefault(c => c.Id == id);
            var table = GetTables()
                .FirstOrDefault(c => c.Id == id);
            if (table == null)
            {
                throw new ArgumentNullException();
            }


            return table;
        }
        public bool InsertTable(Table table)
        {
            try
            {
                bool rs = false;
                _uow.GetRepository<Table>()
                   .Insert(table);
                rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool UpdateTable(Table table)
        {
            try
            {

                _uow.GetRepository<Table>().Update(table);
                var rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool DeleteTable(int id)
        {
            try
            {
                bool rs = false;
                var table = GetTables().FirstOrDefault(c => c.Id == id);
                _uow.GetRepository<Table>().Delete(table);
                rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Customers
        public IEnumerable<Customer> GetCustomers()
        {
            try
            {
                IEnumerable<Customer> list = _uow
                .GetRepository<Customer>()
                .GetAll();


                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Customer> GetCustomersList()
        {
            try
            {
                List<Customer> result = GetCustomers()
                .ToList();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Customer GetCustomerDetail(int id)
        {
            // var category = _uow.GetRepository<Category>().GetAll().FirstOrDefault(c => c.Id == id);
            var customer = GetCustomers()
                .FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                throw new ArgumentNullException();
            }


            return customer;
        }
        public bool InsertCustomer(Customer customer)
        {
            try
            {
                bool rs = false;
                _uow.GetRepository<Customer>()
                   .Insert(customer);
                rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool UpdateCustomer(Customer customer)
        {
            try
            {

                _uow.GetRepository<Customer>().Update(customer);
                var rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool DeleteCustomer(int id)
        {
            try
            {
                bool rs = false;
                var customer = GetCustomers().FirstOrDefault(c => c.CustomerId == id);
                _uow.GetRepository<Customer>().Delete(customer);
                rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Orders
        public IEnumerable<Order> GetOrders()
        {
            try
            {
                IEnumerable<Order> list = _uow
                .GetRepository<Order>()
                .GetAll()
                //.Include(c=>c.Table.Number);
                ;

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Order> GetOrdersList()
        {
            try
            {
                List<Order> result = GetOrders()
                .OrderByDescending(c => c.CheckInDate)
                // .Where(c => c.Active == true)
                .ToList();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Order GetOrderById(int id)
        {
            try
            {
                var order = GetOrders().FirstOrDefault(c => c.OrderId == id);

                return order;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool InsertOrder(string orderCode,int numOfcustomer)
        {
            try
            {

                var order = new Order
                {
                    OrderCode = orderCode,
                    CheckInDate = DateTime.Now,
                    NumberOfGuest = numOfcustomer
                    
                };
                bool rs = false;
                _uow.GetRepository<Order>()
                   .Insert(order);
                rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            try
            {
                List<OrderDetail> result = GetOrderDetails()
                 .Where(c => c.OrderId == orderId)
                .ToList();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateOrder(Order category)
        {
            return false;
        }
        public bool DeleteOrder(int id)
        {
            return false;
        }
        #endregion

        #region OrderDetails
        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            try
            {
                IEnumerable<OrderDetail> result = _uow.GetRepository<OrderDetail>()
                .GetAll();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public bool InsertOrderDetail(List<ProductOrder> orderDetail,string orderCode)
        {

            try
            {
                var order = GetOrders().FirstOrDefault(c => c.OrderCode == orderCode);
                if (order == null)
                    return false;
                foreach(ProductOrder product in orderDetail) {
                    var item = new OrderDetail { OrderId = order.OrderId, ProductId = product.productId, Quantity = product.quantity};
                    _uow.GetRepository<OrderDetail>().Insert(item);
                }
               var rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool DeleteOrderDetail(int id)
        {
            return false;

        }
        #endregion
        public IEnumerable<Payment> GetPayments()
        {
            throw new NotImplementedException();
        }





    }
}
