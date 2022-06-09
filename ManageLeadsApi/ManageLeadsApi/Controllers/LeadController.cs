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
        public async Task<IActionResult> Get()
        {
            return Ok(await _applicationServiceLead.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _applicationServiceLead.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LeadDTO leadDto)
        {
            try
            {
                if (leadDto == null)
                {
                    return NotFound();
                }

                await _applicationServiceLead.Add(leadDto);
                return Ok("Lead Inserted with success!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LeadDTO leadDto)
        {
            try
            {
                if (leadDto == null)
                {
                    return NotFound();
                }

                await _applicationServiceLead.Update(leadDto);
                return Ok(string.Format("Lead {0}-{1} updated!", leadDto.Id, leadDto.FirstName));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] LeadDTO leadDto)
        {
            try
            {
                if (leadDto == null)
                {
                    return NotFound();
                }

                await _applicationServiceLead.Delete(leadDto);
                return Ok(string.Format("Lead {0}-{1} deleted!", leadDto.Id, leadDto.FirstName));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   