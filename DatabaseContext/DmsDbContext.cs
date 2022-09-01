using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Device_Management_System.Models;

namespace Device_Management_System.DatabaseContext
{
    public class DmsDbContext : DbContext
    {

        public DmsDbContext(DbContextOptions<DmsDbContext> options) : base(options)
        {

        }

        //create table the tables
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Category> Categories { get; set;}
        public DbSet<Device> Devices { get; set; }




    }
}
