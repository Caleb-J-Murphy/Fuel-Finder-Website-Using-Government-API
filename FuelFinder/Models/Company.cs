using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FuelFinder.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        [Required]
        [StringLength(140, ErrorMessage = "The name cannot exceed 140 character in length")]
        [Display(Name = "Campany Name")]
        public string CompanyName { get; set; }
        public virtual ICollection<Outlet> Outlet { get; set; }

        public Company()
        {
            Outlet = new List<Outlet>();
        }

    }
}