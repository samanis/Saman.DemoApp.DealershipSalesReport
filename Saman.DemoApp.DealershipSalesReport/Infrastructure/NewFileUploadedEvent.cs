using System;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure
{
    public class NewFileUploadedEvent
    {
        public NewFileUploadedEvent(string newUploadedFileName, DateTime uploadDateTime)
        {
            NewUploadedFileName = newUploadedFileName ?? throw new ArgumentNullException(nameof(newUploadedFileName));
            UploadDateTime = uploadDateTime;
        }

        public string NewUploadedFileName { get; set; }

        public DateTime UploadDateTime { get; set; }

    }
}
