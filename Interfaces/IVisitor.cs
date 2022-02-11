using VMS.Models.Visitor;

namespace VMS_API.Interfaces
{
    public interface IVisitor
    {
        Task<List<VisitorEntryModel>> GetVisitor();
        Task<VisitorEntryModel> GetVisitorById(int id);
        Task<VisitorEntryModel> GetVisitorByContactNo(string contactNo);
        Task<string> SaveVisitor(VisitorEntryModel visitor);
        Task<string> EditVisitor(VisitorEntryModel visitor);
        Task<List<CourierModel>> GetCourier();
       
    }
}
