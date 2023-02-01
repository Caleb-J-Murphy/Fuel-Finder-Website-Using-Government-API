using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FuelFinder.Models
{
    public class State
    {
        public int StateID { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "The State must be a 3 letter abbreviation i.e. Queensland = QLD")]
        [Display(Name = "State - Abbreviation")]
        public string StateName { get; set; }
        public virtual ICollection<Suburb> Suburb { get; set; }
    }
}