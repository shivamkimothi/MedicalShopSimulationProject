using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersApi.Models;
using OrdersApi.Services;

namespace OrdersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(OrdersController));
        private IOrderService _orderservice;

        public OrdersController(IOrderService orderservice)
        {
            _orderservice = orderservice;
        }

        /*public Medicine GetMed(int id)
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
                foreach(var y in data)
                {
                    if (y.Mid == id)
                    {
                        m.Mid = y.Mid;
                        m.Mname = y.Mname;
                        m.Price = y.Price;
                        m.QuantityRemaining = y.QuantityRemaining;
                    }
                }
                return m;
            }
        }
        */
        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<Orders>> GetOrders()
        {
            return Ok(_orderservice.GetOrders());
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<Orders> GetOrders(int id)
        {
            IQueryable<Orders> order = (IQueryable<Orders>)_orderservice.GetOrders(id);

            if (order.Count() == 0)
            {
                return BadRequest();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutOrders(int id, Orders orders)
        {
            if (id != orders.Oid)
            {
                return BadRequest();
            }

            //_context.Entry(orders).State = EntityState.Modified;

            try
            {
                _orderservice.PutOrders(id, orders);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Orders> PostOrders(Orders order)
        {
            //_context.Orders.Add(orders);
           var x = _orderservice.PostOrders(order);
            /*try
            {
                
            }
            catch (DbUpdateException)
            {
                if (OrdersExists(order.Oid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }*/

            return CreatedAtAction("GetOrders", new { id = order.Oid }, order);
            //return CreatedAtAction("GetOrders", new { id = orders.Oid }, orders);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public ActionResult<Orders> DeleteOrders(int id)
        {
            IQueryable<Orders> order = (IQueryable<Orders>)_orderservice.DeleteOrders(id);
            if (order.Count() == 0)
            {
                return BadRequest();
            }

            return Ok(order);
        }

        private bool OrdersExists(int id)
        {
            var x = _orderservice.GetOrders(id).FirstOrDefault();
            return _orderservice.OrdersExists(id);
            //return _context.Orders.Any(e => e.Oid == id);
        }
    }
}
