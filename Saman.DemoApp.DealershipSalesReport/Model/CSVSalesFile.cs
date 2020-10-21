using System;
using System.Collections.Generic;
using System.Linq;

namespace Saman.DemoApp.DealershipSalesReport.Model
{
    public class CSVSalesFile : SalesFileBase
    {
        public CSVSalesFile(string fileContent, DateTime uploadedDateTime, string fileName) : base(fileContent, uploadedDateTime, fileName)
        {
        }

        public override SalesFileType SalesFileType => SalesFileType.CSV;

        public string[] FileLines => FileContent.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

        public override void Validate()
        {
            if (FileLines.Count() < 2)
            {
                throw new Exception("CSV file has no content");
            }
        }
    }
}
