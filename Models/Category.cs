using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Device_Management_System.Interfaces;

namespace Device_Management_System.Models
{
    public class Category : TodayDate
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string CategoryDescription { get; set; }

    
    }

    
}
