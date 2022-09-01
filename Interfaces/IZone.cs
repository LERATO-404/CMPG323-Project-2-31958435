using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Device_Management_System.Models;

namespace Device_Management_System.Interfaces
{
    public interface IZone
    {
        IEnumerable<Zone> GetAllZones();
        //Or
        //List<Zone> GetAllZones();
        Zone GetZoneById(int id);

        Zone CreateZone(Zone zone);

        Zone UpdateZone(Zone zone);

        void DeleteZone(Zone zone);

        IEnumerable<Device> GetAllDevicesInZone(int id);
    }
}
