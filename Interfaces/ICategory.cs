using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Device_Management_System.Models;

namespace Device_Management_System.Interfaces
{
    interface ICategory
    {

        IEnumerable<Category> GetAllCategories();
        //Or
        //List<Category> GetAllCategories();

        Category GetCategoryById(int id);

        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(Category category);

        //return/get all the device in a specific category
        IEnumerable<Device> GetAllDeviceInCategory(int id);

        //not sure
        IEnumerable<Zone> NumberOfZonesInCategory(int id);
    }
}
