using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Olimpia.Stadium.Api.Model;

namespace Olimpia.Stadium.Api.Data
{
    public class Context : DbContext
    {
        public Context()
        {
            
        }
      
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Gate> Gates { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Model.Stadium> Stadiums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
