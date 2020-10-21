using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Model
{
    public class SalesReportFactory
    {
        public SalesReport BuildSalesReport(string input, string fileName)
        {
            
            var values = input.Split(',');
            List<string> strings = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();
            for(int idx = 0; idx<values.Length; idx++)
            {
                if(values[idx].StartsWith("\""))
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
            SalesReport salesReport = new SalesReport();
            salesReport.DealNumber = int.Parse(finalArray[0]);
            salesReport.CustomerName = finalArray[1];
            salesReport.DealershipName = finalArray[2];
            salesReport.Vehicle = finalArray[3];
            salesReport.Price = decimal.Parse($"{finalArray[4].Replace("\"","")}");
            salesReport.Date = DateTime.Parse(finalArray[5]);
            if (string.IsNullOrEmpty(fileName.Trim()))
                throw new Exception("Can't build the record, File name is empty");
            salesReport.FileName = fileName;
            return salesReport;
        }

        public IEnumerable<SalesReport> BuildSalesReports(CSVSalesFile cSVSalesFile)
        {
            var salesReports = new List<SalesReport>();
            for(int index =1;index < cSVSalesFile.FileLines.Length; index++)
            {
                var salesReport = BuildSalesReport(cSVSalesFile.FileLines[index],cSVSalesFile.FileName);
                salesReports.Add(salesReport);
            }

            return salesReports;
        }
    }
}
