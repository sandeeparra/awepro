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
    public class CustomerController : Controller
    {
        private ISWEntities db = new ISWEntities();

        // GET: Customer
        public ActionResult Index()
        {
            //var MigrationType = new Dictionary<string, string>();
            //MigrationType.Add("1", "E2E to O365");
            //MigrationType.Add("2", "GDrive to O365");
            //MigrationType.Add("3", "N2E to O365");
            //MigrationType.Add("4", "OD4B");           
            //MigrationType.Add("5", "GDrive");
            //MigrationType.Add("6", "Box to OD4B");
            //MigrationType.Add("7", "FS to OD4B");
            //MigrationType.Add("8", "O365 MT Exchange Hybrid");
            //MigrationType.Add("9", "O365 MT Notes");
            //MigrationType.Add("10", "O365 MT OD4B");
            //MigrationType.Add("11", "O365 MT IMAP");
            //MigrationType.Add("12", "FS to Team Sites");
            //MigrationType.Add("13", "IMAP");
            //MigrationType.Add("14", "Exchange - Hybrid");
            //MigrationType.Add("15", "O365 MT Gdrive");
            //MigrationType.Add("16", "O365 MT Exchange Cutover");
            //MigrationType.Add("17", "FS to O365");


           
            // ViewData["MigrationType"] = MigrationType;
            // Dictionary < int, List<People> myDictionary = items.ToDictionary(p => p.Age, p => People);
            Dictionary < string, string> MigrationType = db.MigrationTypes.ToDictionary(p => p.ID.ToString(), p => p.name);
            MigrationType.Add("0", "");
            MigrationType.Add("", "");
            ViewData["MigrationType"] = MigrationType;
           
            var flag = new Dictionary<string, string>();
            flag.Add("1", "Yes");
            flag.Add("0", "No");
            flag.Add("True", "Yes");
            flag.Add("False", "No");
            flag.Add("", "");
            ViewData["flag"] = flag;
            
            var state = new Dictionary<string, string>();
            state.Add("1", "Approved");
            state.Add("2", "Need review");
            state.Add("", "");
            
            ViewData["state"] = state;
            return View(db.Customers.ToList());
           
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Dictionary<string, string> MigrationType = db.MigrationTypes.ToDictionary(p => p.ID.ToString(), p => p.name);

            ViewData["MigrationType"] = MigrationType;
            var flag = new Dictionary<string, string>();
            flag.Add("1", "Yes");
            flag.Add("0", "No");
            flag.Add("True", "Yes");
            flag.Add("False", "No");
            flag.Add("", "");
            ViewData["flag"] = flag;

            var state = new Dictionary<string, string>();
            state.Add("1", "Approved");
            state.Add("2", "Need review");
            state.Add("", "");

            ViewData["state"] = state;
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MigrationType,AssignedDate,UnassignedDate,HVC,Exception,ExceptionDetail,state,Name")] Customer customer)
        {
            Dictionary<string, string> MigrationType = db.MigrationTypes.ToDictionary(p => p.ID.ToString(), p => p.name);
            
            ViewData["MigrationType"] = MigrationType;
            var flag = new Dictionary<string, string>();
            flag.Add("1", "Yes");
            flag.Add("0", "No");
            flag.Add("True", "Yes");
            flag.Add("False", "No");
            flag.Add("", "");
            ViewData["flag"] = flag;

            var state = new Dictionary<string, string>();
            state.Add("1", "Approved");
            state.Add("2", "Need review");
            state.Add("", "");

            ViewData["state"] = state;
            var foo = db.Customers.Any(c => c.Name.ToUpper().Trim() == customer.Name.ToUpper().Trim() && c.UnassignedDate ==null);
            if(foo )
            {
                ModelState.AddModelError("recordexisit", "customer name exist with empty unassigned date ");

            }

            if (ModelState.IsValid)
            {
                customer.updatedDate = DateTime.Now;
                customer.updatedby = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.LastIndexOf("\\") + 1); ;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            Dictionary<string, string> MigrationType = db.MigrationTypes.ToDictionary(p => p.ID.ToString(), p => p.name);
            
            ViewData["MigrationType"] = MigrationType;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MigrationType,AssignedDate,UnassignedDate,HVC,Exception,ExceptionDetail,state,Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.updatedDate = DateTime.Now;
                customer.updatedby = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.LastIndexOf("\\") + 1); ;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
