using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Device_Management_System.Interfaces;
using Device_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Device_Management_System.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    [Authorize]
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _categoryRepo;

        public CategoryController(ICategory category)
        {
            _categoryRepo = category;
        }
        //Before editing/deleting
        private bool CheckIfCategoryExist(Category category)
        {
            if (category != null)
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryRepo.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryRepo.GetCategoryById(id);
            if (CheckIfCategoryExist(category) == true)
            {
                return Ok(category);
            }
            return NotFound("Category Id: " + id.ToString() + " was not found");

        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryRepo.CreateCategory(category);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + category.CategoryID
            , category);
        }


        [HttpPatch("{id}")]
        public IActionResult UpdateCategoryDetails(int id, Category category)
        {
            var existingCategory = _categoryRepo.GetCategoryById(id);
            if (CheckIfCategoryExist(existingCategory) == true)
            {
                category.CategoryID = existingCategory.CategoryID;
                _categoryRepo.UpdateCategory(category);
                return Ok(category);
            }
            else
            {
                return NotFound("Category Id: " + id.ToString() + " was not found");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var existingCategory = _categoryRepo.GetCategoryById(id);
            if (CheckIfCategoryExist(existingCategory) == true)
            {
                _categoryRepo.DeleteCategory(existingCategory);
                return Ok("Category Id: " + id.ToString() + " Deleted");
            }
            else
            {
                return NotFound("Category Id: " + id.ToString() + " was not found");
            }
        }

        [HttpGet("all/devices/{id}")]
        public IActionResult GetAllDevicesInCategory(int id)
        {
            var existingCategory = _categoryRepo.GetCategoryById(id);
            if (CheckIfCategoryExist(existingCategory) == true)
            {
                var devices = _categoryRepo.GetAllDeviceInCategory(id);
                return Ok(devices);
            }
            return NotFound("Category Id: " + id.ToString() + " was not found");

        }


        [HttpGet("zones/count/{id}")]
        public ActionResult<int> ZonesCount(int id){
            var existingCategory = _categoryRepo.GetCategoryById(id);
            if (CheckIfCategoryExist(existingCategory) == true)
            {
                //int numberOfZones =_categoryRepo.NumberOfZonesInCategory(id);
                //return numberOfZones;
                return _categoryRepo.NumberOfZonesInCategory(id);
            }
            return NotFound("Category Id: " + id.ToString() + " was not found");
        }
    }
}
