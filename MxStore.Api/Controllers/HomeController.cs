using Microsoft.AspNetCore.Mvc;

namespace MxStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public object Get()
        {
            return new {version = "Version 0.0.1"};
        }

        [HttpPost]
        [Route("")]
        public object Post()
        {
            return new { version = "Version 0.0.1" };
        }

        [HttpPut]
        [Route("")]
        public object Put()
        {
            return new { version = "Version 0.0.1" };
        }

        [HttpDelete]
        [Route("")]
        public object Delete()
        {
            return new { version = "Version 0.0.1" };
        }
    }
}
