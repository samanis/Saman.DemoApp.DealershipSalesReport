using Saman.DemoApp.DealershipSalesReport.Model.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure.DataAccess
{
    public interface IDealerShipRepository
    {
        void InsertDealership(Dealership dealership);
        void InsertBulkDealership(IEnumerable<Dealership> dealerships);

        IEnumerable<Dealership> FindByIdList(IEnumerable<int> idList);

        IEnumerable<Dealership> FindDealerShipsByName(IEnumerable<string> NameList);
    }
}
