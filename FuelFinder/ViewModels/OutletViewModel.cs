using FuelFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuelFinder.ViewModels
{
    public class OutletViewModel
    {

        public Outlet oOutlet { get; set; }
        public List<Record> RecordsP { get; set; }
        public List<Record> RecordsD { get; set; }

        public OutletViewModel(ApplicationDbContext _db, int? OutletID)
        {
            if (OutletID != null)
            {
                oOutlet = _db.Outlets.FirstOrDefault(o => o.OutletID == OutletID);

                //Finds all fuel prices with the fuel type unleaded
                RecordsP = oOutlet.Record.Where(r => r.OutletID == oOutlet.OutletID && r.Fuel.FuelType.Contains("Un")).OrderBy(r => r.TransactionDateTime).ToList();


                //Finds all fuel prices with the fuel type diesel
                RecordsD = oOutlet.Record.Where(r => r.OutletID == oOutlet.OutletID && r.Fuel.FuelType.Contains("Die")).OrderBy(r => r.TransactionDateTime).ToList();

            }


        }

    }
}