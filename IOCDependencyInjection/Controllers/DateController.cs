using IOCDependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace IOCDependencyInjection.Controllers
{
    public class DateController : Controller
    {
        private readonly IShowDateTime _date1;

        public DateController(IShowDateTime date1)
        {
            _date1 = date1;
        }

        public IActionResult Index([FromServices] IShowDateTime _date2)
        {
            IShowDateTime showDateTime= new ShowDateTime();

            var time1 = _date1.GetDateTime.TimeOfDay;
            var time2 = _date2.GetDateTime.TimeOfDay;

            return Content($"Time 1: {time1} ");
        }
    }
}
