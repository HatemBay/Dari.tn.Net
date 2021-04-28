using Dari.tn.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;

namespace Dari.tn.Controllers
{
    public class OfferController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public OfferController()
        {

            baseAddress = "http://localhost:8000/offer/";
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
                var subs = tokenResponse.Content.ReadAsAsync<IEnumerable<Offer>>().Result;

                return View(subs);
            }
            else
            {
                return View(new List<Offer>());
            }
        }

        // GET: Subscription/Details/5
        public ActionResult Details(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var sub = tokenResponse.Content.ReadAsAsync<Offer>().Result;
                return View(sub);
            }
            else
            {
                return View(new Offer());
            }
        }

        // GET: Subscription/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subscription/Create
        [HttpPost]
        public ActionResult Create(Offer sub)
        {


            if (ModelState.IsValid == true)
            {

                var APIResponse = httpClient.PostAsJsonAsync<Offer>(baseAddress + "add/",
                sub).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                return RedirectToAction("Index", "Offer/Index");
            }
            return View();


        }

        // GET: /ranu/Edit/5  
        public ActionResult Edit(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var sub = tokenResponse.Content.ReadAsAsync<Offer>().Result;
                return View(sub);

            }
            else
            {
                return View(new Offer());
            }
        }
        //  
        // POST: /ranu/Edit/5  
        [HttpPost]
        public ActionResult Edit(int id, Offer sub)
        {

            if (ModelState.IsValid == true)
            {

                DateTime ss = sub.endD.Value;
                String end = ss.ToString("yyyy-MM-dd");

                DateTime sss = sub.startD.Value;
                String start = ss.ToString("yyyy-MM-dd");
                var APIResponse = httpClient.PostAsJsonAsync<Offer>(baseAddress + "update-all2/" + id + "/" + end + "/" + start + "/" + sub.space
                    + "/" + sub.chamNb + "/" + sub.levelNb + "/" + sub.pool + "/" + sub.airC + "/" + sub.description + "/" + sub.adress + "/" + sub.name + "/" + sub.price + "/" + sub.type, null
).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index", "Offer/Index");
            }
            return View();


        }


        public ActionResult Between()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Between2()
        {
            String price = Convert.ToString(Request["price"]);
            var tokenResponse = httpClient.GetAsync(baseAddress + "get-greater-price/" + price).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var subs = tokenResponse.Content.ReadAsAsync<IEnumerable<Offer>>().Result;

                return View(subs);
            }
            else
            {
                return View(new List<Offer>());
            }

        }

        public ActionResult SearchByName()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SearchByName2()
        {
            String name = Convert.ToString(Request["name"]);
            var tokenResponse = httpClient.GetAsync(baseAddress + "get-name/" + name).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var subs = tokenResponse.Content.ReadAsAsync<IEnumerable<Offer>>().Result;

                return View(subs);
            }
            else
            {
                return View(new List<Offer>());
            }

        }

        public ActionResult GlobalSearch()
        {

            return View();
        }

        [HttpPost]
        public ActionResult GlobalSearch2()
        {
            String name = Convert.ToString(Request["name"]);
            var tokenResponse = httpClient.GetAsync(baseAddress + "get-by-all/" + name).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var subs = tokenResponse.Content.ReadAsAsync<IEnumerable<Offer>>().Result;

                return View(subs);
            }
            else
            {
                return View(new List<Offer>());
            }

        }

        public ActionResult BetweenStuff()
        {

            return View();
        }

        [HttpPost]
        public ActionResult BetweenStuff2()
        {
            String from = Convert.ToString(Request["from"]);
            String to = Convert.ToString(Request["to"]);

            var tokenResponse = httpClient.GetAsync(baseAddress + "get-price-between/" + from + "/" + to).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var subs = tokenResponse.Content.ReadAsAsync<IEnumerable<Offer>>().Result;

                return View(subs);
            }
            else
            {
                return View(new List<Offer>());
            }

        }

        public ActionResult Mail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Mail2()

        {
            String mail = Convert.ToString(Request["mail"]);

            httpClient.GetAsync(baseAddress + "scheduler2/" + mail);
            return RedirectToAction("Index", "Offer/Index");

        }

        public ActionResult SaveHistory()
        {

            return View();
        }

        public ActionResult SaveHistory2()
        {

            String name = Convert.ToString(Request["name"]);
            String description = Convert.ToString(Request["description"]);
            String price = Convert.ToString(Request["price"]);
            String levelNb = Convert.ToString(Request["levelNb"]);
            String space = Convert.ToString(Request["space"]);
            String chamNb = Convert.ToString(Request["chamNb"]);

            var tokenResponse = httpClient.GetAsync(baseAddress + "get-by-all-save/" + description + "/" + name + "/" + price + "/" + levelNb
                + "/" + space + "/" + chamNb).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var subs = tokenResponse.Content.ReadAsAsync<IEnumerable<Offer>>().Result;

                return View(subs);
            }
            else
            {
                return View(new List<Offer>());
            }
        }

        // GET: Subscription/Delete/5
        public ActionResult Delete(int id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "delete/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Searching()
        {
            return View();
        }

        // POST: Subscription/Delete/5
        //[HttpPost]
        //public ActionResult Delete2(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}



