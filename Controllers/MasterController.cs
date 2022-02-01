using Microsoft.AspNetCore.Mvc;
using VMS_API.Interfaces;
using VMS_API.Models;
using VMS_API.Models.ViewModels;

namespace VMS_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MasterController : ControllerBase
    {
        private readonly IMaster _master;
        public MasterController(IMaster master)
        {
            _master = master;
        }

        [HttpGet(Name = "GetCompany")]
        public ResponseModal GetCompany()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.GetCompany();
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

        [HttpPost(Name = "SaveCompany")]
        public ResponseModal SaveComapny([FromBody] CompanyTb companyTb)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.SaveCompany(companyTb);
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

        [HttpPut(Name = "EditCompany")]
        public ResponseModal EditCompany([FromBody] CompanyTb companyTb)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.EditCompany(companyTb);
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

        [HttpGet("GetCompnayById")]
        public ResponseModal GetCompanyById(int ComapnyId)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.GetCompanybyId(ComapnyId);
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

        [HttpGet("GetBranch")]
        public ResponseModal GetBranch()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.GetBranch();
                responseModal.Message = "branch details get successfully";
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

        [HttpPost("SaveBranch")]
        public ResponseModal SaveBranch([FromBody] BranchTb branchTb)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.SaveBranch(branchTb);
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

        [HttpPut("EditBranch")]
        public ResponseModal EditBranch([FromBody] BranchTb branchTb)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.EditBranch(branchTb);
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

        [HttpGet("GetBranchById")]
        public ResponseModal GetBranchById(int BranchId)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.GetBranchById(BranchId);
                responseModal.Message = "branch details get successfully";
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
