using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Model.Commands
{
    public class ReportFile : Entity<int>
    {
        public string FileName { get; set; }
    }
}
