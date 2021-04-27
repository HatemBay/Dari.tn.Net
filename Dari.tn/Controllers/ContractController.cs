using Dari.tn.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Dari.tn.Controllers
{
    public class ContractController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public ContractController()
        {
            baseAddress = "http://localhost:8000/contracts/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = Session["AccessToken"];
            //httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _AccessToken));
        }

        // GET: Contract
        public ActionResult Index()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get-all").Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var contracts = tokenResponse.Content.ReadAsAsync<IEnumerable<Contract>>().Result;

                return View(contracts);
            }
            else
            {
                return View(new List<Contract>());
            }
        }

        // GET: Contract
        public ActionResult GetOwned()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "getByUser/" + 1).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var contracts = tokenResponse.Content.ReadAsAsync<IEnumerable<Contract>>().Result;

                return View(contracts);
            }
            else
            {
                return View(new List<Contract>());
            }
        }

        // GET: Contract/Details/5
        public ActionResult Details(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var contract = tokenResponse.Content.ReadAsAsync<Contract>().Result;
                return View(contract);
            }
            else
            {
                return View(new Contract());
            }
        }

        // GET: Contract/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contract/Create
        [HttpPost]
        public ActionResult Create(Contract contract)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Contract>(baseAddress + "affect-contract-seller/" + 1,
                contract).Result;
                if (APIResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("CreateContract", "ChargeRequestH");
                }
                else 
                {
                    ModelState.AddModelError("duration", "You are not subscribed, please subscribe to initiate contracts!");
                    ModelState.AddModelError("startDate", "Or maybe check whether you inserted a future date!");
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Contract/Edit/5
        public ActionResult Edit(int id)
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "get/" + id.ToString()).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                var sub = tokenResponse.Content.ReadAsAsync<Contract>().Result;
                return View(sub);
            }
            else
            {
                return View(new Contract());
            }
        }

        // POST: Contract/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contract contract)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Contract>(baseAddress + "update/" + id,
                contract).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contract/Delete/5
        public ActionResult Delete(int id)
        {
            var tokenResponse = httpClient.DeleteAsync(baseAddress + "delete/" + id).Result;
            if (tokenResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Download()
        {
            var tokenResponse = httpClient.GetAsync(baseAddress + "download/contract_pdf");
            using (var fileStream = new FileStream(HostingEnvironment.MapPath(string.Format("~/real-estate-purchase-agreement.pdf", "")), FileMode.CreateNew))
            {
                tokenResponse.Result.Content.CopyToAsync(fileStream);
            }
            return RedirectToAction("Index");
        }
    }
}