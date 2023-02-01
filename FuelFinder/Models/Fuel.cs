using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FuelFinder.Models
{
    public class Fuel
    {
        public int FuelID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The fuel type cannot exceed 50 character in length")]
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }
        public virtual ICollection<Record> Record { get; set; }

    }
}