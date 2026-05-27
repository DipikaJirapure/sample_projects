using Hangfire;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class JobsController : Controller
    {
        public IActionResult RunJob()
        {
            //BackgroundJob.Enqueue<EmailJobService>(
            //    x => x.SendWelcomeEmail(
            //        "dipika.borwar@autodesk.com"));

            return Content("Background job started");
        }
    }
}
