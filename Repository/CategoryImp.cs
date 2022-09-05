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

        public IEnumerable<Zone> NumberOfZonesInCategory1(int id)
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

        public int NumberOfZonesInCategory(int id)
        {
            int zoneCount = _context.Devices
                            .Where(d => d.CategoryID == id)
                            .GroupBy( x => x.ZoneID).Count();
            return zoneCount;
            //int zoneCount = _context.Devices.Where(x => x.CategoryID == id).GroupBy(x => x.CategoryID).Count();
            //return zoneCount;
            /*
            int zoneCount = _context.Devices.Where(dd => dd.CategoryID == id)
                            .Join(_context.Categories,
                                dc => dc.CategoryID,
                                c => c.CategoryID, 
                                (dc,c) => new {dc,c})
                            .Join(_context.Zones,
                                dz => dz.dc.ZoneID,
                                z => z.ZoneID,
                                (dz,z) => new {dz, z})
                            .GroupBy(
                                x => x.z.ZoneID
                            ).Count();*/
            /*
            var zonesFound = from d in _context.Devices
                            join c in _context.Categories
                            on d.CategoryID equals c.CategoryID
                            join z in _context.Zones
                            on d.ZoneID equals z.ZoneID
                            select new {c.CategoryID, z.ZoneID};
            foreach (var item in zonesFound){
                int zoneCount = _context.Devices.Where(x => x.CategoryID == id).GroupBy(x => x.CategoryID).Count();
                return zoneCount;
            }
            return 0;
            var zonesFound = _context.Devices.Select (d => new  MyCategoryView
                            {
                                CategoryNumber = id,
                                ZonesCount = _context.Zones.Count()
                            }).ToList();*/
            //return 0;
            
        }
    }
}
