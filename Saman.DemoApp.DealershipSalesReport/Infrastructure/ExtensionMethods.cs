using Saman.DemoApp.DealershipSalesReport.Infrastructure.ViewModels;
using Saman.DemoApp.DealershipSalesReport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure
{
    public static class ExtensionMethods
    {

        public static DealershipFile ConvertToDealershipFile(this SalesReport salesReport)
        {
            try
            {
                DealershipFile dealershipFile = new DealershipFile();
                dealershipFile.Dealership = salesReport.DealershipName;
                dealershipFile.FileName = salesReport.FileName;              
                return dealershipFile;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Could not create Dealer shipFile ", ex);
            }
        }

        public static IEnumerable<DealershipFile> ConvertToDealershipFiles(this IEnumerable<SalesReport> salesReports)
        {
            var dealerShipList = new List<DealershipFile>();
            try
            {
                foreach (var item in salesReports)
                {
                    dealerShipList.Add(item.ConvertToDealershipFile());
                }
                return dealerShipList;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Could not create Dealer shipFile list ", ex);
            }
        }
    }
}
