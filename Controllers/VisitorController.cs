using Microsoft.AspNetCore.Mvc;
using VMS.Models.Visitor;
using VMS_API.Interfaces;
using VMS_API.Models.ViewModels;

namespace VMS_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitorController : Controller
    {
        
        private readonly IVisitor _visitor;
        public VisitorController(IVisitor visitor)
        {
            _visitor  = visitor;
        }

        [HttpGet("GetVisitor")]
        public ResponseModal GetVisitor()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _visitor.GetVisitor();
                responseModal.Message = "visitor details get successfully";
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

        [HttpGet("GetVisitorById")]
        public ResponseModal GetVisitorById(int id)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _visitor.GetVisitorById(id);
                responseModal.Message = "visitor details get successfully";
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

        [HttpGet("GetVisitorByContactNo")]
        public ResponseModal GetVisitorByContactNo(string contactNo)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _visitor.GetVisitorByContactNo(contactNo);
                responseModal.Message = "visitor details get successfully";
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
        [HttpPost("SaveVisitor")]
        public ResponseModal SaveVisitor([FromBody]  VisitorEntryModel visitorEntryModel)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _visitor.SaveVisitor(visitorEntryModel);
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
        [HttpPut("EditVisitor")]
        public ResponseModal EditVisitor([FromBody]  VisitorEntryModel visitorEntryModel)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _visitor.EditVisitor(visitorEntryModel);
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

        [HttpGet("GetCourier")]
        public ResponseModal GetCourier()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _visitor.GetCourier();
                responseModal.Message = "visitor details get successfully";
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
