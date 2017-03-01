using OZ.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ.DBRepository
{
    public class SqlServerDefaultContext:DbContext
    {
        public SqlServerDefaultContext():base("SqlServerDefaultContext")
        {
            Database.SetInitializer<SqlServerDefaultContext>(null);
            //Database.SetInitializer<SqlServerDefaultContext>(new CreateDatabaseIfNotExists<SqlServerDefaultContext>());


            //Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());


            //Database.SetInitializer<SqlServerDefaultContext>(null);
            //Database.SetInitializer<SqlServerDefaultContext>(new CreateDatabaseIfNotExists<SqlServerDefaultContext>());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
