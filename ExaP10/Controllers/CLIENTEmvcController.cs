﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExaP10.Models;

namespace ExaP10.Controllers
{
    public class CLIENTEmvcController : Controller
    {
        private Ciudad_DollarEntities db = new Ciudad_DollarEntities();

        // GET: CLIENTEmvc
        public ActionResult Index()
        {
            var cLIENTE = db.CLIENTE.Include(c => c.PIB1).Include(c => c.PRODUCTO1).Include(c => c.UBICACION1);
            return View(cLIENTE.ToList());
        }

        // GET: CLIENTEmvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // GET: CLIENTEmvc/Create
        public ActionResult Create()
        {
            ViewBag.Pib = new SelectList(db.PIB, "Id", "Id");
            ViewBag.Producto = new SelectList(db.PRODUCTO, "Id", "Descripcion");
            ViewBag.Ubicacion = new SelectList(db.UBICACION, "Id", "Id");
            return View();
        }

        // POST: CLIENTEmvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Empresa,Fecha,Donacion,Pib,Ubicacion,Producto")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTE.Add(cLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pib = new SelectList(db.PIB, "Id", "Id", cLIENTE.Pib);
            ViewBag.Producto = new SelectList(db.PRODUCTO, "Id", "Descripcion", cLIENTE.Producto);
            ViewBag.Ubicacion = new SelectList(db.UBICACION, "Id", "Id", cLIENTE.Ubicacion);
            return View(cLIENTE);
        }

        // GET: CLIENTEmvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pib = new SelectList(db.PIB, "Id", "Id", cLIENTE.Pib);
            ViewBag.Producto = new SelectList(db.PRODUCTO, "Id", "Descripcion", cLIENTE.Producto);
            ViewBag.Ubicacion = new SelectList(db.UBICACION, "Id", "Id", cLIENTE.Ubicacion);
            return View(cLIENTE);
        }

        // POST: CLIENTEmvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Empresa,Fecha,Donacion,Pib,Ubicacion,Producto")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pib = new SelectList(db.PIB, "Id", "Id", cLIENTE.Pib);
            ViewBag.Producto = new SelectList(db.PRODUCTO, "Id", "Descripcion", cLIENTE.Producto);
            ViewBag.Ubicacion = new SelectList(db.UBICACION, "Id", "Id", cLIENTE.Ubicacion);
            return View(cLIENTE);
        }

        // GET: CLIENTEmvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // POST: CLIENTEmvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            db.CLIENTE.Remove(cLIENTE);
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
