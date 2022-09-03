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


        public Zone CreateZone(Zone zone)
        {
            _context.Zones.Add(zone);
            _context.SaveChanges();
            return zone;
        }

        public void DeleteZone(Zone zone)
        {
            _context.Zones.Remove(zone);
            _context.SaveChanges();
        }

        public IEnumerable<Device> GetAllDevicesInZone(int zID)
        {
            var devices = _context.Devices.Where(d => d.ZoneID == zID).ToList();
            return devices;
        }

        public IEnumerable<Zone> GetAllZones()
        {
            return _context.Zones.ToList();
        }

        public Zone GetZoneById(int id)
        {
            return _context.Zones.FirstOrDefault(p => p.ZoneID == id);
        }

        public Zone UpdateZone(Zone zone)
        {
            //fetch employee first
            var existingZone = _context.Zones.Find(zone.ZoneID);
            if (existingZone != null)
            {
                //what are you updating
                existingZone.ZoneName = zone.ZoneName;
                existingZone.ZoneDescription = zone.ZoneDescription;
                _context.Update(existingZone);
                _context.SaveChanges();
            }
            return zone;
        }

        
    }
}
