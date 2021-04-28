using Dari.tn.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace Dari.tn.Controllers
{
    public class FileController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public FileController()
        {
            baseAddress = "http://localhost:8000/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = Session["AccessToken"];
            //httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
        }

        // GET: User
        public ActionResult Index()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "files").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var subs = tokenResponse.Content.ReadAsAsync<IEnumerable<ResponseFile>>().Result;

                return View(subs);
            }
            else
            {
                return View(new List<ResponseFile>());
            }

        }




        // GET: User/Details/5



        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(MultipartFileData file2)
        {
            try
            {

                var APIResponse = httpClient.PostAsJsonAsync<MultipartFileData>(baseAddress + "upload", null
).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index", "Offer/Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5


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


    }




}

