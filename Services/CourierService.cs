using Microsoft.EntityFrameworkCore;
using VMS.Models.Visitor;
using VMS_API.Interfaces;
using VMS_API.Models;

namespace VMS_API.Services
{
    public class CourierService : ICourier
    {
        private readonly VMSDBContext _context;
        public CourierService(VMSDBContext context)
        {
            _context = context;
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

        public async Task<CourierModel> GetCourierById(int Id)
        {
            CourierModel Model = new CourierModel();

            try
            {
                var data = _context.CourierTbs.Where(d => d.Id == Id).FirstOrDefault();

                Model.Id = data.Id;
                Model.CourierNo = data.CourierNo;
                Model.CourierCompany = data.CourierCompany;
                Model.CourierPersonName = data.CourierPersonName;
                Model.EmployeeName = data.EmployeeName;
                Model.EmployeeId = data.EmployeeId;
                Model.Time = data.Time;
                Model.Date = Convert.ToDateTime(data.Date);
                Model.Description = data.Description;
                Model.photo = data.PhotoPath;
                Model.certificate = data.CertifactePath;
            }
            catch (Exception ex)
            {
                return Model;
            }
            return Model;
        }
        public async Task<string> SaveCourier(CourierModel courier)
        {
            CourierTb tB = new CourierTb();
            tB.CourierNo = courier.CourierNo;
            tB.CourierCompany = courier.CourierCompany;
            tB.CourierPersonName = courier.CourierPersonName;
            tB.EmployeeId = courier.EmployeeId;
            var user = _context.UserTbs.Where(d => d.UserId == courier.EmployeeId).FirstOrDefault();
            tB.EmployeeName = user.Name;
            tB.Time = courier.Time;
            tB.Date = courier.Date;
            tB.Description = courier.Description;
            tB.PhotoPath = courier.photo = String.IsNullOrEmpty(courier.photo) ? courier.PhotoPath : courier.photo;
            tB.CertifactePath = courier.certificate = String.IsNullOrEmpty(courier.certificate) ? courier.certificatePath : courier.certificate;
            tB.UserId = courier.userId;
            _context.CourierTbs.Add(tB);
            _context .SaveChanges();
            return "courier save success";
        }
        public async Task<string> EditCourier(CourierModel courier)
        {
            var check = _context.CourierTbs.Where(d => d.Id == courier.Id).FirstOrDefault();

            check.CourierNo = courier.CourierNo;
            check.CourierCompany = courier.CourierCompany;
            check.CourierPersonName = courier.CourierPersonName;
            check.EmployeeId = courier.EmployeeId;
            var user = _context.UserTbs.Where(d => d.UserId == courier.EmployeeId).FirstOrDefault();
            check.EmployeeName = user.Name;
            check.Time = courier.Time;
            check.Date = courier.Date;
            check.Description = courier.Description;
            check.UserId = courier.userId;
            check.PhotoPath = courier.photo = String.IsNullOrEmpty(courier.photo) ? courier.PhotoPath : courier.photo;
            check.CertifactePath = courier.certificate = String.IsNullOrEmpty(courier.certificate) ? courier.certificatePath : courier.certificate;
            _context.Entry(check).State = EntityState.Modified;
            _context.SaveChanges();
            return "courier save success";
        }
    }
}
