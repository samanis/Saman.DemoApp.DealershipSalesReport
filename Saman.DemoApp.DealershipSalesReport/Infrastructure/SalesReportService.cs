using Microsoft.AspNetCore.Http;
using Saman.DemoApp.DealershipSalesReport.Model;
using System;
using System.Text;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure
{
    public class SalesReportService : ISalesReportService
    {
        ISalesReportRepository _salesReportRepository;

        public SalesReportService(ISalesReportRepository salesReportRepository)
        {
            _salesReportRepository = salesReportRepository ?? throw new ArgumentNullException(nameof(salesReportRepository));
        }

        public void AddBulkSalesReports(IFormFile formFile, DateTime uploadedDateTime)
        {
            try
            {
                SalesFileFactory salesFileFactory = new SalesFileFactory();
                var salesFile = salesFileFactory.CreateSalesFile(formFile, uploadedDateTime);

                SalesReportFactory salesReportFactory = new SalesReportFactory();
                var salesReports = salesReportFactory.BuildSalesReports((CSVSalesFile)salesFile);
                _salesReportRepository.InsertBulkSalesReports(salesReports);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not save reports");
            }
        }


        public CSVSalesFile GetCSVSASlesFile()
        {
            throw new NotImplementedException();
        }
    }
}
