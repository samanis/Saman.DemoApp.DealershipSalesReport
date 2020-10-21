using Saman.DemoApp.DealershipSalesReport.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure
{
    public class SalesReportRepository : ISalesReportRepository
    {
        SalesReportCommandDBContext _context;

        public SalesReportRepository(SalesReportCommandDBContext salesReportConext)
        {
            this._context = salesReportConext ?? throw new ArgumentNullException(nameof(salesReportConext));
        }

        public void InsertSalesReport(SalesReport salesReport)
        {
            _context.SalesReports.Add(salesReport);
            _context.SaveChanges();
            
        }

        public void InsertBulkSalesReports(IEnumerable<SalesReport> salesReports)
        {
            foreach(var salesReport in salesReports)
            {
                _context.SalesReports.Add(salesReport);
            }
            _context.SaveChanges();
        }
    }
}
