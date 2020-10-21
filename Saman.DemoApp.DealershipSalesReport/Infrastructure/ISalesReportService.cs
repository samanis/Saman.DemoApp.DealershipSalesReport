using Microsoft.AspNetCore.Http;
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
    }
}
