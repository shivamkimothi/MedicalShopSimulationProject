using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcClientApp.Models;
using Newtonsoft.Json;

namespace MvcClientApp.Controllers
{
    public class OrdController : Controller
    {
        public IActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44397/api/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("Orders").Result;


                string stringData = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<IEnumerable<Orders>>(stringData);


                return View(data);
            }
        }
    }
}
