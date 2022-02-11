using Microsoft.EntityFrameworkCore;
using VMS.Models.Visitor;
using VMS_API.Interfaces;
using VMS_API.Models;

namespace VMS_API.Services
{
    public class VisitorService : IVisitor
    {
        private readonly VMSDBContext _context;
        public VisitorService(VMSDBContext context)
        {
            _context = context;
        }
        public async Task<List<VisitorEntryModel>> GetVisitor()
        {
            List<VisitorEntryModel> Model = new List<VisitorEntryModel>();


            try
            {
                var visitors = _context.VisitorEntryTbs.ToList().OrderByDescending(d => d.Id);

                foreach (var item in visitors)
                {
                    VisitorEntryModel visitor = new VisitorEntryModel();
                    visitor.Id = item.Id;
                    visitor.VisitorId = item.VisitorId;
                    visitor.Name = item.Name;
                    visitor.Company = item.Company;
                    visitor.Contact = item.Contact;
                    var user = _context.UserTbs.Where(d => d.UserId == item.EmployeeId).FirstOrDefault();
                    visitor.EmployeeId = Convert.ToInt32(item.EmployeeId);
                    visitor.EmployeeName = user.FirstName + " " + user.LastName;
                    visitor.EmployeeDepartment = user.Department;
                    visitor.InTime = item.InTime;
                    visitor.OutTime = item.OutTime;
                    visitor.VisitDateFrom = Convert.ToDateTime(item.FromDate);
                    visitor.VisitDateTo = Convert.ToDateTime(item.ToDate);
                    visitor.Purpose = item.Purpose;
                    var visitorStatus = _context.VisitorStatusTbs.Where(d => d.VisitId == visitor.Id).FirstOrDefault();
                    if (visitorStatus != null)
                        visitor.Status = visitorStatus.Status;
                    else
                        visitor.Status = "";
                    Model.Add(visitor);
                }
            }
            catch (Exception ex)
            {
                return Model;
            }
            return Model;
        }

        public async Task<VisitorEntryModel> GetVisitorByContactNo(string contactNo)
        {
            VisitorEntryModel Model = new VisitorEntryModel();


            try
            {

                    VisitorEntryTb visitor = new VisitorEntryTb();
                    visitor = _context.VisitorEntryTbs.Where(d => d.Contact == contactNo).OrderByDescending(x => x.Id).FirstOrDefault();
                    Model.Id = visitor.Id;
                    Model.VisitorId = visitor.VisitorId;
                    Model.Name = visitor.Name;
                    Model.Company = visitor.Company;
                    Model.Contact = visitor.Contact;
                    Model.EmailId = visitor.EmailId;
                    Model.Address = visitor.Address;
                    Model.VisitorType = visitor.VisitorType;
                    var user = _context.UserTbs.Where(d => d.UserId == visitor.EmployeeId).FirstOrDefault();
                    Model.EmployeeId = Convert.ToInt32(visitor.EmployeeId);
                    Model.EmployeeName = user.FirstName + " " + user.LastName;
                    Model.EmployeeDepartment = user.Department;
                    Model.Department = user.Department;
                    Model.Designation = user.Designation;
                    Model.InTime = visitor.InTime;
                    Model.OutTime = visitor.OutTime;
                    Model.VisitDateFrom = visitor.FromDate;
                    Model.VisitDateTo = visitor.ToDate;
                    Model.Purpose = visitor.Purpose;
                    Model.Remark = visitor.Remark;
                    Model.Priority = visitor.Priority;
                    Model.IdProof = visitor.IdProof;
                    Model.IdProofNo = visitor.IdProofNumber;
                    Model.Material = visitor.Material;
                    Model.VehicleType = visitor.VehicleType;
                    Model.VehicleNo = visitor.VehicleNo;
                    Model.VehiclePUCNo = visitor.VehicleNo;
                    Model.PUCEndDate = visitor.PucendDate;
                    Model.PhotoPath = visitor.Photo;
                    Model.PhotoPathCapture = visitor.Photo;
                    Model.captureCertificate = visitor.CertificateImagePath;
                    Model.DeviceId = Convert.ToInt32(visitor.DeviceId);
                    Model.CardNo = visitor.CardNo;
            }
            catch (Exception ex)
            {
                return Model;
            }
            return Model;
        }

        public async Task<VisitorEntryModel> GetVisitorById(int id)
        {
            VisitorEntryModel Model = new VisitorEntryModel();

            try
            {
                var visitor = _context.VisitorEntryTbs.Where(d => d.Id == id).FirstOrDefault();

                Model.Id = visitor.Id;
                Model.VisitorId = visitor.VisitorId;
                Model.Name = visitor.Name;
                Model.Company = visitor.Company;
                Model.Contact = visitor.Contact;
                Model.EmailId = visitor.EmailId;
                Model.Address = visitor.Address;
                Model.VisitorType = visitor.VisitorType;
                var user = _context.UserTbs.Where(d => d.UserId == visitor.EmployeeId).FirstOrDefault();
                Model.EmployeeId = Convert.ToInt32(visitor.EmployeeId);
                Model.EmployeeName = user.FirstName + " " + user.LastName;
                Model.EmployeeDepartment = user.Department;
                Model.Department = user.Department;
                Model.Designation = user.Designation;
                Model.InTime = visitor.InTime;
                Model.OutTime = visitor.OutTime;
                Model.VisitDateFrom = visitor.FromDate;
                Model.VisitDateTo = visitor.ToDate;
                Model.Purpose = visitor.Purpose;
                Model.Remark = visitor.Remark;
                Model.Priority = visitor.Priority;
                Model.IdProof = visitor.IdProof;
                Model.IdProofNo = visitor.IdProofNumber;
                Model.Material = visitor.Material;
                Model.VehicleType = visitor.VehicleType;
                Model.VehicleNo = visitor.VehicleNo;
                Model.VehiclePUCNo = visitor.VehicleNo;
                Model.PUCEndDate = visitor.PucendDate;
                Model.PhotoPath = visitor.Photo;
                Model.PhotoPathCapture = visitor.Photo;
                Model.captureCertificate = visitor.CertificateImagePath;
                Model.DeviceId = Convert.ToInt32(visitor.DeviceId);
                Model.CardNo = visitor.CardNo;

            }
            catch (Exception ex)
            {
                return Model;              
            }
            return Model;
        }
        public async Task<string> SaveVisitor(VisitorEntryModel visitor)
        {
            string addId = "";
            var visitordata = _context.VisitorEntryTbs.Where(d => d.Contact == visitor.Contact).FirstOrDefault();

            if (visitordata != null)
            {
                VisitorEntryTb tB = new VisitorEntryTb();
                tB.EmployeeId = visitor.EmployeeId;
                tB.VisitorId = visitordata.VisitorId;
                addId = visitordata.VisitorId;
                tB.Name = visitor.Name;
                tB.Company = visitor.Company;
                tB.VisitorType = visitor.VisitorType;
                tB.Address = visitor.Address;
                tB.InTime = visitor.InTime;
                tB.OutTime = visitor.OutTime;
                tB.FromDate = visitor.VisitDateFrom;
                tB.ToDate = visitor.VisitDateTo;
                tB.IdProof = visitor.IdProof;
                tB.IdProofNumber = visitor.IdProofNo;
                tB.Photo = string.IsNullOrEmpty(visitor.PhotoPathCapture) ? visitor.PhotoPath : visitor.PhotoPathCapture;
                tB.CertificateImagePath = string.IsNullOrEmpty(visitor.certificatePath) ? visitor.captureCertificate : visitor.certificatePath;
                tB.EmailId = visitor.EmailId;
                tB.Contact = visitor.Contact;
                tB.Purpose = visitor.Purpose;
                tB.Remark = visitor.Remark;
                tB.Priority = visitor.Priority;
                tB.Material = visitor.Material;
                tB.VehicleType = visitor.VehicleType;
                tB.VehicleNo = visitor.VehicleNo;
                tB.VehiclePucno = visitor.VehiclePUCNo;
                tB.PucendDate = visitor.PUCEndDate != null ? visitor.PUCEndDate : null;
                tB.UserId = visitor.userId;
                tB.DeviceId = visitor.DeviceId;
                tB.CardNo = visitor.CardNo;
                _context.VisitorEntryTbs.Add(tB);
                _context.SaveChanges();
            }
            else
            {
                VisitorTb dt = new VisitorTb();
                Random generator = new Random();
                string rand = generator.Next(0, 1000000).ToString("D6");
                dt.VisitorId = rand;
                addId = rand;
                dt.Name = visitor.Name;
                dt.Contact = visitor.Contact;
                dt.EmailId = visitor.EmailId;
                dt.Company = visitor.Company;
                dt.Photo = string.IsNullOrEmpty(visitor.PhotoPathCapture) ? visitor.PhotoPath : visitor.PhotoPathCapture;
                _context.VisitorTbs.Add(dt);
                _context.SaveChanges();

                VisitorEntryTb tB = new VisitorEntryTb();
                tB.EmployeeId = visitor.EmployeeId;
                tB.VisitorId = dt.VisitorId;
                tB.Name = visitor.Name;
                tB.Company = visitor.Company;
                tB.VisitorType = visitor.VisitorType;
                tB.Address = visitor.Address;
                tB.InTime = visitor.InTime;
                tB.OutTime = visitor.OutTime;
                tB.FromDate = visitor.VisitDateFrom;
                tB.ToDate = visitor.VisitDateTo;
                tB.IdProof = visitor.IdProof;
                tB.IdProofNumber = visitor.IdProofNo;
                tB.Photo = string.IsNullOrEmpty(visitor.PhotoPathCapture) ? visitor.PhotoPath : visitor.PhotoPathCapture;
                tB.CertificateImagePath = string.IsNullOrEmpty(visitor.captureCertificate) ? visitor.certificatePath : visitor.captureCertificate;
                tB.EmailId = visitor.EmailId;
                tB.Contact = visitor.Contact;
                tB.Purpose = visitor.Purpose;
                tB.Remark = visitor.Remark;
                tB.Priority = visitor.Priority;
                tB.Material = visitor.Material;
                tB.UserId = visitor.userId;
                tB.VehicleType = visitor.VehicleType;
                tB.VehicleNo = visitor.VehicleNo;
                tB.VehiclePucno = visitor.VehiclePUCNo;
                tB.PucendDate = visitor.PUCEndDate != null ? visitor.PUCEndDate : null;
                tB.DeviceId = visitor.DeviceId;
                tB.CardNo = visitor.CardNo;
                _context.VisitorEntryTbs.Add(tB);
                _context.SaveChanges();
            }
            return "visitor entry save";
        }
        public async Task<string> EditVisitor(VisitorEntryModel visitor)
        {
            string addId = "";
           

                var checkVisitor = _context.VisitorEntryTbs.Where(d => d.Id == visitor.Id).FirstOrDefault();

                checkVisitor.EmployeeId = visitor.EmployeeId;
                addId = checkVisitor.VisitorId;
                checkVisitor.Name = visitor.Name;
                checkVisitor.Company = visitor.Company;
                checkVisitor.VisitorType = visitor.VisitorType;
                checkVisitor.Address = visitor.Address;
                checkVisitor.InTime = visitor.InTime;
                checkVisitor.OutTime = visitor.OutTime;
                checkVisitor.FromDate = visitor.VisitDateFrom;
                checkVisitor.ToDate = visitor.VisitDateTo;
                checkVisitor.IdProof = visitor.IdProof;
                checkVisitor.IdProofNumber = visitor.IdProofNo;
                checkVisitor.Photo = string.IsNullOrEmpty(visitor.PhotoPathCapture) ? visitor.PhotoPath : visitor.PhotoPathCapture;
                checkVisitor.CertificateImagePath = string.IsNullOrEmpty(visitor.certificatePath) ? visitor.captureCertificate : visitor.certificatePath;
                checkVisitor.EmailId = visitor.EmailId;
                checkVisitor.Contact = visitor.Contact;
                checkVisitor.Purpose = visitor.Purpose;
                checkVisitor.Remark = visitor.Remark;
                checkVisitor.Priority = visitor.Priority;
                checkVisitor.Material = visitor.Material;
                checkVisitor.UserId = visitor.userId;
                checkVisitor.VehicleType = visitor.VehicleType;
                checkVisitor.VehicleNo = visitor.VehicleNo;
                checkVisitor.VehiclePucno = visitor.VehiclePUCNo;
                checkVisitor.PucendDate = visitor.PUCEndDate != null ? visitor.PUCEndDate : null;
                checkVisitor.DeviceId = visitor.DeviceId;
                checkVisitor.CardNo = visitor.CardNo;
                _context.Entry(checkVisitor).State = EntityState.Modified;
                _context.SaveChanges();
           
            return "visitor entry update success";
        }

        public async Task<List<CourierModel>> GetCourier()
        {
            List<CourierModel> Model = new List<CourierModel>();

            try
            {
                var data = _context.CourierTbs.ToList().OrderByDescending(d => d.Id);

                foreach (var item in data)
                {
                    CourierModel courier = new CourierModel();
                    courier.Id = item.Id;
                    courier.CourierNo = item.CourierNo;
                    courier.CourierCompany = item.CourierCompany;
                    courier.CourierPersonName = item.CourierPersonName;
                    courier.EmployeeName = item.EmployeeName;
                    courier.EmployeeId = item.EmployeeId;
                    courier.Time = item.Time;
                    courier.Date = Convert.ToDateTime(item.Date);
                    Model.Add(courier);
                }
            }
            catch (Exception ex)
            {
                return Model;
            }
            return Model;
        }
    }
}
