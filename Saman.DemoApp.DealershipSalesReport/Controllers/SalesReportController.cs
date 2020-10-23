using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Saman.DemoApp.DealershipSalesReport.Infrastructure;
using Saman.DemoApp.DealershipSalesReport.Infrastructure.ViewModels;
using Saman.DemoApp.DealershipSalesReport.Model;

namespace Saman.DemoApp.DealershipSalesReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesReportController : ControllerBase
    {
        ISalesReportService _salesReportService;

        public SalesReportController(ISalesReportService salesReportService)
        {
            _salesReportService = salesReportService;
        }

        [HttpPost]
        public IActionResult CreateSalesReport()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                if (file == null)
                    return BadRequest("Can't find the file");
                _salesReportService.AddBulkSalesReports(file, DateTime.UtcNow);
                return Created("","Sales report created successfuly");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult GetDealerShipSalesReport([FromQuery(Name = "dealership")]string dealershipName, [FromQuery(Name = "file")]string fileName)
        {
            try
            {
                DealershipFile dealershipFile = new DealershipFile()
                {
                    Dealership = dealershipName.Replace("\"", ""),
                    FileName = fileName.Replace("\"", "")
                };
                var result = _salesReportService.GetTopNSalesReportsPerFile(dealershipFile, 10);
                if (result.Any())
                    return Ok(result);
                return NotFound();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
