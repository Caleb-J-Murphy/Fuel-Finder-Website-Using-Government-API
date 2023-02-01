using FuelFinder.ViewModels;
using FuelFinder.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FuelFinder.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel(db);

            List<Outlet> lstOutlets = new List<Outlet>();

            

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Get: Upload
        [Authorize(Roles = "Admin")] //Only allow admin to access webpage
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload (UploadViewModel _upload)
        {
            //Fail to upload?
            if(_upload.UploadFile == null)
            {
                return HttpNotFound();
            }

            //Createa a file name and path
            string sFileName = Path.GetFileName(_upload.UploadFile.FileName);
            string sPath = Path.Combine(Server.MapPath("~/Content/Upload"), sFileName);

            //Save the file to the server
            _upload.UploadFile.SaveAs(sPath);

            _upload.DeleteAllRecords(db); 

            //Execute the ReadCSVToDB method
            _upload.ReadCSVDataToDB(sPath, db);

            //Redirectthe user to the home index
            return RedirectToAction("Index");
        }
    }
}