using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Model
{
    public class SalesReportFactory
    {
        private SalesReport CreateSalesReport(string input, string fileName)
        {
            string[] reportArray = CreateSalesDataArray(input);
            SalesReport salesReport = new SalesReport();
            salesReport.DealNumber = int.Parse(reportArray[0]);
            salesReport.CustomerName = reportArray[1];
            salesReport.DealershipName = reportArray[2];
            salesReport.Vehicle = reportArray[3];
            salesReport.Price = decimal.Parse($"{reportArray[4].Replace("\"", "")}");
            salesReport.Date = DateTime.Parse(reportArray[5]);
            if (string.IsNullOrEmpty(fileName.Trim()))
                throw new Exception("Can't build the record, File name is empty");
            salesReport.FileName = fileName;
            return salesReport;
        }


        private static string[] CreateSalesDataArray(string input)
        {
            var values = input.Split(',');
            List<string> strings = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();
            for (int idx = 0; idx < values.Length; idx++)
            {
                if (values[idx].StartsWith("\""))
                {
                    stringBuilder.Append(values[idx]);
                    idx++;
                    while (values[idx].EndsWith("\""))
                    {
                        stringBuilder.Append(values[idx]);
                        idx++;
                    }
                    string tempStr = stringBuilder.ToString();
                    strings.Add(tempStr);
                    stringBuilder.Clear();
                }
                strings.Add(values[idx]);
            }
            var finalArray = strings.ToArray();
            return finalArray;
        }

        public IEnumerable<SalesReport> CreateSalesReports(string[] salesFileLines, string fileName)
        {
            var salesReports = new List<SalesReport>();
            for(int index =1;index < salesFileLines.Length; index++)
            {
                var salesReport = CreateSalesReport(salesFileLines[index], fileName);
                salesReports.Add(salesReport);
            }

            return salesReports;
        }

        
    }
}
