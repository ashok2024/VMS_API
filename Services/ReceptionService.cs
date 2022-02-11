using VMS_API.Interfaces;
using VMS_API.Models;

namespace VMS_API.Services
{
    public class ReceptionService: IReceptioncs
    {
        private readonly VMSDBContext _context;
        public ReceptionService(VMSDBContext context)
        {
            _context = context;
        }


    }
}
