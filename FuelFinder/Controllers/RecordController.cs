using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FuelFinder.Models;

namespace FuelFinder.Controllers
{
    public class RecordController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Record
        public ActionResult Index()
        {
            var records = db.Records.Include(r => r.Fuel).Include(r => r.Outlet);
            return View(records.ToList());
        }

        // GET: Record/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // GET: Record/Create
        public ActionResult Create()
        {
            ViewBag.FuelID = new SelectList(db.Fuels, "FuelID", "FuelType");
            ViewBag.OutletID = new SelectList(db.Outlets, "OutletID", "OutletName");
            ViewBag.CompanyID = new SelectList(db.Companys, "CompanyID", "CompanyName");
            ViewBag.SuburbID = new SelectList(db.Suburbs, "SuburbID", "SuburbName");
            return View();
        }

        // POST: Record/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordID,Price,TransactionDateTime,OutletID,FuelID")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Records.Add(record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuelID = new SelectList(db.Fuels, "FuelID", "FuelType", record.FuelID);
            ViewBag.OutletID = new SelectList(db.Outlets, "OutletID", "OutletName", record.OutletID);
            return View(record);
        }

        // GET: Record/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuelID = new SelectList(db.Fuels, "FuelID", "FuelType", record.FuelID);
            ViewBag.OutletID = new SelectList(db.Outlets, "OutletID", "OutletName", record.OutletID);
            return View(record);
        }

        // POST: Record/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordID,Price,TransactionDateTime,OutletID,FuelID")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuelID = new SelectList(db.Fuels, "FuelID", "FuelType", record.FuelID);
            ViewBag.OutletID = new SelectList(db.Outlets, "OutletID", "OutletName", record.OutletID);
            return View(record);
        }

        // GET: Record/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Record/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = db.Records.Find(id);
            db.Records.Remove(record);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
