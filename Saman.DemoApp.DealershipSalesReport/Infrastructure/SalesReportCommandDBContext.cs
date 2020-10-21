using Microsoft.EntityFrameworkCore;
using Saman.DemoApp.DealershipSalesReport.Model;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure
{
    public class SalesReportCommandDBContext : DbContext
    {
        public SalesReportCommandDBContext( DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SalesReports");
        public DbSet<SalesReport> SalesReports { get; set; }

    }
}

