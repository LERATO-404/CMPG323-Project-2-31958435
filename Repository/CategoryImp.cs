using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Device_Management_System.Interfaces;
using Device_Management_System.Models;
using Device_Management_System.DatabaseContext;

namespace Device_Management_System.Repository
{
    public class CategoryImp : ICategory
    {

        public readonly DmsDbContext _context;

        public CategoryImp(DmsDbContext context)
        {
            _context = context;
        }

        public Category CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Device> GetAllDeviceInCategory(int categoryId)
        {
            //var existingCategory = _context.Categories.Find(categoryId);
            var devices = _context.Devices.Where(d => d.CategoryID ==categoryId).ToList();
            return devices;
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(p => p.CategoryID == id);
        }

        public IEnumerable<Zone> NumberOfZonesInCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Category UpdateCategory(Category category)
        {
            //fetch employee first
            var existingCategory = _context.Categories.Find(category.CategoryID);
            if (existingCategory != null)
            {
                //what are you updating
                existingCategory.CategoryName = category.CategoryName;
                existingCategory.CategoryDescription = category.CategoryDescription;
                _context.Update(existingCategory);
                _context.SaveChanges();
            }
            return category;
        }
    }
}
