using InventoryManager.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Database
{
    public class InventoryManagerContext: DbContext
    {
        // name is Pallets
        public virtual DbSet<Pallet> Pallets { get; set; }

        // override onconfiguring method to connect database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // to check the same operation is done only one time
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            //same uname password as serverless.template
            optionsBuilder.UseSqlServer($"Server=iddg56telmtadz.cmxxgvnwvplv.ap-south-1.rds.amazonaws.com; Database=InventoryManagerDB; User Id =yourusername; Password=youruserpassword");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
