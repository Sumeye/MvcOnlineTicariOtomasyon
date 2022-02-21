using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ExpenseItems> ExpenseItems { get; set; }
        public DbSet<Bills> Bills { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<SalesMovements> SalesMovements { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<TodoList> todoLists { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoTracking> cargoTrackings { get; set; }


    }
}