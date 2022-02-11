using Microsoft.AspNetCore.Mvc;
using VMS.Models.Visitor;
using VMS_API.Interfaces;
using VMS_API.Models.ViewModels;

namespace VMS_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourierController : Controller
    {
        private readonly ICourier _courier;
        public CourierController(ICourier courier)
        {
            _courier = courier;
        }
        [HttpGet("GetCourier")]
        public ResponseModal GetCourier()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _courier.GetCourier();
                responseModal.Message = "company details get successfully";
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

        [HttpGet("GetCourierById")]
        public ResponseModal GetCourierById(int id)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _courier.GetCourierById(id);
                responseModal.Message = "Courier details get successfully";
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
        
        [HttpPost("SaveCourier")]
        public ResponseModal SaveVisitor( CourierModel courier)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _courier.SaveCourier(courier);
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
        [HttpPut("EditCourier")]
        public ResponseModal EditCourier(CourierModel courier)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _courier.EditCourier(courier);
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
