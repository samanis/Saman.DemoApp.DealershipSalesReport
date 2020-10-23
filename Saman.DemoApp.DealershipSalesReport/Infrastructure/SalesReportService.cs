using Microsoft.AspNetCore.Http;
using Saman.DemoApp.DealershipSalesReport.Infrastructure.DataAccess;
using Saman.DemoApp.DealershipSalesReport.Infrastructure.ViewModels;
using Saman.DemoApp.DealershipSalesReport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var salesReports = salesReportFactory.CreateSalesReports(((CSVSalesFile)salesFile).FileLines, salesFile.FileName);

                _salesReportRepository.InsertBulkSalesReports(salesReports);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not save reports",ex);
            }
        }


        public CSVSalesFile GetCSVSASlesFile()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DealershipFile> GetDealershipFiles(string dealershipName, DateTime from, DateTime to)
        {
            try
            {
                IEnumerable<SalesReport> salesReports = _salesReportRepository.GetSalesFilesPerDealership(dealershipName, from, to);
                return salesReports.ConvertToDealershipFiles();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can't find file list", ex);
            }
        }

        public IEnumerable<string> GetDealerships()
        {
            try
            {
                return _salesReportRepository.GetDealershipNames();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Could not find dealerships", ex);
            }
        }

        public IEnumerable<SalesReport> GetTopNSalesReportsPerFile(DealershipFile dealershipFile, int topNumbers)
        {
            try
            {
                IEnumerable<SalesReport> salesReports = _salesReportRepository.GetTopNSalesReportsPerDealershipAndFile(dealershipFile.Dealership,
                    dealershipFile.FileName
                    , topNumbers);
                return salesReports;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can't find sales report list", ex);
            }
        }
    }
}
