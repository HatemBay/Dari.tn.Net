using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dari.tn.Controllers
{
    public class ChargeRequestHController : Controller
    {
        // GET: ChargeRequestH
        public ActionResult Index()
        {
            return View();
        }

        // GET: ChargeRequestH/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChargeRequestH/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChargeRequestH/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChargeRequestH/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChargeRequestH/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChargeRequestH/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChargeRequestH/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
