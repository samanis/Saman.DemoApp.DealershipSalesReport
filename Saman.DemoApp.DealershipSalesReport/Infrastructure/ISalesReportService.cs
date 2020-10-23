using Microsoft.AspNetCore.Http;
using Saman.DemoApp.DealershipSalesReport.Infrastructure.ViewModels;
using Saman.DemoApp.DealershipSalesReport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure
{
    public interface ISalesReportService
    {
        void AddBulkSalesReports(IFormFile formFile, DateTime uploadedDateTime);
        CSVSalesFile GetCSVSASlesFile();

        IEnumerable<string> GetDealerships();

        IEnumerable<DealershipFile> GetDealershipFiles(string dealershipName, DateTime from, DateTime to);

        IEnumerable<SalesReport> GetTopNSalesReportsPerFile(DealershipFile dealershipFile,int topNumbers);
    }
}
