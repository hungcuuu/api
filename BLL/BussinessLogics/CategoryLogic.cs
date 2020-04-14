using BLL.Helpers;
using BLL.Interfaces;
using DAL.Models;
using DAL.UnitOfWorks;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.BussinessLogics
{
    class CategoryLogic : ICategoryLogic
    {
        #region Classes and Constructor
        protected readonly IUnitOfWork _uow;
        protected readonly IOptions<AppSetting> _options;
        // protected readonly IOptions<AdminGuide> _help;
        public CategoryLogic(IUnitOfWork uow, IOptions<AppSetting> options)
        {
            _uow = uow;
            _options = options;
        }
        #endregion



        public List<Category> ViewCategoriesList(Category Category)
        {
            try
            {
                List<Category> result = _uow
                .GetRepository<Category>()
                .GetAll()
                .Where(c => c.IsDisplayed == true)
                .OrderBy(c => c.DisplayOrder)
                .ToList();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Category ViewCategoryDetail(int CategoryId)
        {
            var category = _uow.GetRepository<Category>().GetAll().FirstOrDefault(c => c.Id == CategoryId);
            if (category == null)
            {
                throw new ArgumentNullException();
            }


            return category;
        }
    }
}
