using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dari.tn.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Dari.tn.Controllers
{
    public class LivreurController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:8000/";




        public async Task<ActionResult> Index()
        {
            List<Livreur> FURInfo = new List<Livreur>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("AllLivreures");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    FURInfo = JsonConvert.DeserializeObject<List<Livreur>>(EmpResponse);

                }



                //returning the employee list to view  
                return View(FURInfo);
            }
        }


        public ActionResult create()
        {
            return View();
        }

        public HttpResponseMessage PostResponse(string url, object model)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"].ToString());

            return httpClient.PostAsJsonAsync(url, model).Result;
        }

        [HttpPost]
        public ActionResult Create(Models.Livreur livreur )
        {
            
            
            HttpResponseMessage response = PostResponse("add-Livreur", livreur);

            response.EnsureSuccessStatusCode();


            return RedirectToAction("Index");
        }





        public HttpResponseMessage DeleteResponse(string url)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"].ToString());
            return httpClient.DeleteAsync(url).Result;
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = DeleteResponse("remove-Livreur/" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }



        public HttpResponseMessage PutResponse(string url, object model)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"].ToString());
            return httpClient.PutAsJsonAsync(url, model).Result;
        }


        public HttpResponseMessage GetResponse(string url)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"].ToString());
            return httpClient.GetAsync(url).Result;
        }
        public static int idd;


        public static string imagefur;
        //[HttpGet]  
        public ActionResult EditProduct(int id)
        {

            HttpResponseMessage response = GetResponse("byidliv/" + id.ToString());
            idd = id;

            response.EnsureSuccessStatusCode();
            Models.Livreur furnitures = response.Content.ReadAsAsync<Models.Livreur>().Result;
       
            ViewBag.Title = "Index";
            return View(furnitures);
        }



        //[HttpPut]  
        public ActionResult Update(Models.Livreur furniture, int id)
        {

            HttpResponseMessage response = PutResponse("modify-Livreur/" + idd, furniture);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        public static float montant;
        public ActionResult Details(int id)
        {

            HttpResponseMessage response = GetResponse("byidliv/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.Livreur furnitures = response.Content.ReadAsAsync<Models.Livreur>().Result;

         
            ViewBag.Title = "All Livreures";
            return View(furnitures);
        }






    }
}