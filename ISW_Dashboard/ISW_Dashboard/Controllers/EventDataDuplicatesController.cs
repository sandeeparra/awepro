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
    public class EventDataDuplicatesController : Controller
    {
        private ISWEntities db = new ISWEntities();

        // GET: EventDataDuplicates
        public ActionResult Index()
        {
            var estatus = new Dictionary<string, string>();
            estatus.Add("1", "Duplicate ");
            estatus.Add("2", "Customer Does not exist");
            
            estatus.Add("", "");
            estatus.Add("0", "");
            ViewData["EStatus"] = estatus;
            return View(db.tbl_ISW_Data_duplicate.ToList());
        }

        // GET: EventDataDuplicates/Details/5
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

        // GET: EventDataDuplicates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventDataDuplicates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerName,CategoryName,MigrationType,MigrationWindow,MigrationGroup,ExpectedKickOff,MigratorName,PeerReviewer,DMName,LastKickOffEmailSent,ScheduleCount,SuccessCount,InProgressCount,FailedCount,CurrentPowerBICount,PreviousPowerBICount,LastUpdateEmailSent,CurrentSummary,CommentsForDelayKickOff,NextUpdateTime,Exception,ScheduledDate,ActivityName,updatedby,updateddate,MigrationApplied,KBUsed,Effort,PowerBIUpdated,parent_id,KickOffStatus,EventStatus,UpdateStatus")] tbl_ISW_Data_duplicate tbl_ISW_Data_duplicate)
        {
            if (ModelState.IsValid)
            {
                db.tbl_ISW_Data_duplicate.Add(tbl_ISW_Data_duplicate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_ISW_Data_duplicate);
        }

        // GET: EventDataDuplicates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estatus = new Dictionary<string, string>();
            estatus.Add("1", "Duplicate ");
            estatus.Add("2", "Customer Does not exist");

            ViewData["EStatus"] = estatus;
            tbl_ISW_Data_duplicate tbl_ISW_Data_duplicate = db.tbl_ISW_Data_duplicate.Find(id);
            if (tbl_ISW_Data_duplicate == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ISW_Data_duplicate);
        }

        // POST: EventDataDuplicates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerName,CategoryName,MigrationType,MigrationWindow,MigrationGroup,ExpectedKickOff,MigratorName,PeerReviewer,DMName,LastKickOffEmailSent,ScheduleCount,SuccessCount,InProgressCount,FailedCount,CurrentPowerBICount,PreviousPowerBICount,LastUpdateEmailSent,CurrentSummary,CommentsForDelayKickOff,NextUpdateTime,Exception,ScheduledDate,ActivityName,updatedby,updateddate,MigrationApplied,KBUsed,Effort,PowerBIUpdated,parent_id,KickOffStatus,EventStatus,UpdateStatus")] tbl_ISW_Data_duplicate tbl_ISW_Data_duplicate)
        {
            if (ModelState.IsValid)
            {
                tbl_ISW_Data_duplicate.updateddate = DateTime.Now;
                tbl_ISW_Data_duplicate.updatedby = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.LastIndexOf("\\") + 1); ;
                db.Entry(tbl_ISW_Data_duplicate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_ISW_Data_duplicate);
        }

        // GET: EventDataDuplicates/Delete/5
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

        // POST: EventDataDuplicates/Delete/5
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
