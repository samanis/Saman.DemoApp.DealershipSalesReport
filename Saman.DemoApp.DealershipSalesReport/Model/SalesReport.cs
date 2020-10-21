using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Model
{
    public class SalesReport
    {
        public int Id { get; set; }
        public int DealNumber { get; set; }

        public string FileName { get; set; }

        public string CustomerName { get; set; }

        public string DealershipName { get; set; }

        public string Vehicle { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
    }
}
