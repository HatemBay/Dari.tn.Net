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
    public class OfferFavController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public OfferFavController()
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
            var tokenResponse = httpClient.GetAsync(baseAddress + "get-fav").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var subs = tokenResponse.Content.ReadAsAsync<IEnumerable<OfferFav>>().Result;

                return View(subs);
            }
            else
            {
                return View(new List<OfferFav>());
            }
        }

        [ChildActionOnly]
        public ActionResult OfferFavPartial()
        {
            return PartialView(new Offer());
        }


        // GET: Subscription/Details/5
        public ActionResult Details(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var sub = tokenResponse.Content.ReadAsAsync<OfferFav>().Result;
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
        public ActionResult Create(OfferFav sub)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<OfferFav>(baseAddress + "add/",
                sub).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index", "Subscription/Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Subscription/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Subscription/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OfferFav sub)
        {
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
        }

        // GET: Subscription/Delete/5
        public ActionResult Delete(int id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "delete-fav/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
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
