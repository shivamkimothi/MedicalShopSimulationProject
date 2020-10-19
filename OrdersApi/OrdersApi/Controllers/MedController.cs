using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersApi.Models;

namespace OrdersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedController : ControllerBase
    {
        [HttpGet]
        public dynamic GetMed()
        {
            using (var client = new HttpClient())
            {
                Medicine m = new Medicine();

                client.BaseAddress = new Uri("https://localhost:44335/");
                //client.BaseAddress = new Uri("http://52.224.82.33/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("api/medicines").Result;
                var data = response.Content.ReadAsAsync<IEnumerable<Medicine>>().Result;

                        /*m.Mid = y.Mid;
                        m.Mname = y.Mname;
                        m.Price = y.Price;
                        m.QuantityRemaining = y.QuantityRemaining;*/


                return data;
            }
        }
    }
}
