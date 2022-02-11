using VMS.Models.Employee;
using VMS.Models.Visitor;

namespace VMS_API.Interfaces
{
    public interface IEmployee
    {
        Task<EmployeeDashboardModel> GetEmployeeDashboardDetaisl(int UserId);
        Task<List<VisitorEntryModel>> GetEmployeVisitor(int userId);
        Task<string> SaveVisitorStatus(ApproveRejectModel userId);

        Task<List<VisitorEntryModel>> GetEmployeeScheduledVisit(int userId);
        Task<VisitorEntryModel> GetEmployeeScheduledVisitByid(int userId);
        Task<string> ScheduleVisit(VisitorEntryModel visitorEntryModel);
        Task<List<VisitorEntryModel>> ApproveVisitorReport(int userid );
        Task<List<VisitorEntryModel>> RejectVisitorReport(int userid);

    }
}
