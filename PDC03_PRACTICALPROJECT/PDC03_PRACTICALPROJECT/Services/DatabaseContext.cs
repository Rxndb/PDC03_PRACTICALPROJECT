using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using PDC03_PRACTICALPROJECT.Model;
using System.IO;

namespace PDC03_PRACTICALPROJECT.Services
{
    class DatabaseContext : DbContext
    {
        public DbSet<AnimalModel> Animals { get; set; }
        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Animal.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
