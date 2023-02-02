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
        public List<OrderItemVm> GetAllOrderItems()
        {
            using (TrueCodeTrainingDbContext dbContext = new TrueCodeTrainingDbContext()) {
                return (from order in dbContext.Orders
                        join orderItems in dbContext.OrderItems on order.OrderId equals orderItems.OrderId join
                        customer in dbContext.Customers on order.CustomerId equals customer.CustomerId
                        group orderItems by new { order.OrderId, order.CustomerId, order.OrderDate, customer.CustomerName, customer.Address } into groupData
                        select new OrderItemVm() {
                            OrderId = groupData.Key.OrderId,
                            CustomerName = groupData.Key.CustomerName,
                            Address = groupData.Key.Address,
                            OrderDate = groupData.Key.OrderDate,
                            Quantity = groupData.Sum(x=>x.Quantity),
                            TotalPrice = groupData.Sum(x=>x.TotalPrice)
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

        public void AddOrder(OrderVmw orderVmw)
        {
            using (TrueCodeTrainingDbContext dbContext = new TrueCodeTrainingDbContext()) {
                var orderDb = new Order();
                orderDb.OrderDate = orderVmw.OrderDate;
                orderDb.CustomerId = orderVmw.CustomerId;
                foreach(var orderItem in orderVmw.productVms) {
                    var orderData = new OrderItems() {
                        Price = orderItem.Price,
                        ProductId = orderItem.ProductId,
                        Quantity = (int)orderItem.Quantity,
                        TotalPrice = orderItem.TotalPrice
                    };
                    dbContext.OrderItems.Add(orderData);
                };
                dbContext.Orders.Add(orderDb);
                dbContext.SaveChanges();

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
