using Microsoft.EntityFrameworkCore;
using Saman.DemoApp.DealershipSalesReport.Model;
using Saman.DemoApp.DealershipSalesReport.Model.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure.DataAccess
{
    public class SalesReportCommandRepository : ISalesRepository
    {
        SalesReportDBContext _context;

        public SalesReportCommandRepository(SalesReportDBContext salesReportConext)
        {
            _context = salesReportConext ?? throw new ArgumentNullException(nameof(salesReportConext));
        }

        public void InsertBulkSales(IEnumerable<SaleRecord> sales)
        {
            IEnumerable<Dealership> query =
                from c in sales.Select(x=>x.Dealership)
                where !(from o in _context.DelaerShips
                        select o.Id)
                       .Contains(c.Id)
                select c;

            foreach (var dealership in query.ToList())
            {
                _context.DelaerShips.Add(dealership);
            }
            
            _context.SaveChanges();

            foreach (var sale in sales)
            {
                SalesReport salesReport = sale.ConvertToSalesReport();
                _context.Sales.Add(sale);
                _context.SalesReports.Add(salesReport);
            }
            _context.SaveChanges();
        }

        public void InsertSales(SaleRecord sales)
        {
            SalesReport salesReport = sales.ConvertToSalesReport();
            _context.Sales.Add(sales);
            _context.SalesReports.Add(salesReport);
            _context.SaveChanges();
        }

    }
}
