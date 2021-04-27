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
    public class InsuranceController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public InsuranceController()
        {
            baseAddress = "http://localhost:8000/insurances/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = Session["AccessToken"];
            //httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
        }

        // GET: Insurance
        public ActionResult Index()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get-all").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var insurances = tokenResponse.Content.ReadAsAsync<IEnumerable<Insurance>>().Result;

                return View(insurances);
            }
            else
            {
                return View(new List<Insurance>());
            }
        }

        // GET: Insurance/Details/5
        public ActionResult Details(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var insurance = tokenResponse.Content.ReadAsAsync<Insurance>().Result;
                return View(insurance);
            }
            else
            {
                return View(new Insurance());
            }
        }

        // GET: Insurance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insurance/Create
        [HttpPost]
        public ActionResult Create(Insurance insurance)
        {
            try
            {
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Insurance/Edit/5
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

        // POST: Insurance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Insurance insurance)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Insurance>(baseAddress + "update/" + id,
                insurance).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Insurance/Delete/5
        public ActionResult Delete(int id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "delete/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
