using BriskDesk.Data;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BriskDesk.Data.Migrations
{
    public sealed class MigrationConfiguration : DbMigrationsConfiguration<BriskContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BriskContext context)
        {
            new TestDataSeeder().Seed(context);
        }
    }
}
