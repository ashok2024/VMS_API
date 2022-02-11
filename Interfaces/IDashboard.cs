using VMS.Models.Employee;
using VMS_API.Models.ViewModels;
namespace VMS_API.Interfaces
{
    public interface IDashboard
    {
        Task<DashboardCountData> GetDashboardDetaisl();
      
    }
}
