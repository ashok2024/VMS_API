using VMS_API.Interfaces;
using VMS_API.Models;
using VMS_API.Models.ViewModels;

namespace VMS_API.Services
{
   
    public class DashboardService:IDashboard
    {
        private readonly VMSDBContext _context;
        public DashboardService(VMSDBContext context)
        {
            _context = context;
        }
        public async Task<DashboardCountData> GetDashboardDetaisl()
        { 
            DashboardCountData dashboardCountData = new DashboardCountData();
            dashboardCountData.TotalVisitor = _context.VisitorEntryTbs.Count();
            dashboardCountData.TotalVisited = _context.VisitorStatusTbs.Where(d => d.Status == "Approve").ToList().Count();
            dashboardCountData.TotalUpcominVisit = _context.VisitorEntryTbs.Where(d => d.FromDate > DateTime.Now).ToList().Count();
            dashboardCountData.TotalRejectVisit = _context.VisitorStatusTbs.Where(d => d.Status == "Reject").ToList().Count();
            dashboardCountData.TotalDefaulters = 0;
            dashboardCountData.TotalDeliveries = _context.CourierTbs.ToList().Count();
            return dashboardCountData;
        }
    }

}
