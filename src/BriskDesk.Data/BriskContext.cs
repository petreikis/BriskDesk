using BriskDesk.Data.Migrations;
using BriskDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Data
{
    public class BriskContext : DbContext
    {

        public BriskContext() : base("BriskHelpdesk")
        {
            Database.SetInitializer<BriskContext>(new MigrateDatabaseToLatestVersion<BriskContext, MigrationConfiguration>());
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Load all EntityTypeConfiguration<T> from current assembly and add to configurations
            // To keep it clean, we store all type configurations in Models/EntityTypeConfiguration folder
            var mapTypes = from t in typeof(BriskContext).Assembly.GetTypes()
                           where t.BaseType != null && t.BaseType.Name.StartsWith("EntityTypeConfiguration")
                           select t;
            foreach (var mapType in mapTypes)
            {
                dynamic mapInstance = Activator.CreateInstance(mapType);
                modelBuilder.Configurations.Add(mapInstance);
            }
        }
    }
}
