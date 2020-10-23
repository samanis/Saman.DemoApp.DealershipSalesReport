using Saman.DemoApp.DealershipSalesReport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure.DataAccess
{
    public class SalesReportRepository : ISalesReportRepository
    {
        SalesReportDBContext _context;

        public SalesReportRepository(SalesReportDBContext salesReportConext)
        {
            _context = salesReportConext ?? throw new ArgumentNullException(nameof(salesReportConext));
        }

        public void InsertSalesReport(SalesReport salesReport)
        {
            try
            {
                _context.SalesReports.Add(salesReport);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void InsertBulkSalesReports(IEnumerable<SalesReport> salesReports)
        {
            try
            {
                foreach (var salesReport in salesReports)
                {
                    _context.SalesReports.Add(salesReport);
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<string> GetDealershipNames()
        {
            try
            {
                return _context.SalesReports.Select(x => x.DealershipName).Distinct().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<SalesReport> GetTopNSalesReportsPerDealershipAndFile(string dealership, string fileName, int numberOfItems)
        {
            try
            {
                IEnumerable<SalesReport> salesReports = _context.SalesReports.Where(x => x.DealershipName == dealership)
                        .Where(z => z.FileName == fileName)
                        .OrderBy(p => p.Price)
                        .Take(numberOfItems).ToList();
                return salesReports;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<SalesReport> GetSalesFilesPerDealership(string dealership, DateTime from, DateTime to)
        {
            try
            {
                IEnumerable<SalesReport> salesReports = _context.SalesReports.Where(x => x.DealershipName == dealership)
                       .Where(y => y.Date >= from && y.Date <= to).ToList();
                return salesReports;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
