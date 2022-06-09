using ManageLeadsApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageLeadsApi.Controllers
{
    [Route("lead/")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly IApplicationServiceLead _applicationServiceLead;

        public LeadController(IApplicationServiceLead applicationServiceLead)
        {
            _applicationServiceLead = applicationServiceLead;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_applicationServiceLead.GetAll());
        }


    }
}
