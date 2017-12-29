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
    public class EventController : Controller
    {
        private ISWEntities db = new ISWEntities();

        // GET: Event
        public ActionResult Index()
        {
            var subStatus = new Dictionary<string, string>();
            subStatus.Add("1", "PF-Started");
            subStatus.Add("2", "PF-InProgress");
            subStatus.Add("3", "PF-Completed");
            subStatus.Add("4", "KickoffEmailSent");
            subStatus.Add("5", "Job-Started");
            subStatus.Add("6", "M-InProgress");
            subStatus.Add("7", "M-StatusEmailSent");
            subStatus.Add("8", "M-Completed");
            subStatus.Add("9", "M-PBUploaded");
            subStatus.Add("", "");
            subStatus.Add("0", "");
            ViewData["subStatus"] = subStatus;
            var status = new Dictionary<string, string>();
            status.Add("1", "Started");
            status.Add("2", "Assigned");
            status.Add("3", "Completed");
            status.Add("", "");
            status.Add("0", "");
            ViewData["Status"] = status;
            return View(db.tbl_ISW_Data.ToList());
        }

        // GET: Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ISW_Data tbl_ISW_Data = db.tbl_ISW_Data.Find(id);
            if (tbl_ISW_Data == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ISW_Data);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerName,CategoryName,ScheduledDate,ActivityName,MigrationWindow,MigrationGroup,TotalUnits,MigrationDate,SubStatus,Review,Status,UserName,UpdatedDate")] tbl_ISW_Data tbl_ISW_Data)
        {
            if (ModelState.IsValid)
            {
                db.tbl_ISW_Data.Add(tbl_ISW_Data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_ISW_Data);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ISW_Data tbl_ISW_Data = db.tbl_ISW_Data.Find(id);
            if (tbl_ISW_Data == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ISW_Data);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerName,CategoryName,ScheduledDate,ActivityName,MigrationWindow,MigrationGroup,TotalUnits,MigrationDate,SubStatus,Review,Status,UserName,UpdatedDate,completed,inprogress,failed")] tbl_ISW_Data tbl_ISW_Data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tbl_ISW_Data).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                }

        }
            return View(tbl_ISW_Data);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ISW_Data tbl_ISW_Data = db.tbl_ISW_Data.Find(id);
            if (tbl_ISW_Data == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ISW_Data);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ISW_Data tbl_ISW_Data = db.tbl_ISW_Data.Find(id);
            db.tbl_ISW_Data.Remove(tbl_ISW_Data);
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
