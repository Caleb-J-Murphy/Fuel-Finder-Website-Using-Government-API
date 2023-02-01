using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FuelFinder.Models
{
    public class Suburb
    {
        public int SuburbID { get; set; }
        [Required]
        [StringLength(140, ErrorMessage = "The name cannot exceed 140 character in length")]
        [Display(Name = "Suburb")]
        public string SuburbName { get; set; }
        [Range(0000, 9999, ErrorMessage = "The PostCode must be a four digit positive number")]
        public int PostCode { get; set; }
        public int StateID { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Outlet> Outlet { get; set; }

    }
}