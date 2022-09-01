using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Device_Management_System.Models;

namespace Device_Management_System.Interfaces
{
    public interface IDevice
    {
        IEnumerable<Device> GetAllDevices();
        //Or
        //List<Zone> GetAllZones();

        Zone GetDeviceById(int id);

        void CreateDevice(Device device);

        void UpdateDevice(Device device);

        void DeleteDevice(Device device);
    }
}
