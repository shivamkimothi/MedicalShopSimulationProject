using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcClientApp.Models;
using MvcClientApp.Models.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcClientApp.Controllers
{
    public class MedsController : Controller
    {

        public IActionResult Index()
        {
            Users obj = new Users { Email = "admin", Password = "admin" };
            using (HttpClient client = new HttpClient())
            {
                var token = GetToken("https://localhost:44364/api/token", obj);
                client.BaseAddress = new Uri("https://localhost:44335/api/");
                // MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                //client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("Medicines").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<IEnumerable<Medicine>>(stringData);
                return View(data);
            }
        }

        public IActionResult Buy(int id)
        {
            OrderQuantityViewModel obj = new OrderQuantityViewModel();
            obj.ProductId = id;
            return View(obj);
            /*
            Medicine o = new Medicine();
            
            Users obj = new Users { Email = "admin", Password = "admin" };
            using (HttpClient client = new HttpClient())
            {
                var token = GetToken("https://localhost:44364/api/token", obj);
                client.BaseAddress = new Uri("https://localhost:44335/api/");
                // MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                //client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
                using (var response = await client.GetAsync("https://localhost:44335/api/medicines" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    o = JsonConvert.DeserializeObject<Medicine>(apiResponse);
                }
            }
            return View(o);*/
        }

        [HttpPost]
        public async Task<IActionResult> Buy(OrderQuantityViewModel oqvm)
        {
            Users obj = new Users { Email = "admin", Password = "admin" };
            using (HttpClient client = new HttpClient())
            {
                Orders ord = new Orders();
                List<Orders> o = new List<Orders>();
                Medicine med = new Medicine();
                List<Medicine> l = new List<Medicine>();
                var token = GetToken("https://localhost:44364/api/token", obj);
                client.BaseAddress = new Uri("https://localhost:44335/api/");
                // MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                //client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await client.GetAsync("https://localhost:44335/api/medicines/" + oqvm.ProductId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    l= JsonConvert.DeserializeObject<List<Medicine>> (apiResponse);
                    
                }
                ord.Dateoforder = DateTime.Now;
                ord.Mid = oqvm.ProductId;
                ord.Oid = oqvm.OrderId;
                ord.Totalcost = l[0].Price * oqvm.Quantity;
                ord.Quantity = oqvm.Quantity;
               // l[0].QuantityRemaining = l[0].QuantityRemaining - ord.Quantity;

                StringContent content = new StringContent(JsonConvert.SerializeObject(ord), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("https://localhost:44397/api/Orders/", content))  //?id="+oqvm.ProductId+"&q="+oqvm.Quantity
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ord = JsonConvert.DeserializeObject<Orders>(apiResponse);
                    //ord = o[0];
                }
                Medicine medi = new Medicine();
                medi.Mid = ord.Mid;
                medi.Mname = l[0].Mname;
                medi.Price = l[0].Price;
                medi.QuantityRemaining = l[0].QuantityRemaining - ord.Quantity;
                medi.ExpiryDate = l[0].ExpiryDate;
                l[0].Mid = oqvm.ProductId;

                //content = new StringContent(JsonConvert.SerializeObject(medi), Encoding.UTF8, "application/json");
                /*using (var response = await client.DeleteAsync("https://localhost:44335/api/medicines/"+oqvm.ProductId))  //?id="+oqvm.ProductId+"&q="+oqvm.Quantity
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    med = JsonConvert.DeserializeObject<Medicine>(apiResponse);
                    //ord = o[0];
                }*/

                content = new StringContent(JsonConvert.SerializeObject(medi), Encoding.UTF8, "application/json");
                using (var response = await client.PutAsync("https://localhost:44335/api/medicines/"+oqvm.ProductId, content))  //?id="+oqvm.ProductId+"&q="+oqvm.Quantity
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    med = JsonConvert.DeserializeObject<Medicine>(apiResponse);
                    //ord = o[0];
                }


            }
            return RedirectToAction("Index");
        }

       
        static string GetToken(string url, Users user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, data).Result;
                string name = response.Content.ReadAsStringAsync().Result;
                dynamic details = JObject.Parse(name);
                return details.token;
            }
        }
    }
}
