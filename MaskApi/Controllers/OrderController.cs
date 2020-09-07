using System.Collections.Generic;
using MaskApi.models;
using Microsoft.AspNetCore.Mvc;

namespace MaskApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase {
        public static List<Mask> MasksInStock = new List<Mask>();
        public static List<Order> Orders = new List<Order>();
        
        public OrderController() {
            MasksInStock.Add(new Mask("m-9999", 1, "White", true, false, "Flowers", true, 10.00));
            MasksInStock.Add(new Mask("m-8888", 3, "Black", false, true, "RaceCars", true, 3.50));
            MasksInStock.Add(new Mask("m-7777", 1, "Pink", true, false, "Peppa Pig", true, 15.00));
            MasksInStock.Add(new Mask("m-6666", 3, "Yellow", false, true, "Sponge Bob", true, 5.50));

            Orders.Add(new Order(new Mask("m-9999", 1, "White", true, false, "Flowers", true, 10.00), 20));
            Orders.Add(new Order(new Mask("m-7777", 1, "Pink", true, false, "Peppa Pig", true, 15.00), 5));
        }

        [HttpGet("GetAll")]
        public List<Order> GetAll() {
            return Orders;
        }

        [HttpGet("{orderNo}")]
        public Order GetOrder(int orderNo) {
            Order found = null;
            foreach(Order order in Orders) {
                if(orderNo == order.OrderNo) {
                    found = order;
                    break;
                }
            }
            
            return found;
        }

        [HttpPost]
        public int MakeOrder(MaskRequest request) {
            // LINQ
            Mask found = MasksInStock.Find(m => m.MaskId == request.MaskId);

            if(found == null) {
                return 0;
            }

            Order newOrder = new Order(found, request.Qty);
            Orders.Add(newOrder);

            return newOrder.OrderNo;

        }
    }
}