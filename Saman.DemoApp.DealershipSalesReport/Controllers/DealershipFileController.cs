using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saman.DemoApp.DealershipSalesReport.Infrastructure;

namespace Saman.DemoApp.DealershipSalesReport.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DealershipFileController : ControllerBase
    {
        ISalesReportService _salesReportService;

        public DealershipFileController(ISalesReportService salesReportService)
        {
            _salesReportService = salesReportService ?? throw new ArgumentNullException(nameof(salesReportService));
        }

        [HttpGet]
        public IActionResult GetDealershipFileReport([FromQuery(Name = "dealership")]string dealershipName,
            [FromQuery(Name = "from")]string from,
            [FromQuery(Name = "to")]string to)
        {
            try
            {
                var startDate = BuildDateTimeFromYAFormat(from);
                var endDate = BuildDateTimeFromYAFormat(to);
                var result = _salesReportService.GetDealershipFiles(dealershipName.Replace("\"", ""), startDate, endDate);
                if (result.Any())
                    return Ok(result);
                return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DateTime BuildDateTimeFromYAFormat(string dateString)
        {
            Regex r = new Regex(@"^\d{4}\d{2}\d{2}$");
            if (!r.IsMatch(dateString))
            {
                throw new FormatException(
                    string.Format("{0} is not the correct format. Should be yyyyMMdd", dateString));
            }

            DateTime dt = DateTime.ParseExact(dateString, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

            return dt;
        }

    }
}