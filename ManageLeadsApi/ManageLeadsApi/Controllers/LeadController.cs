using ManageLeadsApp.DTO;
using ManageLeadsApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageLeadsApi.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_applicationServiceLead.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] LeadDTO leadDto)
        {
            try
            {
                if (leadDto == null)
                {
                    return NotFound();
                }

                _applicationServiceLead.Add(leadDto);
                return Ok("Lead Inserted with success!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Update([FromBody] LeadDTO leadDto)
        {
            try
            {
                if (leadDto == null)
                {
                    return NotFound();
                }

                _applicationServiceLead.Update(leadDto);
                return Ok(string.Format("Lead {0}-{1} updated!", leadDto.Id, leadDto.FirstName));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] LeadDTO leadDto)
        {
            try
            {
                if (leadDto == null)
                {
                    return NotFound();
                }

                _applicationServiceLead.Delete(leadDto);
                return Ok(string.Format("Lead {0}-{1} deleted!", leadDto.Id, leadDto.FirstName));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   