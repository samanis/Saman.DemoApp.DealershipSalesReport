using Saman.DemoApp.DealershipSalesReport.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure
{
    public interface ISalesReportRepository
    {

        public void InsertSalesReport(SalesReport salesReport);

        public void InsertBulkSalesReports(IEnumerable<SalesReport> salesReports);
    }
}
