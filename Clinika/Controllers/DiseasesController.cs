using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinika.Models.DatabaseObject;
using Clinika.Models.Gateway;

namespace Clinika.Controllers
{
    public class DiseasesController : Controller
    {
        private Gateway db = new Gateway();

        // GET: /Diseases/
        public ActionResult Index()
        {
            var diseaseses = db.Diseaseses.Include(d => d.AMedicine);
            return View(diseaseses.ToList());
        }

        // GET: /Diseases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diseases diseases = db.Diseaseses.Find(id);
            if (diseases == null)
            {
                return HttpNotFound();
            }
            return View(diseases);
        }

        // GET: /Diseases/Create
        public ActionResult Create()
        {
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "Name");
            return View();
        }

        // POST: /Diseases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DiseasesId,Name,Description,TreatmentProcedure,MedicineId")] Diseases diseases)
        {
            if (ModelState.IsValid)
            {
                db.Diseaseses.Add(diseases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "Name", diseases.MedicineId);
            return View(diseases);
        }

        // GET: /Diseases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diseases diseases = db.Diseaseses.Find(id);
            if (diseases == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "Name", diseases.MedicineId);
            return View(diseases);
        }

        // POST: /Diseases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DiseasesId,Name,Description,TreatmentProcedure,MedicineId")] Diseases diseases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diseases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "Name", diseases.MedicineId);
            return View(diseases);
        }

        // GET: /Diseases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diseases diseases = db.Diseaseses.Find(id);
            if (diseases == null)
            {
                return HttpNotFound();
            }
            return View(diseases);
        }

        // POST: /Diseases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diseases diseases = db.Diseaseses.Find(id);
            db.Diseaseses.Remove(diseases);
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
