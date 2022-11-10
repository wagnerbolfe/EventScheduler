using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EventScheduler.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ErrorHandlerController : ControllerBase
    {
        [Route("error-development")]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.InnerException?.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }

        [Route("error")]
        public IActionResult HandleError() => Problem();
    }
}
