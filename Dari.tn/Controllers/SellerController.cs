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
    public class SellerController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public SellerController()
        {
            baseAddress = "http://localhost:8000/sellers/";
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
                var subs = tokenResponse.Content.ReadAsAsync<IEnumerable<Seller>>().Result;

                return View(subs);
            }
            else
            {
                return View(new List<Seller>());
            }
        }

        // GET: Subscription/Details/5
        public ActionResult Details(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var sub = tokenResponse.Content.ReadAsAsync<Seller>().Result;
                return View(sub);
            }
            else
            {
                return View(new Seller());
            }
        }

        public ActionResult SellerFav(int id)
        {
            var tokenResponse = httpClient.GetAsync("http://localhost:8000/offer/get-fav-user/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var sub = tokenResponse.Content.ReadAsAsync<IEnumerable<OfferFav>>().Result;
                return View(sub);
            }
            else
            {
                return View(new List<OfferFav>());
            }
        }

        // GET: Subscription/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subscription/Create
        [HttpPost]
        public ActionResult Create(Seller sub)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Seller>(baseAddress + "add/",
                sub).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index", "Seller/Index");

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
                var sub = tokenResponse.Content.ReadAsAsync<Seller>().Result;
                return View(sub);

            }
            else
            {
                return View(new Seller());
            }
        }
        //  
        // POST: /ranu/Edit/5  
        [HttpPost]
        public ActionResult Edit(int id, Seller sub)
        {

            if (ModelState.IsValid == true)
            {

                var APIResponse = httpClient.PutAsJsonAsync<Offer>(baseAddress + "update-all/" + id + "/" + sub.email + "/" + sub.name, null
).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index", "Seller/Index");
            }
            return View();


        }

        public ActionResult Fav(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var sub = tokenResponse.Content.ReadAsAsync<Seller>().Result;
                return View(sub);

            }
            else
            {
                return View(new Offer());
            }
        }

        // POST: Subscription/Edit/5
        [HttpPost]
        public ActionResult Fav(int id, Seller seller2)
        {
            string off = Convert.ToString(Request["offer"]);
            string seller = Convert.ToString(Request["seller"]);

            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<OfferFav>(baseAddress + "affect-off-fav-2-buyer/" + off + "/" + seller2.sellerId, null
).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index", "Seller/Index");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult AffectSeller2Offer(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var sub = tokenResponse.Content.ReadAsAsync<Seller>().Result;
                return View(sub);

            }
            else
            {
                return View(new Offer());
            }
        }

        // POST: Subscription/Edit/5
        [HttpPost]
        public ActionResult AffectSeller2Offer(int id, Seller seller2)
        {
            string off = Convert.ToString(Request["offer"]);
            string seller = Convert.ToString(Request["seller"]);

            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Offer>(baseAddress + "affect-off-buyer/" + off + "/" + seller2.sellerId, null
).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index", "Seller/Index");

            }
            catch
            {
                return View();
            }
        }


        public ActionResult AllSellersStats()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "nb-with-offer").Result;

            var users = tokenResponse.Content.ReadAsAsync<String>().Result;
            ViewBag.Result = users;

            var tokenResponse8 = httpClient.GetAsync(baseAddress + "percent-with-offer").Result;

            var users8 = tokenResponse8.Content.ReadAsAsync<String>().Result;
            ViewBag.Result8 = users8;

            var tokenResponse2 = httpClient.GetAsync(baseAddress + "get-avg-prices").Result;

            var users2 = tokenResponse2.Content.ReadAsAsync<String>().Result;
            ViewBag.Result2 = users2;

            var tokenResponse3 = httpClient.GetAsync(baseAddress + "get-max-prices").Result;

            var users3 = tokenResponse3.Content.ReadAsAsync<String>().Result;
            ViewBag.Result3 = users3;

            var tokenResponse4 = httpClient.GetAsync(baseAddress + "get-min-prices").Result;

            var users4 = tokenResponse4.Content.ReadAsAsync<String>().Result;
            ViewBag.Result4 = users4;

            var tokenResponse5 = httpClient.GetAsync(baseAddress + "get-avg-space").Result;

            var users5 = tokenResponse5.Content.ReadAsAsync<String>().Result;
            ViewBag.Result5 = users5;

            var tokenResponse6 = httpClient.GetAsync(baseAddress + "get-max-space").Result;

            var users6 = tokenResponse6.Content.ReadAsAsync<String>().Result;
            ViewBag.Result6 = users6;

            var tokenResponse7 = httpClient.GetAsync(baseAddress + "get-min-space").Result;

            var users7 = tokenResponse7.Content.ReadAsAsync<String>().Result;
            ViewBag.Result7 = users7;

            return View();


        }

        public ActionResult SellerStats(long id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get-avg-price-seller/" + id).Result;
            var users = tokenResponse.Content.ReadAsAsync<String>().Result;
            ViewBag.Result = users;
            var tokenResponse2 = httpClient.GetAsync(baseAddress + "get-min-price-seller/" + id).Result;
            var users2 = tokenResponse2.Content.ReadAsAsync<String>().Result;
            ViewBag.Result2 = users2;
            var tokenResponse3 = httpClient.GetAsync(baseAddress + "get-max-price-seller/" + id).Result;
            var users3 = tokenResponse3.Content.ReadAsAsync<String>().Result;
            ViewBag.Result3 = users3;
            var tokenResponse4 = httpClient.GetAsync(baseAddress + "get-avg-space-seller/" + id).Result;
            var users4 = tokenResponse4.Content.ReadAsAsync<String>().Result;
            ViewBag.Result4 = users4;
            var tokenResponse5 = httpClient.GetAsync(baseAddress + "get-min-space-seller/" + id).Result;
            var users5 = tokenResponse5.Content.ReadAsAsync<String>().Result;
            ViewBag.Result5 = users5;
            var tokenResponse6 = httpClient.GetAsync(baseAddress + "get-max-space-seller/" + id).Result;
            var users6 = tokenResponse6.Content.ReadAsAsync<String>().Result;
            ViewBag.Result6 = users6;
            return View();


        }

        // GET: Subscription/Delete/5
        public ActionResult Delete(int id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "delete/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return View("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFav(int id)
        {
            var tokenResponse = httpClient.DeleteAsync("http://localhost:8000/offer/delete-fav/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Seller/Index");
            }
            return RedirectToAction("Index", "Seller/Index");
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
