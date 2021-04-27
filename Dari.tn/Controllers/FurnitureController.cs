using Dari.tn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using System.Data;
namespace Dari.tn.Controllers
{
    public class FurnitureController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:8000/";

   
        public async Task<ActionResult> Index()
        {
            List<Furniture> FURInfo = new List<Furniture>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("AllFurnitures");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    FURInfo = JsonConvert.DeserializeObject<List<Furniture>>(EmpResponse);

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
        public ActionResult Create(Models.Furniture furniture, Models.FileImage del)
        {
            string filename = Path.GetFileNameWithoutExtension(del.Imagefile.FileName);
            string d = filename;
            string extension = Path.GetExtension(del.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            string p = filename;
            furniture.image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
             del.Imagefile.SaveAs(filename);
            furniture.image = p;
            furniture.quantity = 1;
            furniture.publishedDate= DateTime.Now; 

            HttpResponseMessage response = PostResponse("add-Furniture", furniture);
         
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
            HttpResponseMessage response = DeleteResponse("remove-Furniture/" + id.ToString());
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
           
            HttpResponseMessage response = GetResponse("byid/" + id.ToString());
            idd = id;
           
            response.EnsureSuccessStatusCode();
            Models.Furniture furnitures = response.Content.ReadAsAsync<Models.Furniture>().Result;
            imagefur= furnitures.image;
            ViewBag.Title = "Index";
            return View(furnitures);
        }



        //[HttpPut]  
        public ActionResult Update(Models.Furniture furniture, int id)
        {
            furniture.image = imagefur;
            furniture.Barcode = 111;
            HttpResponseMessage response = PutResponse("modify-Furniture/"+idd, furniture);
            response.EnsureSuccessStatusCode();
           return RedirectToAction("Index");
        }

        public static float montant;
        public ActionResult Details(int id)
        {
          
            HttpResponseMessage response = GetResponse("byid/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.Furniture furnitures = response.Content.ReadAsAsync<Models.Furniture>().Result;

            montant = furnitures.price;
            ViewBag.Title = "All Furnitures";
            return View(furnitures);
        }



        
        public ActionResult CreatePanier(Models.LigneCommande lignec, Models.Commande commande)
        {


            HttpResponseMessage responselc = PostResponse("add-LC_Commande/1", lignec);

            responselc.EnsureSuccessStatusCode();


            Commande c = new Commande();


            c.date = DateTime.Now;
            c.montant = FurnitureController.montant;
           c.total = c.montant;
            c.status = "IN_PROGRESS";
            c.PourcentageDeRemise = 0;
            c.remise = "0%";
            

            commande = c;

            HttpResponseMessage responsecommande = PostResponse("add-Commande", commande);

            responsecommande.EnsureSuccessStatusCode();



            HttpResponseMessage responseaffecterUser_A_Commande = PutResponse("affecterUser_A_Commande/1/1", "");

            responseaffecterUser_A_Commande.EnsureSuccessStatusCode();


            HttpResponseMessage responseaffecterLC_A_Commande = PutResponse("affecterLC_A_Commande/1/1", "");

            responseaffecterLC_A_Commande.EnsureSuccessStatusCode();


            HttpResponseMessage responseaddPanier = PutResponse("addMeubleDansPanier12/1/1/1", "");

            responseaddPanier.EnsureSuccessStatusCode();

            return RedirectToAction("DetailsPanier");

        }


        public ActionResult ViderPanier(Models.LigneCommande lignec, Models.Commande commande)
        {


            HttpResponseMessage responseaddPanier = DeleteResponse("deleteMeubleFromPanier12/1/1");

            responseaddPanier.EnsureSuccessStatusCode();

            return RedirectToAction("DetailsPanier");

        }






        public static List<string> nameList;
        public static List<string> nameList2;

        public ActionResult DetailsPanier()
        {

            HttpResponseMessage response = GetResponse("getFurnitureByCard/1");
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;

            List<string> myList = JsonConvert.DeserializeObject<List<string>>(responseBody);
          
            foreach(var name in myList) { 
            
            nameList = name.Split(',').ToList();


                nameList2 = new List<string>();
                nameList2.Add(nameList[2]);
                nameList2.Add(nameList[4]);
                nameList2.Add(nameList[5]);
                nameList2.Add(nameList[8]);
            }

           
            
            return PartialView(nameList2);
        }

        public ActionResult CreateFacturePdf(Models.Factures facture)
        {


            Factures f = new Factures();


            f.date_de_depart = DateTime.Now;
            f.montant = montant;
            f.type = "Achat";
                
            facture = f;

            HttpResponseMessage responsefacture = PostResponse("add-Facture", facture);

            responsefacture.EnsureSuccessStatusCode();





            HttpResponseMessage responseaffecterCommande_A_Facture = PutResponse("affecterCommande_A_Facture/1/1", "");

            responseaffecterCommande_A_Facture.EnsureSuccessStatusCode();



            HttpResponseMessage response = GetResponse("afficherPDF/1/1");
            response.EnsureSuccessStatusCode();



            return RedirectToAction("Index");

        }





        public ActionResult Acheter()
        {



            return View();

        }






    }
    }