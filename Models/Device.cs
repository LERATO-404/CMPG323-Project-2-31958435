using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Device_Management_System.Models
{
    public class Device
    {
        [Key]
        public int DeviceId { get; set; }

        public string DeviveName { get; set; }

        public string Status { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        //Relationships

        [Required]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        [Required]
        public int ZoneID { get; set; }
        [ForeignKey("ZoneID")]
        public Zone Zone { get; set; }



    }
}
