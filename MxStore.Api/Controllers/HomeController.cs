using Microsoft.AspNetCore.Mvc;

namespace MxStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public object asdfasdfGet()
        {
            return new {version = "Version 0.0.1"};
        }
    }
}
