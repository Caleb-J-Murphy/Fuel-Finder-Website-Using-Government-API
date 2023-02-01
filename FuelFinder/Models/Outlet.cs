using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FuelFinder.Models
{
    public class Outlet
    {
        public int OutletID { get; set; }
        [Required]
        [StringLength(140, ErrorMessage = "The name cannot exceed 140 character in length")]
        [Display(Name = "Fuel Outlet Title")]
        public string OutletName { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public int SuburbID { get; set; }
        public virtual Suburb Suburb { get; set; }
        public virtual ICollection<Record> Record { get; set; }


    }
}