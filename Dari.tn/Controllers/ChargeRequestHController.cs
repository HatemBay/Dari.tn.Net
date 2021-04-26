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
    public class ChargeRequestHController : Controller
    {

        HttpClient httpClient;
        string baseAddress;
        public ChargeRequestHController()
        {
            baseAddress = "http://localhost:8000/charge/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = Session["AccessToken"];
            //httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
        }

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
        public ActionResult Create(ChargeRequestH chargeRequest)
        {
            Subscription s = TempData["subscription"] as Subscription;
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<ChargeRequestH>(baseAddress + "sub/" + s.Id,
                    chargeRequest).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
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
