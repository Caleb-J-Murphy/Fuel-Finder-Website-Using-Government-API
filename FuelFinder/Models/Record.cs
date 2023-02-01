using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FuelFinder.Models
{
    public class Record
    {
        public int RecordID { get; set; }
        [Required]
        [Range(0, 99999, ErrorMessage = "The price cannot be negative or exceed 99999")]
        public int Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime TransactionDateTime { get; set; }
        public int OutletID { get; set; }
        public virtual Outlet Outlet { get; set; }
        public int FuelID { get; set; }
        public virtual Fuel Fuel { get; set; }
    }
}