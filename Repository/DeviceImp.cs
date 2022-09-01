using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Device_Management_System.Interfaces;
using Device_Management_System.Models;
using Device_Management_System.DatabaseContext;

namespace Device_Management_System.Repository
{
    public class DeviceImp : IDevice
    {
        public readonly DmsDbContext _context;

        public DeviceImp(DmsDbContext context)
        {
            _context = context;
        }

        public Device CreateDevice(Device device)
        {
            _context.Devices.Add(device);
            _context.SaveChanges();
            return device;
        }

        public void DeleteDevice(Device device)
        {
            _context.Devices.Remove(device);
            _context.SaveChanges();
        }

        public IEnumerable<Device> GetAllDevices()
        {
            return _context.Devices.ToList();
        }

        public Device GetDeviceById(int id)
        {
            return _context.Devices.FirstOrDefault(p => p.DeviceId == id);
        }

        public Device UpdateDevice(Device device)
        {
            //fetch employee first
            var existingDevice = _context.Devices.Find(device.DeviceId);
            if (existingDevice != null)
            {
                //what are you updating
                existingDevice.DeviveName = device.DeviveName;
                existingDevice.Status = device.Status;
                existingDevice.IsActive = device.IsActive;
                existingDevice.CategoryID = device.CategoryID;
                existingDevice.ZoneID = device.ZoneID;
                _context.Update(existingDevice);
                _context.SaveChanges();
            }
            return device;
        }
    }
}
