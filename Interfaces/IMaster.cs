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
    }
}
