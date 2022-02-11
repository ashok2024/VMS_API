using VMS.Models.Account;
using VMS.Models.Admin;
using VMS.Models.Employee;
using VMS_API.Models;

namespace VMS_API.Interfaces
{
    public interface IMaster
    {
        Task<List<CompanyTb>> GetCompany();
        Task<CompanyTb> GetCompanybyId(int ComapnyId);
        Task<string> SaveCompany(CompanyTb companyTb);
        Task<string> EditCompany(CompanyTb companyTb);
        Task<List<BranchTb>> GetBranch();
        Task<BranchTb> GetBranchById(int BranchId);
        Task<string> SaveBranch(BranchTb branchTb);
        Task<string> EditBranch(BranchTb branchTb);
        Task<List<DepartmentModel>> GetDepartment();
        Task<DepartmentModel> GetDepartmentbyId(int DepartmentId);
        Task<string> SaveDepartment(DepartmentTb departmentModel);
        Task<string> EditDepartment(DepartmentTb departmentModel);
        Task<List<EmployeeModel>> GetEmployee();      
        Task<List<UserTypeModel>> GetUserType();
        Task<string> SaveEmployee(AddEmployeeModel tB);
        Task<string> EditEmployee(AddEmployeeModel tB);
        Task<AddEmployeeModel> GetEmployeById(int id);
        Task<string> UploadEmployee (string empid , string deviceid);
        Task<string> DeleteEmployee(string empid, string deviceid);
    }
}
