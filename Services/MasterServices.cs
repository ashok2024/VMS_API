using Microsoft.EntityFrameworkCore;
using VMS_API.Interfaces;
using VMS_API.Models;

namespace VMS_API.Services
{
    public class MasterServices : IMaster
    {
        private VMSDBContext _vMSDBContext;
        public MasterServices(VMSDBContext vMSDBContext)
        { 
           _vMSDBContext = vMSDBContext;    
        }
        public async Task<List<CompanyTb>> GetCompany()
        {
            try
            {
                return _vMSDBContext.CompanyTbs.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> SaveCompany(CompanyTb companyTb)
        {
            _vMSDBContext.CompanyTbs.Add(companyTb);
            _vMSDBContext.SaveChanges();
            return "Company Save";
        }
        public async Task<string> EditCompany(CompanyTb companyTb)
        {
            var res =  _vMSDBContext.CompanyTbs.Where(x => x.Id == companyTb.Id).AsNoTracking().FirstOrDefault();
            if (res != null)
            { 
                res.Name = companyTb.Name;  
                res.ContactPerson = companyTb.ContactPerson;
                res.Phone = companyTb.Phone;
                res.Address = companyTb.Address;
                _vMSDBContext.CompanyTbs.Update(res);
                _vMSDBContext.SaveChanges();
                return "Company Update Success";
            }
            else
            {
                return "Invalid Company Id";
            }
            
        }

        public async Task<CompanyTb> GetCompanybyId(int ComapnyId)
        {
            return  _vMSDBContext.CompanyTbs.Where(x => x.Id == ComapnyId).FirstOrDefault();
        }

        public async Task<List<BranchTb>> GetBranch()
        {
            return _vMSDBContext.BranchTbs.ToList();
        }

        public async Task<BranchTb> GetBranchById(int BranchId)
        {
            return _vMSDBContext.BranchTbs.Where(x => x.Id == BranchId).FirstOrDefault();
        }

        public async Task<string> SaveBranch(BranchTb branchTb)
        {
            _vMSDBContext.BranchTbs.Add(branchTb);
            _vMSDBContext.SaveChanges();
            return "Branch save success";
        }

        public async Task<string> EditBranch(BranchTb branchTb)
        {
            var res = _vMSDBContext.BranchTbs.Where(x => x.Id == branchTb.Id).AsNoTracking().FirstOrDefault();
            if (res != null)
            {
                res.Name = branchTb.Name;
                res.ContactPerson = branchTb.ContactPerson;
                res.Phone = branchTb.Phone;
                res.Address = branchTb.Address;
                _vMSDBContext.BranchTbs.Update(res);
                _vMSDBContext.SaveChanges();
                return "Branch Update Success";
            }
            else
            {
                return "Invalid Branch Id";
            }
        }
    }
}
