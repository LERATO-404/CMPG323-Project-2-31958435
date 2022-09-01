using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Device_Management_System.Interfaces;
using Device_Management_System.Models;

namespace Device_Management_System.Repository
{
    public class DeviceImp : IDevice
    {
        //Before editing/deleting
        private bool CheckIfDeviceExist(int id)
        {
            throw new NotImplementedException();
        }
        public void CreateDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public void DeleteDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Device> GetAllDevices()
        {
            throw new NotImplementedException();
        }

        public Zone GetDeviceById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDevice(Device device)
        {
            throw new NotImplementedException();
        }
    }
}
