using Microsoft.AspNetCore.Mvc;
using VMS.Models.Employee;
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
        [HttpGet("GetDepartment")]
        public ResponseModal GetDepartment()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.GetDepartment();
                responseModal.Message = "department details get successfully";
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
        [HttpGet("GetDepartmentById")]
        public ResponseModal GetDepartmentById(int DepartmentId)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.GetDepartmentbyId(DepartmentId);
                responseModal.Message = "department details get successfully";
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
        [HttpPost("SaveDepartment")]
        public ResponseModal SaveDepartment([FromBody] DepartmentTb departmentTb)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.SaveDepartment(departmentTb);
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

        [HttpPut("EditDepartment")]
        public ResponseModal EditDepartment([FromBody] DepartmentTb departmentTb)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.EditDepartment(departmentTb);
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
        [HttpGet("GetEmployyee")]
        public ResponseModal GetEmployee()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.GetEmployee();
                responseModal.Message = "employee details get successfully";
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
        [HttpGet("GetEmployeeById")]
        public ResponseModal GetEmployeeById(int EmployeeId)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.GetDepartmentbyId(EmployeeId);
                responseModal.Message = "employee details get successfully";
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
        [HttpPost("SaveEmployee")]
        public ResponseModal SaveEmployee([FromBody] AddEmployeeModel emp)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.SaveEmployee(emp);
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

        [HttpPut("EditEmployee")]
        public ResponseModal EditEmployee([FromBody] AddEmployeeModel emp)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.EditEmployee(emp);
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
        [HttpGet("GetUserType")]
        public ResponseModal GetUserType()
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.GetUserType();
                responseModal.Message = "user type get successfully";
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

        [HttpPost("UploadEmployee")]
        public ResponseModal UploadEmployee([FromBody] string emp , string dev)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.UploadEmployee(emp , dev);
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
        [HttpPost("DeleteEmployee")]
        public ResponseModal DeleteEmployee([FromBody] string emp, string dev)
        {
            ResponseModal responseModal = new ResponseModal();
            try
            {
                responseModal.Data = _master.DeleteEmployee(emp, dev);
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
