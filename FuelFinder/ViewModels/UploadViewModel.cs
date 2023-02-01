using FuelFinder.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FuelFinder.ViewModels
{
    public class UploadViewModel
    {
        public HttpPostedFileBase UploadFile { get; set; }
        
        public void ReadCSVDataToDB (string _fileLocation, ApplicationDbContext _db)
        {
            // Logic for reading the fuel database upon upload

            //Store each record as an index in the array
            string[] arrRecords = File.ReadAllLines(_fileLocation);

            int i = 0; //Batch Counter

            //Go through each row, but skip the header
            foreach(var row in arrRecords.Skip(1))
            {
                //Break the row into columns
                string[] arrFuelDetails = Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                //Record is the main entity
                string sOutletID = arrFuelDetails[0];
                string sOutletName = arrFuelDetails[1];
                string sCompanyName = arrFuelDetails[2];
                string sOutletAddress = arrFuelDetails[3];
                string sSuburbName = arrFuelDetails[4];
                string sStateName = arrFuelDetails[5];
                string sPostCode = arrFuelDetails[6];
                string sLatitude = arrFuelDetails[7];
                string sLongitude = arrFuelDetails[8];
                string sFuelType = arrFuelDetails[9];
                string sPrice = arrFuelDetails[10];
                DateTime dtTransactionDateTime = Convert.ToDateTime(arrFuelDetails[11]);
           
                //Finds a compnay containing the sCompanyName in the database.
                Company oCompany = _db.Companys.FirstOrDefault(o => o.CompanyName == sCompanyName);

                //If there isnt a company with that name, then create another company.
                if(oCompany == null)
                {
                    oCompany = new Company();
                    oCompany.CompanyName = sCompanyName;

                    _db.Companys.Add(oCompany);
                    _db.SaveChanges();
                }

                //Same as the company but for the state.
                State oState = _db.States.FirstOrDefault(o => o.StateName == sStateName);

                if (oState == null)
                {
                    oState = new State();
                    oState.StateName = sStateName;

                    _db.States.Add(oState);
                    _db.SaveChanges();
                }

                //Same as the company but for the state.
                Suburb oSuburb = _db.Suburbs.FirstOrDefault(o => o.SuburbName == sSuburbName);

                if (oSuburb == null)
                {
                    oSuburb = new Suburb();
                    oSuburb.SuburbName = sSuburbName;
                    oSuburb.PostCode = Convert.ToInt32(sPostCode);

                    oSuburb.StateID = oState.StateID;

                    _db.Suburbs.Add(oSuburb);
                    _db.SaveChanges();

                    oState.Suburb.Add(oSuburb);
                }

                //Same as the company but for the state.
                Fuel oFuel = _db.Fuels.FirstOrDefault(o => o.FuelType == sFuelType);

                if (oFuel == null)
                {
                    oFuel = new Fuel();
                    oFuel.FuelType = sFuelType;

                    _db.Fuels.Add(oFuel);
                    _db.SaveChanges();
                }

                //Same as the company but for the state.
                Outlet oOutlet = _db.Outlets.FirstOrDefault(o => o.OutletName == sOutletName);

                if (oOutlet == null)
                {
                    oOutlet = new Outlet();
                    oOutlet.OutletName = sOutletName;
                    oOutlet.Address = sOutletAddress;
                    oOutlet.Latitude = Convert.ToDouble(sLatitude);
                    oOutlet.Longitude = Convert.ToDouble(sLongitude);

                    //Links the outlet to the company through a foreign key
                    oOutlet.CompanyID = oCompany.CompanyID;
                    oOutlet.SuburbID = oSuburb.SuburbID;

                    oOutlet.Company = oCompany;
                    oOutlet.Suburb = oSuburb;

                    _db.Outlets.Add(oOutlet);
                    _db.SaveChanges();

                    oCompany.Outlet.Add(oOutlet);
                    oSuburb.Outlet.Add(oOutlet);
                }
                
                //As each record is assumed to be unique, no measures are used to check for duplicates.
                Record oRecord = new Record();
                oRecord.Price = Convert.ToInt32(sPrice);
                oRecord.TransactionDateTime = dtTransactionDateTime;

                oRecord.FuelID = oFuel.FuelID;
                oRecord.OutletID = oOutlet.OutletID;

                _db.Records.Add(oRecord);
                _db.SaveChanges();

                oFuel.Record.Add(oRecord);
                oOutlet.Record.Add(oRecord);
                
                //Batching logic for efficiency
                if (i % 100 == 0)
                {
                    _db.Dispose();
                    _db = new ApplicationDbContext();
                }

                i++;

            }

            _db.SaveChanges();
        }

        public void DeleteAllRecords(ApplicationDbContext _db)
        {
            //Delete All Records
            _db.Records.RemoveRange(_db.Records);
            _db.SaveChanges();
            _db.Outlets.RemoveRange(_db.Outlets);
            _db.SaveChanges();
            _db.Companys.RemoveRange(_db.Companys);
            _db.SaveChanges();
            _db.Suburbs.RemoveRange(_db.Suburbs);
            _db.SaveChanges();
            _db.States.RemoveRange(_db.States);
            _db.SaveChanges();
            _db.Fuels.RemoveRange(_db.Fuels);
            _db.SaveChanges();

            //Reset all autoincrement values
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Company', RESEED, 0)");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Suburb', RESEED, 0)");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('State', RESEED, 0)");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Fuel', RESEED, 0)");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Outlet', RESEED, 0)");
            _db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Record', RESEED, 0)");

            _db.SaveChanges();
        }
    }
}