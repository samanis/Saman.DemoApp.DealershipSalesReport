using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure
{
    public interface INewUploadedFileEventHandler
    {
        public void SubscribeToNewFileUploadedEvent(NewFileUploadedEvent newFileUploadedEvent);
    }
}
