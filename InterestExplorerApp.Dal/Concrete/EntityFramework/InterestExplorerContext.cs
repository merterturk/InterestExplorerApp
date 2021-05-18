using InterestExplorerApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestExplorerApp.Dal.Concrete.EntityFramework
{
    //LOCAL MSSQL : Server=LAPTOP-9IQ5NO3T\\SQLEXPRESS;Initial Catalog=InterestExplorerDb;Integrated Security=True;
    // Hosting MSSQL : workstation id=InterestExplorerDb.mssql.somee.com;packet size=4096;user id=Merterturk_SQLLogin_1;pwd=qsuq8v5hpp;data source=InterestExplorerDb.mssql.somee.com;persist security info=False;initial catalog=InterestExplorerDb
    public class InterestExplorerContext : DbContext
    {
        public InterestExplorerContext():base("Server=LAPTOP-9IQ5NO3T\\SQLEXPRESS;Initial Catalog=InterestExplorerDb;Integrated Security=True;")
        {
            this.Configuration.LazyLoadingEnabled = false;

        }
        public DbSet<Book> Books  { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<MainCategory> MainCategories { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Series> Series { get; set; }

        public DbSet<VideoGame> VideoGames { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
