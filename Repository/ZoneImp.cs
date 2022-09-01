using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Device_Management_System.Interfaces;
using Device_Management_System.Models;
using Device_Management_System.DatabaseContext;
using Device_Management_System.Repository;

namespace Device_Management_System.Repository
{
    public class ZoneImp : IZone
    {
        public readonly DmsDbContext _context;

        public ZoneImp(DmsDbContext context)
        {
            _context = context;
        }


        public void CreateZone(Zone zone)
        {
            throw new NotImplementedException();
        }

        public void DeleteZone(Zone zone)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Device> GetAllDevicesInZone(int zID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Zone> GetAllZones()
        {
            return _context.Zones.ToList();
        }

        public Zone GetZoneById(int id)
        {
            return _context.Zones.FirstOrDefault(p => p.ZoneID == id);
        }

        public void UpdateZone(Zone zone)
        {
            throw new NotImplementedException();
        }

        
    }
}
