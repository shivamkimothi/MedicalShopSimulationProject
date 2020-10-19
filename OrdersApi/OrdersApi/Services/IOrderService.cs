using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using OrdersApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApi.Services
{
    public interface IOrderService
    {
        public List<Orders> GetOrders();

        public IQueryable<Orders> GetOrders(int id);

        public Orders PutOrders(int id, Orders orders);

        //public void PostOrders(int id, int q, Orders order);

        public Orders PostOrders(Orders orders);

        public IQueryable<Orders> DeleteOrders(int id);

        public bool OrdersExists(int id);



    }
}
