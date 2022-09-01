using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Device_Management_System.Models
{
    public class Zone
    {
        [Key]
        public int ZoneID {get;set;}

        [Required]
        public string ZoneName { get; set; }

        public string ZoneDescription { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
