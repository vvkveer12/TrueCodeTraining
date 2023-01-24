using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCode.Model;
using TrueCodeTraining.DbModel;

namespace TrueCodeTraining.Repository
{
    public class OrderRepository 
    {
        public List<OrderVm> GetOrder()
        {
            using(TrueCodeTrainingDbContext trueContext = new TrueCodeTrainingDbContext())
            {
                return (from order in trueContext.Orders
                        join customer in trueContext.Customers on order.CustomerId equals customer.CustomerId
                        select new OrderVm() {
                            OrderId = order.OrderId,
                            OrderDate = order.OrderDate,
                            CustomerId = order.CustomerId,
                            CustomerName = customer.CustomerName
                        }).ToList();
            }
        }
        public void DeleteOrder(int OrderId)
        {
            using(TrueCodeTrainingDbContext deleteOrder = new TrueCodeTrainingDbContext()) {
                var data = deleteOrder.Orders.Find(OrderId);
                deleteOrder.Orders.Remove(data);
                deleteOrder.SaveChanges();
            }
        }
        public Order AddOrderData(OrderVm order)
        {
            using(TrueCodeTrainingDbContext addOrder = new TrueCodeTrainingDbContext()) {
                var orderData = new Order();
                orderData.OrderDate = order.OrderDate;
                orderData.CustomerId = order.CustomerId;
                addOrder.Orders.Add(orderData);
                addOrder.SaveChanges();
                return orderData;
            }
        }
        public OrderVm GetSingleOrder(int? OrderId)
        {
            using(TrueCodeTrainingDbContext singleorder = new TrueCodeTrainingDbContext()) {
               
               return (from data in singleorder.Orders 
                       join customer in singleorder.Customers on data.CustomerId equals customer.CustomerId
                        where data.OrderId == OrderId
                        select new OrderVm() {
                            OrderId = data.OrderId,
                            OrderDate = data.OrderDate,
                            CustomerId = data.CustomerId,
                            CustomerName = customer.CustomerName                          
                        }).SingleOrDefault();
                
            }
        }
        public void UpdateOrder(OrderVm orderVm)
        {
            using(TrueCodeTrainingDbContext updateOrder = new TrueCodeTrainingDbContext()) {
                var order = updateOrder.Orders.Find(orderVm.OrderId);
                 order.OrderDate = orderVm.OrderDate;
                 order.CustomerId = orderVm.CustomerId;
                updateOrder.SaveChanges();
            }
        }
    }
}
