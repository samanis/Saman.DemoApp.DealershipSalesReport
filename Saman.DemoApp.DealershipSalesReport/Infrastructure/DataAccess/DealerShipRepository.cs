using Saman.DemoApp.DealershipSalesReport.Model.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saman.DemoApp.DealershipSalesReport.Infrastructure.DataAccess
{
    public class DealerShipRepository : IDealerShipRepository
    {
        SalesReportDBContext _context;

        public DealerShipRepository(SalesReportDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void InsertBulkDealership(IEnumerable<Dealership> dealerships)
        {
            foreach (var dealership in dealerships)
            {
                _context.DelaerShips.Add(dealership);
            }
            _context.SaveChanges();
        }

        public void InsertDealership(Dealership dealership)
        {
            _context.DelaerShips.Add(dealership);
            _context.SaveChanges();
        }

        public Dealership FindById(int id)
        {
            return _context.DelaerShips.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Dealership> FindByIdList(IEnumerable<int> idList)
        {
            return _context.DelaerShips.Where(x => idList.Contains(x.Id)).ToList();
        }

        public IEnumerable<Dealership> FindDealerShipsByName(IEnumerable<string> NameList)
        {
            var query = from p in _context.DelaerShips
            where NameList.Contains(p.Name)
            select p;
            return query.ToList();
        }
    }
}
