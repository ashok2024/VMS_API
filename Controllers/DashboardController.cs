using Microsoft.AspNetCore.Mvc;
using VMS_API.Interfaces;
using VMS_API.Models.ViewModels;

namespace VMS_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboard _dashbaord;
        public DashboardController(IDashboard dashboard)
        { 
            _dashbaord = dashboard;
        }
        [HttpGet(Name = "GetDashboardDetails")]
        public ResponseModal GetDashboardDetails()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _dashbaord.GetDashboardDetaisl();
                responseModal.Message = "Dashboard details get successfully";
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

    }
}
