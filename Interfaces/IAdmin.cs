using VMS.Models.Account;
using VMS.Models.Admin;
using VMS.Models.Visitor;

namespace VMS_API.Interfaces
{
    public interface IAdmin
    {
        Task<UserModel> Login(LoginModel loginModel);
        Task<List<MailSettingModel>> GetMailSettings();
        Task<MailSettingModel> GetMailSettingsByid(int id);
        Task<string> SaveMailSettings(MailSettingModel mailSettingModel);
        Task<string> EditMailSettings(MailSettingModel mailSettingModel);
        Task<List<DeviceModel>> GetDevice();
        Task<DeviceModel> GetDeviceByid(int id);
        Task<string> SaveDevice(DeviceModel device);
        Task<string> EditDevice(DeviceModel device);
        Task<List<EmployeePunchModel>> GetDeviceLog();
        Task<List<ApiMonitorModel>> GetApiMonitorLog();
        Task<List<VisitorEntryModel>> GetApproveVisitorList(bool userid , int employeeid);
        Task<List<VisitorEntryModel>> GetRejectVisitorList(bool userid ,int employeeid);



    }
}
