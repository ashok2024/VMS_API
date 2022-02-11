using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net.Http.Json;
using VMS.Models;
using VMS.Models.Account;
using VMS.Models.Admin;
using VMS.Models.Employee;
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

        public async Task<List<DepartmentModel>> GetDepartment()
        {
            List<DepartmentModel> Model = new List<DepartmentModel>();           

            try
            {
                var emp = _vMSDBContext.DepartmentTbs.ToList().OrderBy(d => d.Name);

                foreach (var item in emp)
                {
                    var company = _vMSDBContext.CompanyTbs.Where(d => d.Id == item.CompanyId).FirstOrDefault();
                    var branch = _vMSDBContext.BranchTbs.Where(d => d.Id == item.BranchId).FirstOrDefault();

                    DepartmentModel employee = new DepartmentModel();
                    employee.Id = item.Id;
                    employee.Name = item.Name;
                    employee.CompanyId = company != null ? company.Id : 0;
                    employee.CompanyName = company != null ? company.Name : "";
                    employee.BranchId = branch != null ? branch.Id : 0;
                    employee.BranchName = branch != null ? branch.Name : "";
                    Model.Add(employee);
                }
            }
            catch (Exception ex)
            {
                return Model;
                
            }
            return Model;
        }

        public async Task<DepartmentModel> GetDepartmentbyId(int DepartmentId)
        {
            DepartmentModel Model = new DepartmentModel();

            
                var emp = _vMSDBContext.DepartmentTbs.Where(x => x.Id == DepartmentId).FirstOrDefault();

                
                    var company = _vMSDBContext.CompanyTbs.Where(d => d.Id == emp.CompanyId).FirstOrDefault();
                    var branch = _vMSDBContext.BranchTbs.Where(d => d.Id == emp.BranchId).FirstOrDefault();
                    DepartmentModel employee = new DepartmentModel();
                    employee.Id = emp.Id;
                    employee.Name = emp.Name;
                    employee.CompanyId = company != null ? company.Id : 0;
                    employee.CompanyName = company != null ? company.Name : "";
                    employee.BranchId = branch != null ? branch.Id : 0;
                    employee.BranchName = branch != null ? branch.Name : "";
                    //Model.Add(employee);
                    return employee;               
            
        }

        public async Task<string> SaveDepartment(DepartmentTb departmentModel)
        {
             _vMSDBContext.DepartmentTbs.Add(departmentModel);
            return "department save success";
        }

        public async Task<string> EditDepartment(DepartmentTb departmentModel)
        {
            var res = _vMSDBContext.DepartmentTbs.Where(x => x.Id == departmentModel.Id).FirstOrDefault();
            if (res != null)
            {
                res.CompanyId = departmentModel.CompanyId;
                res.BranchId = departmentModel.BranchId;
                _vMSDBContext.Add(res);
                _vMSDBContext.SaveChanges();
                return "department edit suucess";
            }
            else
            {
                return "invalid department id";
            }
        }

        public async Task<List<EmployeeModel>> GetEmployee()
        {
            List<EmployeeModel> Model = new List<EmployeeModel>();


                 var emp = _vMSDBContext.UserTbs.Where(d => d.UserType != "Admin").ToList().OrderByDescending(d => d.UserId);

            foreach (var item in emp)
            {
                EmployeeModel employee = new EmployeeModel();
                employee.UserId = item.UserId;
                employee.EmpCode = item.EmpCode;
                employee.Name = item.FirstName + " " + item.LastName;
                employee.FirstName = item.FirstName;
                employee.LastName = item.LastName;
                employee.CompanyId = item.CompanyId;
                employee.Company = _vMSDBContext.CompanyTbs.Where(d => d.Id == item.CompanyId).Select(x => x.Name).FirstOrDefault();
                employee.BranchId = item.BranchId;
                employee.Branch = _vMSDBContext.BranchTbs.Where(d => d.Id == item.BranchId).Select(x => x.Name).FirstOrDefault();
                employee.DepartmentId = item.DepartmentId;
                employee.Department = _vMSDBContext.DepartmentTbs.Where(d => d.Id == item.DepartmentId).Select(x => x.Name).FirstOrDefault();
                employee.DesignationId = item.DesignationId;
                employee.Designation = _vMSDBContext.DesignationTbs.Where(d => d.Id == item.DesignationId).Select(x => x.Name).FirstOrDefault();
                employee.Phone = item.Phone;
                employee.Email = item.Email;
                employee.BirthDate = Convert.ToDateTime(item.BirthDate);
                employee.Password = item.Password;
                employee.Address = item.Address;
                employee.UserType = item.UserType;
                employee.IdProofNo = item.IdProofNumber;
                employee.PhotoPath = item.Photo;
                employee.DeviceId = Convert.ToInt32(item.DeviceId);
                employee.CardNo = item.CardNo;
                Model.Add(employee);
            }
           
            return Model;
        }

        public async Task<AddEmployeeModel> GetEmployeById(int EmployeId)
        {
            AddEmployeeModel Model = new AddEmployeeModel();
            if (EmployeId > 0)
            {
                try
                {
                    var emp = _vMSDBContext.UserTbs.Where(d => d.UserId == EmployeId).FirstOrDefault();

                    Model.EmpCode = emp?.EmpCode;
                    Model.UserId = emp.UserId;
                    Model.Name = emp.Name;
                    Model.EmailId = emp.Email;
                    Model.Contact = emp.Phone;
                    Model.BirthDate = Convert.ToDateTime(emp.BirthDate);
                    Model.Address = emp.Address;
                    Model.CompanyId = emp.CompanyId;
                    Model.Company = _vMSDBContext.CompanyTbs.Where(d => d.Id == emp.CompanyId).Select(x => x.Name).FirstOrDefault();
                    Model.BranchId = emp.BranchId;
                    Model.Branch = _vMSDBContext.BranchTbs.Where(d => d.Id == emp.BranchId).Select(x => x.Name).FirstOrDefault();
                    Model.DepartmentId = emp.DepartmentId;
                    Model.Department = _vMSDBContext.DepartmentTbs.Where(d => d.Id == emp.DepartmentId).Select(x => x.Name).FirstOrDefault();
                    Model.DesignationId = emp.DesignationId;
                    Model.Designation = _vMSDBContext.DesignationTbs.Where(d => d.Id == emp.DesignationId).Select(x => x.Name).FirstOrDefault();
                    Model.UserName = emp.UserName;
                    Model.Password = emp.Password;
                    Model.UserType = emp.UserType;
                    Model.IdProofNo = emp.IdProofNumber;
                    Model.PhotoPath = emp.Photo;
                    Model.IdProofNo = emp.IdProofNumber;
                    Model.DeviceId = Convert.ToInt32(emp.DeviceId);
                    Model.CardNo = emp.CardNo;
                }
                catch (Exception ex)
                {
                    return Model;
                    throw ex;
                }
            }
            return Model;
        }
        public async Task<List<UserTypeModel>> GetUserType()
        {
            List<UserTypeModel> usertypeList = new List<UserTypeModel>();
            UserTypeModel userType = new UserTypeModel();
            userType.Id = 1;
            userType.Name = "Employee";
            usertypeList.Add(userType);

            userType = new UserTypeModel();
            userType.Id = 2;
            userType.Name = "Reception";
            usertypeList.Add(userType);
            return usertypeList;
        }

        public async Task<string> SaveEmployee(AddEmployeeModel emp) 
        {
            UserTb tB = new UserTb();
            tB.EmpCode = emp.EmpCode;
            tB.Name = emp.Name;
            tB.FirstName = Convert.ToString(emp.Name.Split(' ')[0]);
            tB.Email = emp.EmailId;
            tB.Phone = emp.Contact;
            tB.BirthDate = emp.BirthDate;
            tB.Address = emp.Address;
            tB.CompanyId = emp.CompanyId;
            tB.BranchId = emp.BranchId;
            tB.DepartmentId = emp.DepartmentId;
            tB.DesignationId = emp.DesignationId;
            tB.UserName = emp.UserName;
            tB.Password = emp.Password;
            tB.UserType = emp.UserType;
            tB.DeviceId = emp.DeviceId;
            tB.CardNo = emp.CardNo;
            tB.IdProofNumber = emp.IdProofNo;
            tB.Photo = emp.PhotoPath;
            _vMSDBContext.UserTbs.Add(tB);
            _vMSDBContext.SaveChanges();
            var result = emp.UserType == "Employee" ? "Employee save success" : "Reception save success";
            return result;
        }
        public async Task<string> EditEmployee(AddEmployeeModel emp)
        {
            var userdt = _vMSDBContext.UserTbs.Where(d => d.UserId == emp.UserId).FirstOrDefault();

            userdt.EmpCode = emp.EmpCode;
            userdt.Name = emp.Name;
            userdt.FirstName = Convert.ToString(emp.Name.Split(' ')[0]);
            userdt.Email = emp.EmailId;
            userdt.Phone = emp.Contact;
            userdt.BirthDate = emp.BirthDate;
            userdt.Address = emp.Address;
            userdt.CompanyId = emp.CompanyId;
            userdt.BranchId = emp.BranchId;
            userdt.DepartmentId = emp.DepartmentId;
            userdt.DesignationId = emp.DesignationId;
            userdt.UserType = emp.UserType;
            userdt.DeviceId = emp.DeviceId;
            userdt.CardNo = emp.CardNo;
            userdt.IdProofNumber = emp.IdProofNo;
            userdt.Photo = emp.PhotoPath;
            _vMSDBContext.Entry(userdt).State = EntityState.Modified;
            _vMSDBContext.SaveChanges();
            var result = emp.UserType == "Employee" ? "Employee edit success" : "Reception edit success";
            return result;
        }
        public async Task<string> UploadEmployee(string empid, string deviceid)
        {
            try
            {
                bool res = true;
                string[] devices = deviceid.Split(',');

                string[] empdt = empid.Split(',');
                string strEmployrrList = string.Empty;
                List<string> listEmployeeNo = new List<string>();
                foreach (var item in empdt)
                {
                    if (item != "")
                    {
                        listEmployeeNo.Add(item.ToString());
                    }
                }
                foreach (string d in devices)
                {
                    if (d != "")
                    {
                        var dv = _vMSDBContext.DevicesTbs.Where(x => x.DeviceAccountId == d).FirstOrDefault();

                        string url = "http://" + dv.DeviceIpaddress + ":" + dv.Port + "/ISAPI/ContentMgmt/DeviceMgmt/deviceList?format=json";

                        string req = "{\"SearchDescription\" : {\"position\":0,\"maxResult\":5}}";

                        //req = string.Empty;
                        string reps = string.Empty;
                        string strMatchNum = string.Empty;
                        clienthttp clnt = new clienthttp();
                        int iet = clnt.HttpRequest(dv.UserName, dv.Password, url, "POST", req, ref reps);
                        if (iet == (int)HttpStatus.Http200)
                        {
                            DeviceSearchRoot dr = JsonConvert.DeserializeObject<DeviceSearchRoot>(reps);
                            strMatchNum = Convert.ToString(dr.SearchResult.numOfMatches);

                            if ("0" != strMatchNum)
                            {
                                foreach (var devv in dr.SearchResult.MatchList)
                                {
                                    if (devv.Device.EhomeParams.EhomeID == dv.DeviceAccountId)
                                    {
                                        var devicedt = devv.Device;

                                        ApiMonitorTb at = new ApiMonitorTb();
                                        at.Command = "Check Device Exist";
                                        at.Page = "Upload Employee";
                                        at.Time = DateTime.Now;
                                        at.DeviceSrno = dv.DeviceSerialNo;
                                        at.DeviceName = dv.DeviceName;
                                        at.EmpCode = "";
                                        at.EmpName = "";
                                        at.Status = "Success";
                                        _vMSDBContext.ApiMonitorTbs.Add(at);
                                        _vMSDBContext.SaveChanges();

                                        for (int i = 0; i < listEmployeeNo.Count; i++)
                                        {
                                            strEmployrrList += ",";

                                            string filePath = System.IO.Path.Combine(("/Uploads/"), "M+ANIL_1002788.jpg");
                                            string strEmployeeID = listEmployeeNo[i];
                                            string strReq = "{ \"FaceInfo\": {\"employeeNo\": \"" + strEmployeeID + "\",\"faceLibType\": \"blackFD\" }}";
                                            string strUrl = "http://" + dv.DeviceIpaddress + ":" + dv.Port + "/ISAPI/Intelligent/FDLib/FaceDataRecord?format=json&devIndex=" + devicedt.devIndex;
                                            string strRsp = string.Empty;

                                            string fileKeyName = "FaceImage";
                                            NameValueCollection stringDict = new NameValueCollection();
                                            stringDict.Add("FaceDataRecord", strReq);

                                            clnt = new clienthttp();
                                            int iRet = clnt.HttpPostData(dv.UserName, dv.Password, strUrl, fileKeyName, filePath, stringDict, ref strRsp);
                                            if (iRet != (int)HttpStatus.Http200)
                                            {
                                                at = new ApiMonitorTb();
                                                at.Command = "Face Upload";
                                                at.Page = "Upload Employee";
                                                at.Time = DateTime.Now;
                                                at.DeviceSrno = dv.DeviceSerialNo;
                                                at.DeviceName = dv.DeviceName;
                                                var emp = _vMSDBContext.UserTbs.Where(c => c.EmpCode == at.EmpCode).FirstOrDefault();
                                                at.EmpName = emp.Name;
                                                at.Status = "Success";
                                                _vMSDBContext.ApiMonitorTbs.Add(at);
                                                _vMSDBContext.SaveChanges();
                                            }
                                            else
                                            {
                                                at = new ApiMonitorTb();
                                                at.Command = "Face Upload";
                                                at.Page = "Upload Employee";
                                                at.Time = DateTime.Now;
                                                at.DeviceSrno = dv.DeviceSerialNo;
                                                at.DeviceName = dv.DeviceName;
                                                at.EmpCode = strEmployeeID;
                                                var emp = _vMSDBContext.UserTbs.Where(c => c.EmpCode == at.EmpCode).FirstOrDefault();
                                                at.EmpName = emp.Name;
                                                at.Status = "Failed";
                                                _vMSDBContext.ApiMonitorTbs.Add(at);
                                                _vMSDBContext.SaveChanges();
                                            }
                                        }                                       
                                    }
                                }
                            }
                        }
                    }
                }               
            }
            catch (Exception ex)
            {

            }
            return "Employee upload success";
        }

        public async Task<string> DeleteEmployee(string empid, string deviceid)
        {
            try
            {
                bool res = true;
                string[] devices = deviceid.Split(',');

                string[] empdt = empid.Split(',');
                string strEmployrrList = string.Empty;
                List<string> listEmployeeNo = new List<string>();
                foreach (var item in empdt)
                {
                    if (item != "")
                    {
                        listEmployeeNo.Add(item.ToString());
                    }
                }
                foreach (string d in devices)
                {
                    if (d != "")
                    {
                        var dv = _vMSDBContext.DevicesTbs.Where(x => x.DeviceAccountId == d).FirstOrDefault();

                        string url = "http://" + dv.DeviceIpaddress + ":" + dv.Port + "/ISAPI/ContentMgmt/DeviceMgmt/deviceList?format=json";

                        string req = "{\"SearchDescription\" : {\"position\":0,\"maxResult\":5}}";

                        //req = string.Empty;
                        string reps = string.Empty;
                        string strMatchNum = string.Empty;
                        clienthttp clnt = new clienthttp();
                        int iet = clnt.HttpRequest(dv.UserName, dv.Password, url, "POST", req, ref reps);
                        if (iet == (int)HttpStatus.Http200)
                        {
                            DeviceSearchRoot dr = JsonConvert.DeserializeObject<DeviceSearchRoot>(reps);
                            strMatchNum = Convert.ToString(dr.SearchResult.numOfMatches);

                            if ("0" != strMatchNum)
                            {
                                foreach (var devv in dr.SearchResult.MatchList)
                                {
                                    if (devv.Device.EhomeParams.EhomeID == dv.DeviceAccountId)
                                    {
                                        var devicedt = devv.Device;

                                        ApiMonitorTb at = new ApiMonitorTb();
                                        at.Command = "Check Device Exist";
                                        at.Page = "Delete Employee";
                                        at.Time = DateTime.Now;
                                        at.DeviceSrno = dv.DeviceSerialNo;
                                        at.DeviceName = dv.DeviceName;
                                        at.EmpCode = "";
                                        at.EmpName = "";
                                        at.Status = "Success";
                                        _vMSDBContext.ApiMonitorTbs.Add(at);
                                        _vMSDBContext.SaveChanges();

                                        for (int i = 0; i < listEmployeeNo.Count; i++)
                                        {
                                            strEmployrrList += ",";

                                            string filePath = System.IO.Path.Combine(("/Uploads/"), "M+ANIL_1002788.jpg");
                                            string strEmployeeID = listEmployeeNo[i];
                                            string strReq = "{ \"FaceInfo\": {\"employeeNo\": \"" + strEmployeeID + "\",\"faceLibType\": \"blackFD\" }}";
                                            string strUrl = "http://" + dv.DeviceIpaddress + ":" + dv.Port + "/ISAPI/Intelligent/FDLib/FaceDataRecord?format=json&devIndex=" + devicedt.devIndex;
                                            string strRsp = string.Empty;

                                            string fileKeyName = "FaceImage";
                                            NameValueCollection stringDict = new NameValueCollection();
                                            stringDict.Add("FaceDataRecord", strReq);

                                            clnt = new clienthttp();
                                            int iRet = clnt.HttpPostData(dv.UserName, dv.Password, strUrl, fileKeyName, filePath, stringDict, ref strRsp);
                                            if (iRet != (int)HttpStatus.Http200)
                                            {
                                                at = new ApiMonitorTb();
                                                at.Command = "Face Upload";
                                                at.Page = "Delete Employee";
                                                at.Time = DateTime.Now;
                                                at.DeviceSrno = dv.DeviceSerialNo;
                                                at.DeviceName = dv.DeviceName;
                                                var emp = _vMSDBContext.UserTbs.Where(c => c.EmpCode == at.EmpCode).FirstOrDefault();
                                                at.EmpName = emp.Name;
                                                at.Status = "Success";
                                                _vMSDBContext.ApiMonitorTbs.Add(at);
                                                _vMSDBContext.SaveChanges();
                                            }
                                            else
                                            {
                                                at = new ApiMonitorTb();
                                                at.Command = "Face Upload";
                                                at.Page = "Delete Employee";
                                                at.Time = DateTime.Now;
                                                at.DeviceSrno = dv.DeviceSerialNo;
                                                at.DeviceName = dv.DeviceName;
                                                at.EmpCode = strEmployeeID;
                                                var emp = _vMSDBContext.UserTbs.Where(c => c.EmpCode == at.EmpCode).FirstOrDefault();
                                                at.EmpName = emp.Name;
                                                at.Status = "Failed";
                                                _vMSDBContext.ApiMonitorTbs.Add(at);
                                                _vMSDBContext.SaveChanges();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return "Employee delete success";
        }
    }
}
