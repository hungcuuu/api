using BLL.Helpers;
using BLL.Interfaces;
using DAL.Models;
using DAL.UnitOfWorks;
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

        public List<Category> GetCategoriesList()
        {
            try
            {

                List<Category> result = GetCategories()
                .OrderBy(c => c.DisplayOrder)
                .ToList();
                return result;
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
        public List<Product> GetProductsList()
        {
            try
            {
                List<Product> result = GetProducts()
                .OrderBy(c => c.DisplayOrder)
                .ToList();
                return result;
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

        #endregion

        #region Customers
        public IEnumerable<Customer> GetCustomers()
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

        #endregion

        #region Orders
        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region OrderDetails
        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            throw new NotImplementedException();
        }
        #endregion
        public IEnumerable<Payment> GetPayments()
        {
            throw new NotImplementedException();
        }

       




    }
}
