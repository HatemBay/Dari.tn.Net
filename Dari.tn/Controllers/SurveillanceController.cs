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
    public class SurveillanceController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public SurveillanceController()
        {
            baseAddress = "http://localhost:8000/contract/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = Session["AccessToken"];
            //httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
        }


        // GET: Surveillance
        public ActionResult Index()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + 1 +"/surveillance/detect-all").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var cams = tokenResponse.Content.ReadAsAsync<IEnumerable<string>>().Result;

                return View(cams);
            }
            else
            {
                return View(new List<string>());
            }
        }

        // GET: Surveillance/Details/5
        public ActionResult Details(string camName)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + 1 + "/surveillance/capture/" + camName).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var cams = tokenResponse.Content.ReadAsAsync<IEnumerable<string>>().Result;

                return View(cams);
            }
            else
            {
                return View(new List<string>());
            }
        }

        // GET: Surveillance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surveillance/Create
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

        // GET: Surveillance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Surveillance/Edit/5
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

        // GET: Surveillance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Surveillance/Delete/5
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
