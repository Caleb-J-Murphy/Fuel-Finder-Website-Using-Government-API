using FuelFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuelFinder.ViewModels
{
    public class HomeViewModel
    {
        public List<Record> Records { get; set; }

        public List<Outlet> Outlets { get; set; }
        public Record lowestRecord { get; set; }

        public List<Outlet> lstOutlets { get; set; }

        public HomeViewModel(ApplicationDbContext _db)
        {
            //Outlets = new List<Outlet>(); 
            //int numOutletsMap = 600;
            //for (int i = 0; i < numOutletsMap; i++)
            //{
            //    Outlet oOutlet = _db.Outlets.FirstOrDefault(o => o.OutletID == i);
            //    if (!Outlets.Any(o => o.OutletID == oOutlet.OutletID))
            //    {
            //        Outlets.Add(oOutlet);
            //    }
            //    else
            //    {
            //        numOutletsMap++;
            //    }
            //}
            Outlets = _db.Outlets.Take(600).Distinct().ToList();
            Records = new List<Record>();
            Records = _db.Records.ToList();

            lowestRecord = _db.Records.FirstOrDefault(r => r.RecordID == 0);

            lstOutlets = new List<Outlet>();

            foreach (var m in Outlets)
            {
                lstOutlets.Add(new Outlet
                {
                    OutletName = m.OutletName,
                    Latitude = m.Latitude,
                    Longitude = m.Longitude
                });
            }

        }

    }
}