using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISW_Dashboard.Models;
using PagedList;


namespace ISW_Dashboard.Controllers
{
    public class TActivitiesEventDataController : Controller
    {
        private ISWEntities db = new ISWEntities();

        // GET: EventData
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var kstatus = new Dictionary<string, string>();
            kstatus.Add("1", "Sent");
            kstatus.Add("2", "Delayed");
            kstatus.Add("3", "Canceled");
            kstatus.Add("4", "Rescheduled");
            kstatus.Add("", "");
            kstatus.Add("0", "");
            ViewData["KStatus"] = kstatus;

            var estatus = new Dictionary<string, string>();
            estatus.Add("1", "Assigned");
            estatus.Add("2", "Completed");
            estatus.Add("3", "Customer Cancelled");
            // estatus.Add("4", "Outflow");
            estatus.Add("4", "Started");
            // estatus.Add("6", "Task Cancelled");
            //   estatus.Add("7", "Transferred");
            estatus.Add("5", "Unassigned");
            estatus.Add("", "");
            estatus.Add("0", "");
            ViewData["EStatus"] = estatus;
            IEnumerable<ISW_Dashboard.Models.tbl_ISW_Data> eventData = db.tbl_ISW_Data.Where((v => (v.CategoryName == "T- Activities" || v.CategoryName == "Pre and Post Activities") && (v.EventStatus != 2 && v.EventStatus != 3))).ToList();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                //eventData = eventData.Where(s => s.CustomerName.ToUpper().Contains(searchString.ToUpper().Trim()));
                //eventData = eventData.Where(s => s.CustomerName.ToUpper().Contains(searchString.ToUpper().Trim()) ||
                //                            s.AssignBy.Replace("(","").Replace(")","").Contains(searchString.ToUpper().Trim())
                //                                );
                //eventData = eventData.Where(s => s.CustomerName.ToUpper().Contains(searchString.ToUpper().Trim()) ||
                //                           s.AssignBy.Replace("(", "").Replace(")", "").Contains(searchString.ToUpper().Trim())
                //                               );
                eventData = eventData.Where(s => (!string.IsNullOrEmpty(s.CustomerName) && s.CustomerName.ToUpper().Contains(searchString.ToUpper().Trim())) ||
                                          (!string.IsNullOrEmpty(s.AssignBy) && s.AssignBy.ToUpper().Contains(searchString.ToUpper().Trim())) ||
                                           (!string.IsNullOrEmpty(s.MigratorName) && s.MigratorName.ToUpper().Contains(searchString.ToUpper().Trim())) ||
                                           (!string.IsNullOrEmpty(s.CategoryName) && s.CategoryName.ToUpper().Contains(searchString.ToUpper().Trim()))
                                           || (!string.IsNullOrEmpty(s.updatedby) && s.updatedby.ToUpper().Contains(searchString.ToUpper().Trim()))
                                               );

                //     eventData =
                //from events in eventData
                //where SqlMethods.Like(events.AssignBy, "%John%")
                //select events;
            }
            var CategoryNamesList = eventData.Select(p => p.CategoryName)
                   .Distinct().ToList();

            var CategoryNames = CategoryNamesList.Select(x => new SelectListItem { Text = x, Value = x })
                  .Distinct().ToList();
            if (Request["SerchbyCategoryNames"] == null)
            {
                ViewData["SelectedCategoryNames"] = "ALL";
            }
            else
            {
                ViewData["SelectedCategoryNames"] = Request["SerchbyCategoryNames"];
                if (ViewData["SelectedCategoryNames"].ToString().ToUpper().Trim() != "ALL")
                    eventData = eventData.Where(s => (!string.IsNullOrEmpty(s.CategoryName) && s.CategoryName.ToUpper().Contains(ViewData["SelectedCategoryNames"].ToString().ToUpper().Trim())));
            }
            CategoryNames.Insert(0, new SelectListItem { Text = "ALL", Value = "ALL" });

            //List<SelectListItem> items = new List<SelectListItem>();
            ViewData["CategoryNames"] = CategoryNames.ToList();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            ViewData["eventCount"] = eventData.Count();

            ViewBag.CurrentFilter = searchString;

            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(eventData.OrderByDescending(x => x.updateddate).ToPagedList(pageNumber, pageSize));
        }

        // GET: EventData/Details/5
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

        // GET: EventData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerName,CategoryName,MigrationType,MigrationWindow,MigrationGroup,ExpectedKickOff,MigratorName,PeerReviewer,DMName,LastKickOffEmailSent,KickOffStatus,ScheduleCount,SuccessCount,InProgressCount,FailedCount,CurrentPowerBICount,PreviousPowerBICount,EventStatus,UpdateStatus,LastUpdateEmailSent,CurrentSummary,CommentsForDelayKickOff,NextUpdateTime,ScheduledDate,ActivityName,updatedby,updateddate,MigrationApplied,KBUsed,Effort,PowerBIUpdated")] tbl_ISW_Data tbl_ISW_Data)
        {
            if (ModelState.IsValid)
            {
                db.tbl_ISW_Data.Add(tbl_ISW_Data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_ISW_Data);
        }

        // GET: EventData/Edit/5
        public ActionResult Edit(int? id)
        {
            var kstatus = new Dictionary<string, string>();
            kstatus.Add("0", "Please select");
            kstatus.Add("1", "Sent");
            kstatus.Add("2", "Delayed");
            kstatus.Add("3", "Canceled");
            kstatus.Add("4", "Rescheduled");


            ViewData["KStatus"] = kstatus;

            var estatus = new Dictionary<string, string>();

            estatus.Add("1", "Assigned");
            estatus.Add("2", "Completed");
            estatus.Add("3", "Customer Cancelled");
            // estatus.Add("4", "Outflow");
            estatus.Add("4", "Started");
            // estatus.Add("6", "Task Cancelled");
            //   estatus.Add("7", "Transferred");
            estatus.Add("5", "Unassigned ");



            ViewData["EStatus"] = estatus;

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

        // POST: EventData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerName,CategoryName,MigrationType,MigrationWindow,MigrationGroup,ExpectedKickOff,MigratorName,PeerReviewer,DMName,LastKickOffEmailSent,KickOffStatus,ScheduleCount,SuccessCount,InProgressCount,FailedCount,CurrentPowerBICount,PreviousPowerBICount,EventStatus,UpdateStatus,LastUpdateEmailSent,CurrentSummary,CommentsForDelayKickOff,NextUpdateTime,ScheduledDate,ActivityName,updatedby,updateddate,MigrationApplied,KBUsed,Effort,PowerBIUpdated,AssignBy,AssignDate,transferredDate,migrationCompleted,unitId")] tbl_ISW_Data tbl_ISW_Data)
        {
            var kstatus = new Dictionary<string, string>();
            kstatus.Add("0", "Please select");
            kstatus.Add("1", "Sent");
            kstatus.Add("2", "Delayed");
            kstatus.Add("3", "Canceled");
            kstatus.Add("4", "Rescheduled");


            ViewData["KStatus"] = kstatus;

            var estatus = new Dictionary<string, string>();
            estatus.Add("1", "Assigned");
            estatus.Add("2", "Completed");
            estatus.Add("3", "Customer Cancelled");
            // estatus.Add("4", "Outflow");
            estatus.Add("4", "Started");
            // estatus.Add("6", "Task Cancelled");
            //   estatus.Add("7", "Transferred");
            estatus.Add("5", "Unassigned ");
            estatus.Add("", "");
            estatus.Add("0", "");

            ViewData["EStatus"] = estatus;
            if (tbl_ISW_Data.PowerBIUpdated == true && tbl_ISW_Data.InProgressCount == 0)
            {
                ModelState.AddModelError("powerBIerror", "Inprogress count should be zero");

            }
            if (tbl_ISW_Data.ScheduleCount != tbl_ISW_Data.FailedCount + tbl_ISW_Data.SuccessCount + tbl_ISW_Data.InProgressCount)
            {
                ModelState.AddModelError("ScheduleCountError", "Schedule Count should be equals to sum of SuccessCount,FailedCount,InProgressCount");

            }

            if (ModelState.IsValid)
            {
                tbl_ISW_Data.updateddate = DateTime.Now;
                tbl_ISW_Data.updatedby = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.LastIndexOf("\\") + 1); ;
                db.Entry(tbl_ISW_Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_ISW_Data);
        }

        // GET: EventData/Delete/5
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

        // POST: EventData/Delete/5
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
