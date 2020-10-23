using Saman.DemoApp.DealershipSalesReport.Model;
using Saman.DemoApp.DealershipSalesReport.Model.Commands;
using System;
using System.Collections.Generic;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure.DataAccess
{
    public interface ISalesRepository
    {
        public void InsertSales(SaleRecord sales);

        public void InsertBulkSales(IEnumerable<SaleRecord> sales);


    }
}
