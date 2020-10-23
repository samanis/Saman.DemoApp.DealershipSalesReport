using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saman.DemoApp.DealershipSalesReport.Infrastructure;

namespace Saman.DemoApp.DealershipSalesReport.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DealerShipController : ControllerBase
    {
        ISalesReportService _salesReportService;

        public DealerShipController(ISalesReportService salesReportService)
        {
            _salesReportService = salesReportService ?? throw new ArgumentNullException(nameof(salesReportService));
        }

        [HttpGet]
        public IActionResult Dealerships()
        {
            try
            {
                var result = _salesReportService.GetDealerships();
                if(result.Any())
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