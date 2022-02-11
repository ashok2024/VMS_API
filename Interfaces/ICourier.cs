using VMS.Models.Visitor;

namespace VMS_API.Interfaces
{
    public interface ICourier
    {
        Task<List<CourierModel>> GetCourier();
        Task<CourierModel> GetCourierById(int id);
        Task<string> SaveCourier(CourierModel courier);
        Task<string> EditCourier(CourierModel courier);
    }
}
