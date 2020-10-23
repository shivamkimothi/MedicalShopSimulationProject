using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OrdersApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly medicalShopContext _context;
        //private readonly medicalShopContext _con = new medicalShopContext(new DbContextOptions<medicalShopContext>());

        
        public OrderService(medicalShopContext context)
        {
            _context = context;
            
        }
        


        public IQueryable<Orders> DeleteOrders(int id)
        {
            IQueryable<Orders> orders = _context.Orders.Where(p => p.Oid == id);
            _context.Orders.Remove(orders.FirstOrDefault());
            _context.SaveChangesAsync();
            return orders;
        }

        public List<Orders> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public IQueryable<Orders> GetOrders(int id)
        {
            return _context.Orders.Where(p => p.Oid == id);
        }

        public bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Oid == id);
        }

        public Orders PostOrders(Orders orders)
         { 


             _context.Orders.Add(orders);
             _context.SaveChangesAsync();
            return orders;
            /* List<Medicine> med = _con.Medicine.ToList();
             foreach(var y in med)
             {
                 if (y.Mid == orders.Mid)
                 {
                     if (y.QuantityRemaining < orders.Quantity)
                     {
                         throw new Exception();
                     }
                     else
                     {
                         y.QuantityRemaining = y.QuantityRemaining - orders.Quantity;
                     }
                 }
             }
             _con.Entry(orders).State = EntityState.Modified;
             _con.SaveChangesAsync();*/


         }
       /* public void PostOrders(int id, int q, Orders o)
        {
            using (var client = new HttpClient())
            {
                //Medicine m = new Medicine();
                
                client.BaseAddress = new Uri("https://localhost:44335/");
                //client.BaseAddress = new Uri("http://52.224.82.33/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("api/medicines").Result;
                var data = response.Content.ReadAsAsync<IEnumerable<Medicine>>().Result;
                Medicine medicine = (from p in data
                                where p.Mid == id
                                select p).FirstOrDefault();
                o.Mid = medicine.Mid;
                
                o.Quantity = q;
                o.Totalcost = medicine.Price * o.Quantity;
                medicine.QuantityRemaining = medicine.QuantityRemaining - o.Quantity;
                _context.Orders.Add(o);
                //_context.Entry(medicine).State = EntityState.Modified;
                _context.SaveChangesAsync();
                //return o;

                /*foreach(var y in data)
                {
                    if(id == y.Mid)
                    {
                        o.Mid = id;

                        o.Totalcost = o.Quantity * y.Price;
                    }
                    m.QuantityRemaining = m.QuantityRemaining - o.Quantity;
                }
            }
        }*/
        public Orders PutOrders(int id, Orders orders)
        {
            _context.Entry(orders).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return orders;
        }
    }
}
