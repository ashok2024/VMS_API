using Microsoft.EntityFrameworkCore;
using VMS.Models.Employee;
using VMS.Models.Visitor;
using VMS_API.Interfaces;
using VMS_API.Models;

namespace VMS_API.Services
{
    public class EmployeeService:IEmployee
    {
        private readonly VMSDBContext _context;
        public EmployeeService(VMSDBContext context)
        {
            _context = context;
        }
        public async Task<EmployeeDashboardModel> GetEmployeeDashboardDetaisl(int UserId)
        {
            EmployeeDashboardModel Model = new EmployeeDashboardModel();

            try
            {
                var visitors = _context.VisitorEntryTbs.Where(d => d.EmployeeId == UserId).ToList();
                Model.TotalVisitorCount = visitors.Count();

                var Aprovedvisitors = _context.VisitorStatusTbs.Where(d => d.UserId == UserId && d.Status == "Approve").ToList();
                Model.TotalVisitedCount = Aprovedvisitors.Count();

                var Rejectedvisitors = _context.VisitorStatusTbs.Where(d => d.UserId == UserId && d.Status == "Reject").ToList();
                Model.TotalRejectedVisitorCount = Rejectedvisitors.Count();

                var upcomevisitors = visitors.Where(d => d.FromDate > DateTime.Now).ToList();
                Model.TotalupcomingVisitorCount = upcomevisitors.Count();

                var userdata = _context.UserTbs.Where(d => d.UserId == UserId).FirstOrDefault();

                var deliveries = _context.CourierTbs.Where(d => d.EmployeeName == userdata.Name).ToList();
                Model.TotalDeliveries = deliveries.Count();

                Model.TotalDefaultVisitorCount = 0;

            }
            catch (Exception ex)
            {
                return Model;
                throw ex;
            }
            return Model;
        }

       

        public async Task<List<VisitorEntryModel>> GetEmployeVisitor(int UserId)
        {
            List<VisitorEntryModel> Model = new List<VisitorEntryModel>();
           
            try
            {
                var visitors = _context.VisitorEntryTbs.Where(d => d.EmployeeId == UserId).ToList().OrderByDescending(d => d.Id);

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
                    visitor.InTime = item.InTime;
                    visitor.OutTime = item.OutTime;
                    visitor.VisitDateFrom = Convert.ToDateTime(item.FromDate);
                    visitor.VisitDateTo = Convert.ToDateTime(item.ToDate);
                    visitor.Purpose = item.Purpose;
                    visitor.Priority = item.Priority;

                    var status = _context.VisitorStatusTbs.Where(x => x.VisitId == item.Id).FirstOrDefault();
                    if (status == null)
                    {
                        visitor.Status = null;
                    }
                    else
                    {
                        visitor.Status = status.Status;
                    }

                    Model.Add(visitor);
                }
            }
            catch (Exception ex)
            {
                return Model;
                throw ex;
            }
            return Model;
        }

        public async Task<string> SaveVisitorStatus(ApproveRejectModel data)
        {
            try
            {
                VisitorStatusTb tB = new VisitorStatusTb();

                tB.VisitId = data.VisitId;
                tB.UserId = data.UserId;
                tB.Status = data.Status;
                _context.VisitorStatusTbs.Add(tB);
                _context.SaveChanges();

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "status save ";
        }

        public async Task<List<VisitorEntryModel>> GetEmployeeScheduledVisit(int UserId)
        {
            List<VisitorEntryModel> Model = new List<VisitorEntryModel>();

            try
            {
                var scheduleList = _context.EmployeeScheduledVisitTbs.Where(d => d.EmployeeId == UserId).ToList();

                foreach (var item in scheduleList)
                {
                    var visitors = _context.VisitorEntryTbs.Where(d => d.Id == item.VisitId).FirstOrDefault();

                    VisitorEntryModel visitor = new VisitorEntryModel();
                    visitor.Id = item.Id;
                    visitor.VisitorId = visitors.VisitorId;
                    visitor.Name = visitors.Name;
                    visitor.Contact = visitors.Contact;
                    visitor.Company = visitors.Company;
                    visitor.InTime = visitors.InTime;
                    visitor.OutTime = visitors.OutTime;
                    visitor.VisitDateFrom = Convert.ToDateTime(visitors.FromDate);
                    visitor.VisitDateTo = Convert.ToDateTime(visitors.ToDate);
                    visitor.Purpose = visitors.Purpose;
                    visitor.Priority = visitors.Priority;
                    Model.Add(visitor);
                }
            }
            catch (Exception ex)
            {
                return Model;
                throw ex;
            }
            return Model;
        }
        public async Task<VisitorEntryModel> GetEmployeeScheduledVisitByid(int userId)
        {
            VisitorEntryModel Model = new VisitorEntryModel();            

            try
            {
                var schedule = _context.EmployeeScheduledVisitTbs.Where(d => d.Id == userId).FirstOrDefault();

                var visitors = _context.VisitorEntryTbs.Where(d => d.Id == schedule.VisitId).FirstOrDefault();

                Model.Id = schedule.Id;
                Model.VisitorId = visitors.VisitorId;
                Model.Name = visitors.Name;
                Model.Contact = visitors.Contact;
                Model.Company = visitors.Company;
                Model.InTime = visitors.InTime;
                Model.OutTime = visitors.OutTime;
                Model.VisitDateFrom = Convert.ToDateTime(visitors.FromDate);
                Model.VisitDateTo = Convert.ToDateTime(visitors.ToDate);
                Model.Purpose = visitors.Purpose;
                Model.Priority = visitors.Priority;

            }
            catch (Exception ex)
            {
                return Model;
                throw ex;
            }
            return Model;
        }
        public async Task<string> ScheduleVisit(VisitorEntryModel visitor)
        {

            try
            {
                if (visitor.Id > 0)
                {
                    var check = _context.EmployeeScheduledVisitTbs.Where(d => d.Id == visitor.Id).FirstOrDefault();

                    var checkvisit = _context.VisitorEntryTbs.Where(d => d.Id == check.VisitId).FirstOrDefault();

                    checkvisit.Name = visitor.Name;
                    checkvisit.Company = visitor.Company;
                    checkvisit.Address = visitor.Address;
                    checkvisit.InTime = visitor.InTime;
                    checkvisit.OutTime = visitor.OutTime;
                    checkvisit.FromDate = visitor.VisitDateFrom;
                    checkvisit.ToDate = visitor.VisitDateTo;
                    checkvisit.EmailId = visitor.EmailId;
                    checkvisit.Contact = visitor.Contact;
                    checkvisit.Purpose = visitor.Purpose;
                    checkvisit.Remark = visitor.Remark;
                    checkvisit.Priority = visitor.Priority;
                    checkvisit.UserId = visitor.userId;
                    _context.Entry(checkvisit).State = EntityState.Modified;

                    check.EmployeeId = checkvisit.EmployeeId;
                    check.VisitId = checkvisit.Id;
                    _context.Entry(check).State = EntityState.Modified;

                    _context.SaveChanges();
                }
                else
                {
                    VisitorTb dt = new VisitorTb();

                    var visitordata = _context.VisitorTbs.Where(d => d.Contact == visitor.Contact).FirstOrDefault();

                    if (visitordata != null)
                    {
                        // tB.Id = supplier.Id;
                        VisitorEntryTb tB = new VisitorEntryTb();
                        tB.EmployeeId = visitor.userId;
                        tB.VisitorId = visitordata.VisitorId;
                        tB.Name = visitor.Name;
                        tB.Company = visitor.Company;
                        tB.Address = visitor.Address;
                        tB.InTime = visitor.InTime;
                        tB.FromDate = visitor.VisitDateFrom;
                        tB.EmailId = visitor.EmailId;
                        tB.Contact = visitor.Contact;
                        tB.Purpose = visitor.Purpose;
                        tB.Remark = visitor.Remark;
                        tB.Priority = visitor.Priority;
                        tB.UserId = visitor.userId;
                        _context.VisitorEntryTbs.Add(tB);
                        _context.SaveChanges();

                        EmployeeScheduledVisitTb employee = new EmployeeScheduledVisitTb();
                        employee.EmployeeId = tB.EmployeeId;
                        employee.VisitId = tB.Id;
                        _context.EmployeeScheduledVisitTbs.Add(employee);
                        _context.SaveChanges();
                    }
                    else
                    {
                        Random generator = new Random();
                        string rand = generator.Next(0, 1000000).ToString("D6");
                        dt.VisitorId = rand;
                        dt.Name = visitor.Name;
                        dt.Contact = visitor.Contact;
                        dt.EmailId = visitor.EmailId;
                        dt.Company = visitor.Company;
                        dt.Photo = visitor.PhotoPath;
                        _context.VisitorTbs.Add(dt);
                        _context.SaveChanges();

                        // tB.Id = supplier.Id;
                        VisitorEntryTb tB = new VisitorEntryTb();
                        tB.EmployeeId = visitor.userId;
                        tB.VisitorId = dt.VisitorId;
                        tB.Name = visitor.Name;
                        tB.Company = visitor.Company;
                        tB.Address = visitor.Address;
                        tB.InTime = visitor.InTime;
                        tB.FromDate = visitor.VisitDateFrom;
                        tB.EmailId = visitor.EmailId;
                        tB.Contact = visitor.Contact;
                        tB.Purpose = visitor.Purpose;
                        tB.Remark = visitor.Remark;
                        tB.Priority = visitor.Priority;
                        tB.UserId = visitor.userId;
                        _context.VisitorEntryTbs.Add(tB);
                        _context.SaveChanges();

                        EmployeeScheduledVisitTb employee = new EmployeeScheduledVisitTb();
                        employee.EmployeeId = tB.EmployeeId;
                        employee.VisitId = tB.Id;
                        _context.EmployeeScheduledVisitTbs.Add(employee);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "shedule save success";
        }

        public async Task<List<VisitorEntryModel>> ApproveVisitorReport(int userid)
        {
            List<VisitorEntryModel> Model = new List<VisitorEntryModel>();           

            try
            {
                var visitors = _context.VisitorEntryTbs.Where(d => d.EmployeeId == userid).ToList();

                foreach (var item in visitors)
                {
                    var status = _context.VisitorStatusTbs.Where(d => d.VisitId == item.Id).FirstOrDefault();

                    if (status != null)
                    {
                        if (status.Status == "Approve")
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
                            Model.Add(visitor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Model;
                throw ex;
            }
            return Model;
        }
        public async Task<List<VisitorEntryModel>> RejectVisitorReport(int userid)
        {
            List<VisitorEntryModel> Model = new List<VisitorEntryModel>();

            try
            {
                var visitors = _context.VisitorEntryTbs.Where(d => d.EmployeeId == userid).ToList();

                foreach (var item in visitors)
                {
                    var status = _context.VisitorStatusTbs.Where(d => d.VisitId == item.Id).FirstOrDefault();

                    if (status != null)
                    {
                        if (status.Status == "Reject")
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
                            Model.Add(visitor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Model;
                throw ex;
            }
            return Model;
        }
    }
}
