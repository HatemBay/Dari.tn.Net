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
    public class SubscriptionController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public SubscriptionController()
        {
            baseAddress = "http://localhost:8000/subs/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = Session["AccessToken"];
            //httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
        }
        // GET: Subscription
        public ActionResult Index()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get-all").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var subs = tokenResponse.Content.ReadAsAsync<IEnumerable<Subscription>>().Result;

                return View(subs);
            }
            else
            {
                return View(new List<Subscription>());
            }
        }

        // GET: Subscription/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Subscription/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subscription/Create
        [HttpPost]
        public ActionResult Create(Subscription subscription)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Subscription>(baseAddress + "affect-sub-seller/" + 1,
                subscription).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                var result = APIResponse.Result.Content;
                UpdateModel(result);
                TempData["subscription"] = result;
                return RedirectToAction("Create", "ChargeRequestH");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subscription/Edit/5
        public ActionResult Edit(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var sub = tokenResponse.Content.ReadAsAsync<Insurance>().Result;
                return View(sub);
            }
            else
            {
                return View(new Insurance());
            }
        }

        // POST: Subscription/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Subscription subscription)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Subscription>(baseAddress + "update/" + id,
                subscription).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subscription/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Subscription/Delete/5
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
