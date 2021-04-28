﻿using Dari.tn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Dari.tn.Controllers
{
    public class UserController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public UserController()
        {
            baseAddress = "http://localhost:8000/users/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = Session["AccessToken"];
            //httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
        }

        // GET: User
        public ActionResult Index()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get-all").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var users = tokenResponse.Content.ReadAsAsync<IEnumerable<User>>().Result;

                return View(users);
            }
            else
            {
                return View(new List<User>());
            }
        }

        // GET: User/Details/5
        public ActionResult Details(long id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var user = tokenResponse.Content.ReadAsAsync<User>().Result;
                return View(user);
            }
            else
            {
                return View(new User());
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {


            if (ModelState.IsValid == true)
            {

                var APIResponse = httpClient.PostAsJsonAsync<User>(baseAddress + "add/",
                user).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                return RedirectToAction("Index", "User/Index");
            }
            return View();


        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var sub = tokenResponse.Content.ReadAsAsync<User>().Result;
                return View(sub);

            }
            else
            {
                return View(new User());
            }
        }
        //  
        // POST: /ranu/Edit/5  
        [HttpPost]
        public ActionResult Edit(int id, User sub)
        {

            if (ModelState.IsValid == true)
            {

                DateTime ss = sub.dateNaissance.Value;
                String end = ss.ToString("yyyy-MM-dd");

                var APIResponse = httpClient.PostAsJsonAsync<User>(baseAddress + "update-all/" + id + "/" + sub.email + "/" + sub.firstName + "/" + sub.lastname
                    + "/" + sub.password + "/" + end, null
).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index", "User/Index");
            }
            return View();


        }


        public ActionResult AffectUser2Offer(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var sub = tokenResponse.Content.ReadAsAsync<User>().Result;
                return View(sub);

            }
            else
            {
                return View(new Offer());
            }
        }

        // POST: Subscription/Edit/5
        [HttpPost]
        public ActionResult AffectUser2Offer(int id, User seller2)
        {
            string off = Convert.ToString(Request["offer"]);
            string seller = Convert.ToString(Request["seller"]);

            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Offer>(baseAddress + "affect-off-buyer/" + off + "/" + seller2.id, null
).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index", "User/Index");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult AllUsersStats()
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

        public ActionResult UserStats(long id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get-avg-price-user/" + id).Result;
            var users = tokenResponse.Content.ReadAsAsync<String>().Result;
            ViewBag.Result = users;
            var tokenResponse2 = httpClient.GetAsync(baseAddress + "get-min-price-user/" + id).Result;
            var users2 = tokenResponse2.Content.ReadAsAsync<String>().Result;
            ViewBag.Result2 = users2;
            var tokenResponse3 = httpClient.GetAsync(baseAddress + "get-max-price-user/" + id).Result;
            var users3 = tokenResponse3.Content.ReadAsAsync<String>().Result;
            ViewBag.Result3 = users3;
            var tokenResponse4 = httpClient.GetAsync(baseAddress + "get-avg-space-user/" + id).Result;
            var users4 = tokenResponse4.Content.ReadAsAsync<String>().Result;
            ViewBag.Result4 = users4;
            var tokenResponse5 = httpClient.GetAsync(baseAddress + "get-min-space-user/" + id).Result;
            var users5 = tokenResponse5.Content.ReadAsAsync<String>().Result;
            ViewBag.Result5 = users5;
            var tokenResponse6 = httpClient.GetAsync(baseAddress + "get-max-space-user/" + id).Result;
            var users6 = tokenResponse6.Content.ReadAsAsync<String>().Result;
            ViewBag.Result6 = users6;
            return View();


        }

        // GET: User/Delete/5
        public ActionResult Delete(long id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "delete/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // PUT: User/Affect/5/Contract/1
        [HttpPut]
        public ActionResult AffectToContract(long idUser, int idContract)
        {
            try
            {
                var APIResponse = httpClient.PutAsync(baseAddress + "affect-contract-seller/" + idContract + "/" + idUser,null
                    ).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
