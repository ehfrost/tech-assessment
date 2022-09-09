using CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CSharp.Controllers
{


	[ApiController]
	[Route("api/[controller]")]
	public class OrdersController : ControllerBase
	{ 
        public List<Order> orders = new List<Order>(){
        new Order(1, 10, "Eric","Frost","Chicago",25,"1234567"),
        new Order(2, 11, "Eyre","Witts","Pittsburgh",27,"123434567"),
        new Order(3, 12, "Quinn","Araujo","Portland",52,"77777777"),
        new Order(4, 11, "Eyre","Witts","Pittsburgh",27,"123434567"),
        };


        // GET api/orders
        [HttpGet]
        public List<Order> Get(){
            return orders;
        }

		// POST api/orders
        [HttpPost]
        public List<Order> Post([FromBody] Order newOrder)
        {
            var maxOrderId = orders.Max(o => o.id);
            newOrder.id = maxOrderId;
            orders.Add(newOrder);
            return orders;
        }

        [HttpGet]
        public List<Order> GetCustomerOrders([FromQuery] int customerId)
        {
            List<Order> customerOrders = new List<Order>();
            foreach (Order order in orders)
            {
                if(order.getCustomerId(order) == customerId){
                    customerOrders.Add(order);
                }
            }

            return customerOrders;
        }

    
    [HttpPut("{id}")]
    public List<Order> ChangeOrder([FromBody] Order changingOrder)
    {
        foreach (Order order in orders)
        {
            if(order.id == changingOrder.id){
                //order.customerId = changingOrder.customerId; do for all potentially
                int changingid = order.id;
                orders.RemoveAt(order.id);
                orders.Insert(changingid, changingOrder);
            }
        }

        return orders;
    }

    [HttpPut("{id}/delete")]
    public List<Order> DeleteOrder([FromQuery] int targetId)
        {
            foreach (Order order in orders)
            {
                if(order.id == targetId){
                    orders.RemoveAt(order.id);
                }
            }

            return orders;
    }
        
	}
}
