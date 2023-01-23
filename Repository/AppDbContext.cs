using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppDbContext : DbContext
    {
        //Dbcontext implementation
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> tblUser { get; set; }
        public DbSet<Supplier> tblSupplier { get; set; }
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Data Source=FFSQL0;Initial Catalog=FCI_Web21;Integrated Security=False;User ID=sa;Password=sasa;Trust Server Certificate=true");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
    //public class AppDbContext: DbContext
    //{
    //    public AppDbContext(DbContextOptions con) : base(con)
    //    {

    //    }


    //    public DbSet<User> tblUser { get; set; }
    //}

}
