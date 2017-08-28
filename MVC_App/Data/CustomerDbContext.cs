using MVC_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_App.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext() : base("name=CodeFirstDBEntities")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

    }
}