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
    [Route("api/device")]
    [ApiController]
    public class DeviceController : ControllerBase
    {

        private readonly IDevice _deviceRepo;

        public DeviceController(IDevice device)
        {
            _deviceRepo = device;
        }

        //Before editing/deleting
        private bool CheckIfDeviceExist(Device device)
        {
            if (device != null)
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public IActionResult GetAllDevices()
        {
            var devices = _deviceRepo.GetAllDevices();
            return Ok(devices);
        }

        [HttpGet("{id}")]
        public IActionResult GetDeviceById(int id)
        {
            var device = _deviceRepo.GetDeviceById(id);

            if (CheckIfDeviceExist(device) == true)
            {
                return Ok(device);
            }
            return NotFound("Device Id: " + id.ToString() + " was not found");

        }

        [HttpPost]
        public IActionResult CreateDevice(Device device)
        {
            _deviceRepo.CreateDevice(device);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + device.DeviceId
            , device);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateDeviceDetails(int id, Device device)
        {
            var existingdevice = _deviceRepo.GetDeviceById(id);
            if (CheckIfDeviceExist(existingdevice) == true)
            {
                device.DeviceId = existingdevice.DeviceId;
                _deviceRepo.UpdateDevice(device);
                return Ok(device);
            }
            else
            {
                return NotFound("Device Id: " + id.ToString() + " was not found");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var existingdevice = _deviceRepo.GetDeviceById(id);
            if (CheckIfDeviceExist(existingdevice) == true)
            {
                _deviceRepo.DeleteDevice(existingdevice);
                return Ok("Device Id: " + id.ToString() + " Deleted");
            }
            else
            {
                return NotFound("Deleted Id: " + id.ToString() + " was not found");
            }
        }
    }
}
