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
    [Route("api/Zones")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZone _zoneRepo;

        public ZoneController(IZone zone)
        {
            _zoneRepo = zone;
        }
        //Before editing/deleting
        private bool CheckIfZoneExist(Zone zone)
        {
            if (zone != null)
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public IActionResult GetZones()
        {
            var zones = _zoneRepo.GetAllZones();
            return Ok(zones);
        }

        [HttpGet("{id}")]
        public IActionResult GetZoneById(int id)
        {
            var zone = _zoneRepo.GetZoneById(id);
            if (CheckIfZoneExist(zone) == true)
            {
                return Ok(zone);
            }
            return NotFound("Zone Id: " + id.ToString() + " was not found");

        }

        [HttpPost]
        public IActionResult CreateZone(Zone zone)
        {
            _zoneRepo.CreateZone(zone);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + zone.ZoneID
            ,zone);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateZoneDetails(int id, Zone zone)
        {
            var existingZone = _zoneRepo.GetZoneById(id);
            if (CheckIfZoneExist(existingZone) == true)
            {
                zone.ZoneID = existingZone.ZoneID;
                _zoneRepo.UpdateZone(zone);
                return Ok(zone);
            }
            else
            {
                return NotFound("Zone Id: " + id.ToString() + " was not found");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var existingZone = _zoneRepo.GetZoneById(id);
            if (CheckIfZoneExist(existingZone) == true)
            {
                _zoneRepo.DeleteZone(existingZone);
                return Ok("Zone Id: " + id.ToString() + " Deleted");
            }
            else
            {
                return NotFound("Zone Id: " + id.ToString() + " was not found");
            }
        }

        [HttpGet("{id}/devices")]
        public IActionResult GetAllDevicesInZone(int id)
        {
            var existingZone = _zoneRepo.GetZoneById(id);
            if (CheckIfZoneExist(existingZone) == true)
            {
                var devices = _zoneRepo.GetAllDevicesInZone(id);
                return Ok(devices);
            }
            return NotFound("Zone Id: " + id.ToString() + " was not found");

        }



    }
}
