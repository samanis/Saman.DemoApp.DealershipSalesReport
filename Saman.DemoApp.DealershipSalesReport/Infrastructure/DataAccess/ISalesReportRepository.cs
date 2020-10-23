using Saman.DemoApp.DealershipSalesReport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure.DataAccess
{
    public interface ISalesReportRepository
    {

        public void InsertSalesReport(SalesReport salesReport);

        public void InsertBulkSalesReports(IEnumerable<SalesReport> salesReports);

        public IEnumerable<string> GetDealershipNames();

        public IEnumerable<SalesReport> GetTopNSalesReportsPerDealershipAndFile(string dealership, string fileName, int numberOfItems);

        public IEnumerable<SalesReport> GetSalesFilesPerDealership(string dealership, DateTime from, DateTime to);

    }
}
