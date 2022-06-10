using ManageLeadsApp.DTO;
using ManageLeadsApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageLeadsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IApplicationServiceEmail _applicationServiceEmail;

        public EmailController(IApplicationServiceEmail applicationServiceEmail)
        {
            _applicationServiceEmail = applicationServiceEmail;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] EmailDTO emailDto)
        {
            _applicationServiceEmail.SendEmailAsync(emailDto);
            return Ok();
        }
    }
}
