using Microsoft.AspNetCore.Mvc;
using VMS.Models.Account;
using VMS.Models.Admin;
using VMS_API.Interfaces;
using VMS_API.Models.ViewModels;

namespace VMS_API.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdmin _admin;
        public AdminController(IAdmin admin)
        {
            _admin = admin;
        }

        [HttpGet("GetMailSettings")]
        public ResponseModal GetMailSettings()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _admin.GetMailSettings();
                responseModal.Message = "mail settings details get successfully";
                responseModal.status = true;
                return responseModal;
            }
            catch (Exception ex)
            {
                responseModal.Message = ex.ToString();
                responseModal.status = false;
                return responseModal;
            }
        }
        [HttpGet("GetMailSettingsByid")]
        public ResponseModal GetMailSettingsByid(int id)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _admin.GetMailSettingsByid(id);
                responseModal.Message = "mail settings details get successfully";
                responseModal.status = true;
                return responseModal;
            }
            catch (Exception ex)
            {
                responseModal.Message = ex.ToString();
                responseModal.status = false;
                return responseModal;
            }
        }
        [HttpPost("SaveMalSettings")]
        public ResponseModal SaveVisitor([FromBody] MailSettingModel mail)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _admin.SaveMailSettings(mail);
                responseModal.status = true;
                return responseModal;
            }
            catch (Exception ex)
            {
                responseModal.Message = ex.ToString();
                responseModal.status = false;
                return responseModal;
            }
        }
        [HttpPut("EditMalSettings")]
        public ResponseModal EditMalSettings([FromBody] MailSettingModel mail)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _admin.EditMailSettings(mail);
                responseModal.status = true;
                return responseModal;
            }
            catch (Exception ex)
            {
                responseModal.Message = ex.ToString();
                responseModal.status = false;
                return responseModal;
            }
        }
        [HttpGet("GetDevice")]
        public ResponseModal GetDevice()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _admin.GetDevice();
                responseModal.Message = "device  details get successfully";
                responseModal.status = true;
                return responseModal;
            }
            catch (Exception ex)
            {
                responseModal.Message = ex.ToString();
                responseModal.status = false;
                return responseModal;
            }
        }
        [HttpGet("GetDeviceById")]
        public ResponseModal GetDeviceById(int id)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _admin.GetDeviceByid(id);
                responseModal.Message = "Device details get successfully";
                responseModal.status = true;
                return responseModal;
            }
            catch (Exception ex)
            {
                responseModal.Message = ex.ToString();
                responseModal.status = false;
                return responseModal;
            }
        }
        [HttpPost("SaveDevice")]
        public ResponseModal SaveDevice([FromBody] DeviceModel device)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _admin.SaveDevice(device);
                responseModal.status = true;
                return responseModal;
            }
            catch (Exception ex)
            {
                responseModal.Message = ex.ToString();
                responseModal.status = false;
                return responseModal;
            }
        }
        [HttpPut("EditDevice")]
        public ResponseModal EditDevice([FromBody] DeviceModel device)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _admin.EditDevice(device);
                responseModal.status = true;
                return responseModal;
            }
            catch (Exception ex)
            {
                responseModal.Message = ex.ToString();
                responseModal.status = false;
                return responseModal;
            }
        }
        [HttpGet("GetDeviceLog")]
        public ResponseModal GetDeviceLog()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _admin.GetDeviceLog();
                responseModal.Message = "device log details get successfully";
                responseModal.status = true;
                return responseModal;
            }
            catch (Exception ex)
            {
                responseModal.Message = ex.ToString();
                responseModal.status = false;
                return responseModal;
            }
        }
        [HttpGet("GetApiMonitorLog")]
        public ResponseModal GetApiMonitorLog()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _admin.GetApiMonitorLog();
                responseModal.Message = "API monitor log details get successfully";
                responseModal.status = true;
                return responseModal;
            }
            catch (Exception ex)
            {
                responseModal.Message = ex.ToString();
                responseModal.status = false;
                return responseModal;
            }
        }
        [HttpPost("Login")]
        public ResponseModal Login([FromBody] LoginModel login)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                var res = _admin.Login(login);
                if (res.Result.Message == "invalid username and password")
                {
                    responseModal.status = false;
                    responseModal.Message = "Login failed Invalid username and password";
                    return responseModal;
                }
                else
                {
                    responseModal.Data = res;
                    responseModal.status = true;
                    responseModal.Message = "Login success";
                    return responseModal;
                }
               
              
            }
            catch (Exception ex)
            {
                responseModal.Message = ex.ToString();
                responseModal.status = false;
                return responseModal;
            }
        }
    }
}
