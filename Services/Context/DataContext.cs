using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendfoodapi.Models;
using Microsoft.EntityFrameworkCore;

namespace backendfoodapi.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> UserInfo {get; set; }

        public DbSet<IngredientItemModel> IngredientInfo {get; set;}

        public DataContext(DbContextOptions options): base(options){}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }

        internal void SavedChanges()
        {
            throw new NotImplementedException();
        }
    }
}