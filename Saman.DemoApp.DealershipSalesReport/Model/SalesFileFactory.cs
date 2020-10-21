using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Model
{
    public class SalesFileFactory
    {
        public SalesFileBase CreateSalesFile(IFormFile formFile,DateTime uploadedDateTime)
        {
            string extension = Path.GetExtension(formFile.FileName);
            switch (extension)
            {
                case ".csv":
                    {
                        string fileContent = ReadContentFromIFormFile(formFile);
                        var salesFile = new CSVSalesFile(fileContent, uploadedDateTime,
                            $"{GenerateFileName(uploadedDateTime)}.csv");

                        SetSalesFileEncoding(salesFile);

                        return salesFile;
                    }
                default:
                    throw new ApplicationException("Uploaded file type does not supported");
            }
        }

        private static void SetSalesFileEncoding(CSVSalesFile salesFile)
        {
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(salesFile.FileContent);
            byte[] isoBytes = Encoding.Convert(utf8, encoding, utfBytes);
            salesFile.FileContent = encoding.GetString(isoBytes);
        }

        private static string ReadContentFromIFormFile(IFormFile formFile)
        {
            string fileContent;

            using (var reader = new StreamReader(formFile.OpenReadStream(), Encoding.GetEncoding("iso-8859-1")))
            {
                fileContent = reader.ReadToEnd();
            }

            return fileContent;
        }

        private static string GenerateFileName(DateTime dateTime)
        {
            return $"{dateTime.ToString("yyyyMMddThhmmssfffff", CultureInfo.CreateSpecificCulture("en-ca"))}";
        }
    }
}
