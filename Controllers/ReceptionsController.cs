using Microsoft.AspNetCore.Mvc;
using VMS_API.Interfaces;

namespace VMS_API.Controllers
{
    public class ReceptionsController : Controller
    {
        private IReceptioncs _receptioncs;
        public ReceptionsController(IReceptioncs receptioncs)
        { 
            _receptioncs = receptioncs; 
        }
    }
}
