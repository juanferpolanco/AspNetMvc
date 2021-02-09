using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoMVC.Models;

namespace VideoMVC.Controllers
{
    public class ContratosController : Controller
    {
        private dbVideoMVCEntities db = new dbVideoMVCEntities();

        // GET: Contratos
        public ActionResult Index()
        {
            var tblContrato = db.tblContrato.Include(t => t.tblCliente);
            return View(tblContrato.ToList());
        }

        [HttpPost]
        public ActionResult Index(DateTime From, DateTime To)
        {
            var array = db.BuscarDato(From, To);
            return View(array);
        }

        // GET: Contratos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContrato tblContrato = db.tblContrato.Find(id);
            if (tblContrato == null)
            {
                return HttpNotFound();
            }
            return View(tblContrato);
        }

        // GET: Contratos/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.tblCliente, "idCliente", "nombreCliente");
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idContrato,idCliente,montoContrato,fechaContrato")] tblContrato tblContrato)
        {
            if (ModelState.IsValid)
            {
                db.tblContrato.Add(tblContrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.tblCliente, "idCliente", "nombreCliente", tblContrato.idCliente);
            return View(tblContrato);
        }

        // GET: Contratos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContrato tblContrato = db.tblContrato.Find(id);
            if (tblContrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.tblCliente, "idCliente", "nombreCliente", tblContrato.idCliente);
            return View(tblContrato);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idContrato,idCliente,montoContrato,fechaContrato")] tblContrato tblContrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblContrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.tblCliente, "idCliente", "nombreCliente", tblContrato.idCliente);
            return View(tblContrato);
        }

        // GET: Contratos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContrato tblContrato = db.tblContrato.Find(id);
            if (tblContrato == null)
            {
                return HttpNotFound();
            }
            return View(tblContrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblContrato tblContrato = db.tblContrato.Find(id);
            db.tblContrato.Remove(tblContrato);
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
