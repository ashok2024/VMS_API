using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VMS.Models;
using VMS.Models.Account;
using VMS.Models.Admin;
using VMS.Models.Visitor;
using VMS_API.Interfaces;
using VMS_API.Models;

namespace VMS_API.Services
{
    public class AdminService : IAdmin
    {
        private VMSDBContext _vMSDBContext;
        public AdminService(VMSDBContext vMSDBContext)
        {
            _vMSDBContext = vMSDBContext;
        }


        public async Task<UserModel> Login(LoginModel log)
        {
            UserModel user = new UserModel();
            try
            {
               

                var UserData = _vMSDBContext.UserTbs.Where(c => c.UserName == log.UserName && c.Password == log.Password).FirstOrDefault();

                if (UserData != null)
                {
                    user.UserId = UserData.UserId;
                    user.Name = UserData.FirstName + " " + UserData.LastName;
                    user.FirstName = UserData.FirstName;
                    user.LastName = UserData.LastName;
                    user.Phone = UserData.Phone;
                    user.Email = UserData.Email;
                    user.BirthDate = Convert.ToDateTime(UserData.BirthDate);
                    user.UserName = UserData.UserName;
                    user.Password = UserData.Password;
                    user.Address = UserData.Address;
                    user.UserType = UserData.UserType;                // Keep User and User Roles in Cache


                }
                else
                {
                    user.Message = "invalid username and password";
                }
            }
            catch (Exception ex)            
            {                
            }

            return user;
        }

        public async Task<List<MailSettingModel>> GetMailSettings()
        {
            List<MailSettingModel> Model = new List<MailSettingModel>();
            try
            {
                var data = _vMSDBContext.MailSettingTbs.ToList().OrderByDescending(d => d.Id);

                foreach (var item in data)
                {
                    MailSettingModel courier = new MailSettingModel();
                    courier.Id = item.Id;
                    courier.Host = item.Host;
                    courier.smtpfrom = item.Smtpfrom;
                    courier.port = Convert.ToString(item.Port);
                    courier.username = item.Username;
                    courier.password = item.Password;
                    Model.Add(courier);
                }
            }
            catch (Exception ex)
            {
                return Model;
                throw ex;
            }
            return Model;
        }

        public async Task<MailSettingModel> GetMailSettingsByid(int Id)
        {
            MailSettingModel Model = new MailSettingModel();
            try
            {
                var data = _vMSDBContext.MailSettingTbs.Where(d => d.Id == Id).FirstOrDefault();

                Model.Id = data.Id;
                Model.Host = data.Host;
                Model.smtpfrom = data.Smtpfrom;
                Model.port = Convert.ToString(data.Port);
                Model.username = data.Username;
                Model.password = data.Password;
            }
            catch (Exception ex)
            {
                return Model;
                throw ex;
            }
            return Model;
        }

        public async Task<string> SaveMailSettings(MailSettingModel mail)
        {
            MailSettingTb check = new MailSettingTb();
            check.Smtpfrom = mail.smtpfrom;
            check.Port = Convert.ToInt32(mail.port);
            check.Username = mail.username;
            check.Password = mail.password;
            _vMSDBContext.MailSettingTbs.Add(check);
            _vMSDBContext.SaveChanges();
            return "mail settings save success";
        }
        public async Task<string> EditMailSettings(MailSettingModel mail)
        {
            var check = _vMSDBContext.MailSettingTbs.Where(d => d.Id == mail.Id).FirstOrDefault();

            check.Host = mail.Host;
            check.Smtpfrom = mail.smtpfrom;
            check.Port = Convert.ToInt32(mail.port);
            check.Username = mail.username;
            check.Password = mail.password;
            _vMSDBContext.Entry(check).State = EntityState.Modified;
            _vMSDBContext.SaveChanges();
            return "mail settings edit success";

        }

        public async Task<List<DeviceModel>> GetDevice()
        {
            List<DeviceModel> Model = new List<DeviceModel>();

            var data = _vMSDBContext.DevicesTbs.ToList().OrderByDescending(d => d.DeviceId);
            DeviceModel courier = new DeviceModel();
            foreach (var item in data)
            {

                courier.DeviceId = item.DeviceId;
                courier.DeviceName = item.DeviceName;
                courier.DeviceSerialNo = item.DeviceSerialNo;
                courier.DeviceAccountId = item.DeviceAccountId;
                courier.DeviceStatus = item.DeviceStatus;
                courier.DeviceLocation = item.DeviceLocation;
                courier.DeviceIPAddress = item.DeviceIpaddress;
                courier.Port = item.Port;
                courier.UserName = item.UserName;
                courier.Password = item.Password;

                string url = "http://" + item.DeviceIpaddress + ":" + item.Port + "/ISAPI/ContentMgmt/DeviceMgmt/deviceList?format=json";

                string req = "{\"SearchDescription\" : {\"position\":0,\"maxResult\":5}}";

                //req = string.Empty;
                string reps = string.Empty;
                string strMatchNum = string.Empty;
                clienthttp clnt = new clienthttp();
                int iet = clnt.HttpRequest(item.UserName, item.Password, url, "POST", req, ref reps);
                if (iet == (int)HttpStatus.Http200)
                {
                    DeviceSearchRoot dr = JsonConvert.DeserializeObject<DeviceSearchRoot>(reps);
                    strMatchNum = Convert.ToString(dr.SearchResult.numOfMatches);

                    if ("0" != strMatchNum)
                    {
                        foreach (var dev in dr.SearchResult.MatchList)
                        {
                            if (dev.Device.EhomeParams.EhomeID == item.DeviceAccountId)
                            {
                                var devicedt = dev.Device;
                                courier.DeviceStatus = devicedt.devStatus;
                            }
                        }
                    }
                }
                else
                {
                    courier.DeviceStatus = "Not Available";
                }
            }
            Model.Add(courier);
            return Model;
        }

        public async Task<DeviceModel> GetDeviceByid(int id)
        {
            DeviceModel Model = new DeviceModel();

            try
            {
                var item = _vMSDBContext.DevicesTbs.Where(d => d.DeviceId == id).FirstOrDefault();

                Model.DeviceId = item.DeviceId;
                Model.DeviceName = item.DeviceName;
                Model.DeviceSerialNo = item.DeviceSerialNo;
                Model.DeviceAccountId = item.DeviceAccountId;
                Model.DeviceStatus = item.DeviceStatus;
                Model.DeviceLocation = item.DeviceLocation;
                Model.DeviceIPAddress = item.DeviceIpaddress;
                Model.Port = item.Port;
                Model.UserName = item.UserName;
                Model.Password = item.Password;
            }
            catch (Exception ex)
            {
                return Model;
            }
            return Model;
        }

        public async Task<string> SaveDevice(DeviceModel device)
        {
            DevicesTb tB = new DevicesTb();
            tB.DeviceName = device.DeviceName;
            tB.DeviceSerialNo = device.DeviceSerialNo;
            tB.DeviceLocation = device.DeviceLocation;
            tB.DeviceAccountId = device.DeviceAccountId;
            tB.DeviceStatus = device.DeviceStatus;
            tB.DeviceIpaddress = device.DeviceIPAddress;
            tB.Port = device.Port;
            tB.UserName = device.UserName;
            tB.Password = device.Password;
            _vMSDBContext.DevicesTbs.Add(tB);
            _vMSDBContext.SaveChanges();

            string url = "http://" + device.DeviceIPAddress + ":" + device.Port + "/ISAPI/ContentMgmt/DeviceMgmt/deviceList?format=json";

            string req = "{\"deviceinlist\" : [{\"device\": {\"protocoltype\": \"ehomevs\",\"ehomeparams\": {\"ehomeid\":\"1234abcd\",\"ehomekey\":\"1234567a\"},\"devname\": \"testingapi\",\"devtype\": \"accesscontrol\"}}]}";
            string reps = string.Empty;

            clienthttp clnt = new clienthttp();
            int iet = clnt.HttpRequest(device.UserName, device.Password, url, "POST", req, ref reps);
            if (iet == (int)HttpStatus.Http200)
            {
                ApiMonitorTb at = new ApiMonitorTb();
                at.Action = "Add Device";
                at.Page = "Device";
                at.Time = DateTime.Now;
                _vMSDBContext.ApiMonitorTbs.Add(at);
                _vMSDBContext.SaveChanges();
            }

            return "device save success";

        }

        public async Task<string> EditDevice(DeviceModel device)
        {
            var check = _vMSDBContext.DevicesTbs.Where(d => d.DeviceId == device.DeviceId).FirstOrDefault();

            check.DeviceName = device.DeviceName;
            check.DeviceSerialNo = device.DeviceSerialNo;
            check.DeviceLocation = device.DeviceLocation;
            check.DeviceAccountId = device.DeviceAccountId;
            check.DeviceStatus = device.DeviceStatus;
            check.DeviceIpaddress = device.DeviceIPAddress;
            // check.Port = device.Port;
            check.UserName = device.UserName;
            // check.Password = device.Password;
            _vMSDBContext.Entry(check).State = EntityState.Modified;
            _vMSDBContext.SaveChanges();
            string url = "http://" + device.DeviceIPAddress + ":" + device.Port + "/ISAPI/ContentMgmt/DeviceMgmt/deviceList?format=json";

            string req = "{\"deviceinlist\" : [{\"device\": {\"protocoltype\": \"ehomevs\",\"ehomeparams\": {\"ehomeid\":\"1234abcd\",\"ehomekey\":\"1234567a\"},\"devname\": \"testingapi\",\"devtype\": \"accesscontrol\"}}]}";
            string reps = string.Empty;

            clienthttp clnt = new clienthttp();
            int iet = clnt.HttpRequest(device.UserName, device.Password, url, "POST", req, ref reps);
            if (iet == (int)HttpStatus.Http200)
            {
                ApiMonitorTb at = new ApiMonitorTb();
                at.Action = "Add Device";
                at.Page = "Device";
                at.Time = DateTime.Now;
                _vMSDBContext.ApiMonitorTbs.Add(at);
                _vMSDBContext.SaveChanges();
            }
            return "device save success";
        }

        public async Task<List<EmployeePunchModel>> GetDeviceLog()
        {
            List<EmployeePunchModel> Model = new List<EmployeePunchModel>();

            try
            {
                var data = _vMSDBContext.EmployeePunchTbs.ToList().OrderBy(d => d.Id);

                foreach (var item in data)
                {
                    EmployeePunchModel courier = new EmployeePunchModel();
                    courier.major = item.Major;
                    courier.minor = item.Minor;
                    courier.time = Convert.ToDateTime(item.Time);
                    courier.Atime = Convert.ToDateTime(item.Time).ToString("hh:mm:ss");
                    courier.ADate = Convert.ToDateTime(item.Time).ToString("dd/MM/yy");
                    courier.employeeNoString = item.EmployeeNoString != null ? item.EmployeeNoString : "";
                    courier.cardNo = item.CardNo != null ? item.CardNo : "";
                    courier.cardReaderNo = item.CardReaderNo != null ? item.CardReaderNo : "";
                    courier.doorNo = item.DoorNo != null ? item.DoorNo : "";
                    courier.currentVerifyMode = item.CurrentVerifyMode;
                    courier.serialNo = item.SerialNo;
                    courier.type = item.Type;
                    courier.mask = item.Mask;
                    courier.name = item.Name != null ? item.Name : "";
                    courier.userType = item.UserType != null ? item.UserType : "";
                    courier.deviceAccountId = item.DeviceAccountId;
                    Model.Add(courier);
                }
            }
            catch (Exception ex)
            {
                return Model;
            }
            return Model;
        }

        public async Task<List<ApiMonitorModel>> GetApiMonitorLog()
        {
            List<ApiMonitorModel> Model = new List<ApiMonitorModel>();

            try
            {
                var data = _vMSDBContext.ApiMonitorTbs.ToList().OrderByDescending(d => d.Id);
                foreach (var item in data)
                {
                    ApiMonitorModel courier = new ApiMonitorModel();
                    courier.Id = item.Id;
                    courier.Page = item.Page;
                    courier.Action = item.Action;
                    courier.EmpCode = item.EmpCode;
                    courier.EmpName = item.EmpName;
                    courier.DeviceSRNo = item.DeviceSrno;
                    courier.DeviceName = item.DeviceName;
                    courier.Status = item.Status;
                    courier.Command = item.Command;
                    courier.time = Convert.ToDateTime(item.Time);
                    Model.Add(courier);
                }
            }
            catch (Exception ex)
            {
                return Model;
            }
            return Model;
        }

        public async Task<List<VisitorEntryModel>> GetApproveVisitorList(bool userid, int employeeid)
        {
            List<VisitorEntryModel> Model = new List<VisitorEntryModel>();

            var visitors = (from d in _vMSDBContext.VisitorEntryTbs
                            join c in _vMSDBContext.VisitorStatusTbs on d.Id equals c.VisitId
                            where c.Status == "Approve" && (userid ? d.EmployeeId == employeeid : true)
                            select d).ToList();
            //var visitors = entities.VisitorEntryTBs.ToList().OrderByDescending(d => d.Id);

            foreach (var item in visitors)
            {
                //var status = entities.VisitorStatusTBs.Where(d => d.VisitId == item.Id).FirstOrDefault();

                //if (status != null)
                //{
                //    if (status.Status == "Approve")
                //    {
                VisitorEntryModel visitor = new VisitorEntryModel();
                visitor.Id = item.Id;
                visitor.VisitorId = item.VisitorId;
                visitor.Name = item.Name;
                visitor.Company = item.Company;
                visitor.Contact = item.Contact;
                var user = _vMSDBContext.UserTbs.Where(d => d.UserId == item.EmployeeId).FirstOrDefault();
                visitor.EmployeeId = Convert.ToInt32(item.EmployeeId);
                visitor.EmployeeName = user.FirstName + " " + user.LastName;
                visitor.EmployeeDepartment = user.Department;
                visitor.InTime = item.InTime;
                visitor.OutTime = item.OutTime;
                visitor.VisitDateFrom = Convert.ToDateTime(item.FromDate);
                visitor.VisitDateTo = Convert.ToDateTime(item.ToDate);
                visitor.Purpose = item.Purpose;
                Model.Add(visitor);
                //    }
                //}
            }
            return Model;
        }

        public async Task<List<VisitorEntryModel>> GetRejectVisitorList(bool userid, int employeeid)
        {
            List<VisitorEntryModel> Model = new List<VisitorEntryModel>();

            var visitors = (from d in _vMSDBContext.VisitorEntryTbs
                            join c in _vMSDBContext.VisitorStatusTbs on d.Id equals c.VisitId
                            where c.Status == "Reject" && (userid ? d.EmployeeId == employeeid : true)
                            select d).ToList();
            //var visitors = entities.VisitorEntryTBs.ToList().OrderByDescending(d => d.Id);

            foreach (var item in visitors)
            {
                //var status = entities.VisitorStatusTBs.Where(d => d.VisitId == item.Id).FirstOrDefault();

                //if (status != null)
                //{
                //    if (status.Status == "Approve")
                //    {
                VisitorEntryModel visitor = new VisitorEntryModel();
                visitor.Id = item.Id;
                visitor.VisitorId = item.VisitorId;
                visitor.Name = item.Name;
                visitor.Company = item.Company;
                visitor.Contact = item.Contact;
                var user = _vMSDBContext.UserTbs.Where(d => d.UserId == item.EmployeeId).FirstOrDefault();
                visitor.EmployeeId = Convert.ToInt32(item.EmployeeId);
                visitor.EmployeeName = user.FirstName + " " + user.LastName;
                visitor.EmployeeDepartment = user.Department;
                visitor.InTime = item.InTime;
                visitor.OutTime = item.OutTime;
                visitor.VisitDateFrom = Convert.ToDateTime(item.FromDate);
                visitor.VisitDateTo = Convert.ToDateTime(item.ToDate);
                visitor.Purpose = item.Purpose;
                Model.Add(visitor);
                //    }
                //}
            }
            return Model;
        }
    }
}
