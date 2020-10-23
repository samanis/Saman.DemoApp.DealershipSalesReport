using Microsoft.EntityFrameworkCore;
using Saman.DemoApp.DealershipSalesReport.Model;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure.DataAccess
{
    public class SalesReportDBContext : DbContext
    {
        public SalesReportDBContext(DbContextOptions options) : base(options)
        {
        }

        
        public DbSet<SalesReport> SalesReports { get; set; }

    }
}

