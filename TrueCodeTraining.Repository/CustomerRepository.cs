using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCode.Model;
using TrueCodeTraining.DbModel;

namespace TrueCodeTraining.Repository
{
    public class CustomerRepository
    {
        public Customer AddCustomer(Customer customer)
        {
            using(TrueCodeTrainingDbContext trucodeconnection = new TrueCodeTrainingDbContext()) {
                trucodeconnection.Customers.Add(customer);
                trucodeconnection.SaveChanges();
                return customer;
            }
        }
        public void DeleteCustomer(int? CustomerID)
        {
            using(TrueCodeTrainingDbContext deletecustomer = new TrueCodeTrainingDbContext()) {
              var data =   deletecustomer.Customers.Find(CustomerID);
                deletecustomer.Customers.Remove(data);
                deletecustomer.SaveChanges();
            }
        }
        public List<CostomerVm> GetAllCustomer()
        {
            using(TrueCodeTrainingDbContext getAllData = new TrueCodeTrainingDbContext()) {
                //var data = getAllData.Customers.ToList();
                //return data;
                return (from customer in getAllData.Customers
                        select new CostomerVm() {
                            CustomerId = customer.CustomerId,
                            CustomerName = customer.CustomerName,
                            CreatedDate = customer.CreatedDate,
                            Address = customer.Address
                        }).ToList();
            }
        }
        public Customer EditeData(int CustomerId)
        {
            using(TrueCodeTrainingDbContext getsingledata = new TrueCodeTrainingDbContext()) {
                var data = getsingledata.Customers.Find(CustomerId);
                return data;
            }
        }
        public void UpdateCustomer(CostomerVm customerVm)
        {
            //using(TrueCodeTrainingDbContext update = new TrueCodeTrainingDbContext()) {
            //    update.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            //    update.SaveChanges();
            //}
            using(TrueCodeTrainingDbContext update = new TrueCodeTrainingDbContext()) {
                var customer = update.Customers.Find(customerVm.CustomerId);
                 customer.CustomerName = customerVm.CustomerName;
                 customer.Address = customerVm.Address;
                 customer.CreatedDate = customerVm.CreatedDate ;
                 update.SaveChanges();
            }
        }
    }
}
