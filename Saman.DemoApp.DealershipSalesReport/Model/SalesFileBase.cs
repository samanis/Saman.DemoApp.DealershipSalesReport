using System;
using System.Collections.Generic;

namespace Saman.DemoApp.DealershipSalesReport.Model
{
    public abstract class SalesFileBase : ISalesFile
    {
        protected SalesFileBase(string fileContent, DateTime uploadedDateTime, string fileName)
        {
            try
            {
                FileContent = fileContent ?? throw new ArgumentNullException(nameof(fileContent));
                UploadedDateTime = uploadedDateTime;
                FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
                BasicValidation();
                Validate();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can't build model object",ex);
            }
        }

        public string FileContent { get; set; }
        public DateTime UploadedDateTime { get; set; }
        public abstract SalesFileType SalesFileType { get; }

        public string FileName { get; set; }

        public abstract void Validate();

        private void BasicValidation()
        {
            if (string.IsNullOrEmpty(FileContent.Trim()))
                throw new ArgumentException("File is empty or null");
        }
    }

}
