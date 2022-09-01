using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Device_Management_System.Interfaces;


namespace Device_Management_System.Models
{
    public class Zone : TodayDate
    {
        [Key]
        public int ZoneID {get;set;}

        [Required]
        public string ZoneName { get; set; }

        public string ZoneDescription { get; set; }

        
    }

    
}
