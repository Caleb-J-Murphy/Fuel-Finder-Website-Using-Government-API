using FuelFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuelFinder.ViewModels
{
    public class FeatureViewModel
    {
        public List<Record> Records { get; set; }
        public List<Outlet> Outlets { get; set; }

        public List<string> lstOutlets { get; set; }
        public List<int> lstAvPrice { get; set; }

        //Constructor - i.e. excecuted when new FeatueredViewModel(db) is called
        public FeatureViewModel(ApplicationDbContext _db)
        {
            Random rand = new Random();

            Records = new List<Record>();

            for (int i = 0; i < 1000; i++)
            {
                int iRandom = rand.Next(1, _db.Records.Count());

                Record oRecord = _db.Records.FirstOrDefault(o => o.RecordID == iRandom);

                if (!Records.Any(r => r.RecordID == oRecord.RecordID))
                {
                    Records.Add(oRecord);
                }
                else
                {
                    i--;
                }
            }


            //Calling the function that gathers data for the chart.
            SetupChartData();
        }

        public void SetupChartData()
        {
            //Get the average price for each outlet
            lstOutlets = Records.Select(m => m.Outlet.OutletName).Distinct().ToList();

            lstAvPrice = Records.Select(m => m.Price).ToList();
        }
    }
}