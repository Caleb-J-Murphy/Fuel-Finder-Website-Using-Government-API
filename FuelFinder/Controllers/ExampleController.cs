using FuelFinder.Models;
using FuelFinder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FuelFinder.Controllers
{
    public class ExampleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Example
        public ActionResult Index()
        {
            FeatureViewModel featureViewModel = new FeatureViewModel(db);

            return View(featureViewModel);
        }

        public ActionResult Browse(string search, int? dropdown)
        {
            List<Record> lstRecord = new List<Record>();

            if(search != null)
            {
                lstRecord = db.Records.Where(r => r.Outlet.OutletName.Contains(search)).ToList(); //Contains(search)
            }
            else
            {
                lstRecord = db.Records.ToList();
            }

            if(dropdown != null)
            {
                if(!lstRecord.Any(r => r.RecordID == dropdown))
                {
                    Record oRecord = db.Records.FirstOrDefault(r => r.Outlet.OutletID == dropdown);

                    lstRecord.Add(oRecord);
                }
            }

            return View(lstRecord.OrderBy(r => r.Price));
        }
    }
}