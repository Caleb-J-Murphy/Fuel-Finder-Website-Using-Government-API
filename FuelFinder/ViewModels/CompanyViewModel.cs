using FuelFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuelFinder.ViewModels
{
    public class CompanyViewModel
    {
        public Company oCompany { get; set; }
        public List<Outlet> Outlets { get; set; }
        public List<Record> Records { get; set; }
        public List<Record> lstChartRecords { get; set; }


        public CompanyViewModel(ApplicationDbContext _db, int? companyID)
        {
            if(companyID != null)
            {
                oCompany = _db.Companys.FirstOrDefault(c => c.CompanyID == companyID);

                Outlets = oCompany.Outlet.Where(o => o.CompanyID == oCompany.CompanyID).ToList();

                foreach(var outlet in Outlets)
                {
                    //Finds all records of the outlet with a record for undleaded
                    Records = outlet.Record.Where(r => r.OutletID == outlet.OutletID && r.Fuel.FuelType.Contains("Un")).OrderBy(r => r.TransactionDateTime).ToList();
                }
            }
        }
    }
}