using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Device_Management_System.Models;

namespace Device_Management_System.Interfaces
{
    public interface ICategory
    {

        IEnumerable<Category> GetAllCategories();
        //Or
        //List<Category> GetAllCategories();

        Category GetCategoryById(int id);

        Category CreateCategory(Category category);

        Category UpdateCategory(Category category);

        void DeleteCategory(Category category);

        //return/get all the device in a specific category
        IEnumerable<Device> GetAllDeviceInCategory(int categoryId);
        //IEnumerable<Device> GetAllDeviceInCategory(Category category);


        //not sure
        int NumberOfZonesInCategory(int id);
    }
}
