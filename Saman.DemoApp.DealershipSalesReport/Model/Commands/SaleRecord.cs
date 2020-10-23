using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Model.Commands
{
    public class SaleRecord:Entity<int>
    {
        public int DealNumber { get; set; }

        public ReportFile ReportFile { get; set; }

        public string CustomerName { get; set; }

        public Dealership Dealership { get; set; }

        public string Vehicle { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
    }
}
