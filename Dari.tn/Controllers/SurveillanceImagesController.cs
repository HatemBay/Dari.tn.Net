using Dari.tn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Dari.tn.Controllers
{
    public class SurveillanceImagesController : Controller
    {

        HttpClient httpClient;
        string baseAddress;
        public SurveillanceImagesController()
        {
            baseAddress = "http://localhost:8000/contract/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = Session["AccessToken"];
            //httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
        }

        // GET: SurveillanceImages
        public ActionResult Index()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + 1 + "/surveillance/get-all").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var contracts = tokenResponse.Content.ReadAsAsync<IEnumerable<SurveillanceImages>>().Result;

                return View(contracts);
            }
            else
            {
                return View(new List<SurveillanceImages>());
            }
        }

        // GET: SurveillanceImages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SurveillanceImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveillanceImages/Create
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

        // GET: SurveillanceImages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SurveillanceImages/Edit/5
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

        // GET: SurveillanceImages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SurveillanceImages/Delete/5
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
