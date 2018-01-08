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
    public class VPNTrackerController : Controller
    {
        private ISWEntities db = new ISWEntities();

        // GET: VPNTracker
        public ActionResult Index()
        {
            var status = new Dictionary<string, string>();
            status.Add("1", "Not Started");
            status.Add("2", "In Progress");
            status.Add("3", "Blocked");
            status.Add("4", "Completed");
            status.Add("5", "Finished");
            status.Add("0", "");
            status.Add("", "");
            ViewData["Status"] = status;
            IEnumerable<ISW_Dashboard.Models.ProjectVPN> projectVPN = db.ProjectVPNs.Where(v => v.status !="5").ToList();
            return View(projectVPN.ToList());
        }

        // GET: VPNTracker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectVPN projectVPN = db.ProjectVPNs.Find(id);
            if (projectVPN == null)
            {
                return HttpNotFound();
            }
            return View(projectVPN);
        }

        // GET: VPNTracker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VPNTracker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,projectname,customername,projectdetail,projectowner,currentsummary,nextsteps,status")] ProjectVPN projectVPN)
        {
            if (ModelState.IsValid)
            {
                projectVPN.updatedDate = DateTime.Now;
                projectVPN.updatedby = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.LastIndexOf("\\") + 1); 
                db.ProjectVPNs.Add(projectVPN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectVPN);
        }

        // GET: VPNTracker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectVPN projectVPN = db.ProjectVPNs.Find(id);
            if (projectVPN == null)
            {
                return HttpNotFound();
            }
            return View(projectVPN);
        }

        // POST: VPNTracker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,projectname,customername,projectdetail,projectowner,currentsummary,nextsteps,status")] ProjectVPN projectVPN)
        {
            if (ModelState.IsValid)
            {
                projectVPN.updatedDate = DateTime.Now;
                projectVPN.updatedby = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.LastIndexOf("\\") + 1); ;
                db.Entry(projectVPN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectVPN);
        }

        // GET: VPNTracker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectVPN projectVPN = db.ProjectVPNs.Find(id);
            if (projectVPN == null)
            {
                return HttpNotFound();
            }
            return View(projectVPN);
        }

        // POST: VPNTracker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectVPN projectVPN = db.ProjectVPNs.Find(id);
            db.ProjectVPNs.Remove(projectVPN);
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
