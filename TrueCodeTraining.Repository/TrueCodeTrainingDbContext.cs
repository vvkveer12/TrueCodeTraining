using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCodeTraining.DbModel;

namespace TrueCodeTraining.Repository
{
    public class TrueCodeTrainingDbContext : DbContext
    {
        public TrueCodeTrainingDbContext() : base("TrueCodeTraining")
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
