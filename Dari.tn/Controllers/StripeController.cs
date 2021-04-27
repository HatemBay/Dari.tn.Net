using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Dari.tn.Models
{
    public class StripeController : Controller
    {

        HttpClient httpClient;



        public HttpResponseMessage PostResponse(string url, object model)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"].ToString());

            return httpClient.PostAsJsonAsync(url, model).Result;
        }





   
        public ActionResult addCustomer()
        {


            HttpResponseMessage responseStripe = PostResponse("add-Customer/1", "");

            responseStripe.EnsureSuccessStatusCode();


            return RedirectToAction("addCard");

        }


        public ActionResult addCard()
        {
            return View();
        }

        public static string customerIdd;
        [HttpPost]
        public ActionResult AddCard(Models.Stripe stripes)
        {
        


            HttpResponseMessage responseStripe = PostResponse("add-Card/"+ stripes.idCustomer + "/"+ stripes.numcart+"/"+ stripes.mois+"/"+stripes.year +"/"+stripes.password, stripes);

            responseStripe.EnsureSuccessStatusCode();



            customerIdd = stripes.idCustomer;
       

       





         

            return RedirectToAction("Pay");

        }

        public ActionResult Pay()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Payy(Models.Stripe stripes)
        {



            //HttpResponseMessage responsecharge = PostResponse("charge-Card/40000/usd/" + customerIdd, "");

            //responsecharge.EnsureSuccessStatusCode();



            HttpResponseMessage responsePay = PostResponse("pay/1/1/"+ stripes.numcart+"/"+ stripes.mois+"/"+stripes.year +"/"+stripes.password, stripes);

            responsePay.EnsureSuccessStatusCode();





       



            

         

            return RedirectToAction("addCard");

        }


    }
}