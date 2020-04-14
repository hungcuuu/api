using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICategoryLogic
    {
        public List<Category> ViewCategoriesList(Category Category);
        public Category ViewCategoryDetail(int id);
    }
}
