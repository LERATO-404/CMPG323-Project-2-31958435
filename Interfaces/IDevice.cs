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

        Device GetDeviceById(int id);

        Device CreateDevice(Device device);

        Device UpdateDevice(Device device);

        void DeleteDevice(Device device);
    }
}
