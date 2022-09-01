using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Device_Management_System.Interfaces;
using Device_Management_System.Models;

namespace Device_Management_System.Repository
{
    public class CategoryImp : ICategory
    {
        //Before editing/deleting
        private bool CheckIfCategoryExist(int catID)
        {
            throw new NotImplementedException();
        }
        public void CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Device> GetAllDeviceInCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Zone> NumberOfZonesInCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
