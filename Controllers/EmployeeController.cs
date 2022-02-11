using Microsoft.AspNetCore.Mvc;
using VMS.Models.Employee;
using VMS.Models.Visitor;
using VMS_API.Interfaces;
using VMS_API.Models.ViewModels;

namespace VMS_API.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet("GetEmployeeDashboard")]
        public ResponseModal GetEmployeeDashboard(int userid)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _employee.GetEmployeeDashboardDetaisl(userid);
                responseModal.Message = "employee dashboard  details get successfully";
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
        [HttpGet("GetEmployeeVisitor")]
        public ResponseModal GetEmployeeVisitor(int UserId)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _employee.GetEmployeVisitor(UserId);
                responseModal.Message = "employee visitor  details get successfully";
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
        [HttpPost("SaveStatus")]
        public ResponseModal SaveStatus([FromBody] ApproveRejectModel data)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _employee.SaveVisitorStatus(data);
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
        [HttpGet("GetEmployeeScheduledVisit")]
        public ResponseModal GetEmployeeScheduledVisit(int UserId)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _employee.GetEmployeeScheduledVisit(UserId);
                responseModal.Message = "employee visitor  details get successfully";
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
        [HttpGet("GetEmployeeScheduledVisitByid")]
        public ResponseModal GetEmployeeScheduledVisitByid(int UserId)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _employee.GetEmployeeScheduledVisitByid(UserId);
                responseModal.Message = "employee visitor  details get successfully";
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
        [HttpPost("GetEmployeeScheduledVisitByid")]
        public ResponseModal GetEmployeeScheduledVisitByid([FromBody] VisitorEntryModel data)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _employee.ScheduleVisit(data);
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
        [HttpGet("ApproveVisitorReport")]
        public ResponseModal ApproveVisitorReport(int UserId)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _employee.ApproveVisitorReport(UserId);
                responseModal.Message = "visitor report details get successfully";
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
