using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Saman.DemoApp.DealershipSalesReport.Infrastructure;
using Saman.DemoApp.DealershipSalesReport.Model;

namespace Saman.DemoApp.DealershipSalesReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewFileUploadedController : ControllerBase
    {
        ISalesReportService _salesReportService;

        public NewFileUploadedController(ISalesReportService salesReportService)
        {
            _salesReportService = salesReportService;
        }

        [HttpPost]
        public IActionResult CreateSalesReport()
        {
            IFormFile file = Request.Form.Files[0];
            _salesReportService.AddBulkSalesReports(file, DateTime.UtcNow);
            return Ok();
        }
    }
}
