using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISW_Dashboard.Models;

namespace ISW_Dashboard.Controllers
{
    public class EventDuplicatesController : Controller
    {
        private ISWEntities db = new ISWEntities();

        // GET: EventDuplicates
        public ActionResult Index()
        {
            var exception = new Dictionary<string, string>();
            exception.Add("1", "Duplicate");
            exception.Add("2", "Customer Does not exist");
            exception.Add("", "");
            ViewData["exception"] = exception;
            return View(db.tbl_ISW_Data_duplicate.ToList());
        }

        // GET: EventDuplicates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ISW_Data_duplicate tbl_ISW_Data_duplicate = db.tbl_ISW_Data_duplicate.Find(id);
            if (tbl_ISW_Data_duplicate == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ISW_Data_duplicate);
        }

        // GET: EventDuplicates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventDuplicates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerName,CategoryName,ScheduledDate,ActivityName,MigrationWindow,MigrationGroup,TotalUnits,MigrationDate,SubStatus,Review,Status,UserName,UpdatedDate,completed,inprogress,failed,parent_id,Exception")] tbl_ISW_Data_duplicate tbl_ISW_Data_duplicate)
        {
            if (ModelState.IsValid)
            {
                db.tbl_ISW_Data_duplicate.Add(tbl_ISW_Data_duplicate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_ISW_Data_duplicate);
        }

        // GET: EventDuplicates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ISW_Data_duplicate tbl_ISW_Data_duplicate = db.tbl_ISW_Data_duplicate.Find(id);
            if (tbl_ISW_Data_duplicate == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ISW_Data_duplicate);
        }

        // POST: EventDuplicates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerName,CategoryName,ScheduledDate,ActivityName,MigrationWindow,MigrationGroup,TotalUnits,MigrationDate,SubStatus,Review,Status,UserName,UpdatedDate,completed,inprogress,failed,parent_id,Exception")] tbl_ISW_Data_duplicate tbl_ISW_Data_duplicate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ISW_Data_duplicate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_ISW_Data_duplicate);
        }

        // GET: EventDuplicates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ISW_Data_duplicate tbl_ISW_Data_duplicate = db.tbl_ISW_Data_duplicate.Find(id);
            if (tbl_ISW_Data_duplicate == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ISW_Data_duplicate);
        }

        // POST: EventDuplicates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ISW_Data_duplicate tbl_ISW_Data_duplicate = db.tbl_ISW_Data_duplicate.Find(id);
            db.tbl_ISW_Data_duplicate.Remove(tbl_ISW_Data_duplicate);
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
