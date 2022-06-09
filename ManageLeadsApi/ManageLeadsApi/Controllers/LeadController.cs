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

                leadDto.DateCreated = DateTime.Now; 

                await _applicationServiceLead.Add(leadDto);
                return Ok("Lead Inserted with success!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] LeadDTO leadDto)
        {
            try
            {
                if (leadDto == null)
                {
                    return NotFound();
                }

                LeadDTO leadBase = await _applicationServiceLead.GetById(leadDto.Id);

                leadBase.Id = leadDto.Id == null ? leadBase.Id : leadDto.Id;
                leadBase.FirstName = leadDto.FirstName == null ? leadBase.FirstName : leadDto.FirstName;
                leadBase.LastName = leadDto.LastName == null ? leadBase.LastName : leadDto.LastName;
                leadBase.Suburb = leadDto.Suburb == null ? leadBase.Suburb : leadDto.Suburb;
                leadBase.Category = leadDto.Category == null ? leadBase.Category : leadDto.Category;
                leadBase.Description = leadDto.Description == null ? leadBase.Description : leadDto.Description;
                leadBase.Price = leadDto.Price == null ? leadBase.Price : leadDto.Price;
                leadBase.Status = leadDto.Status == null ? leadBase.Status : leadDto.Status;

                await _applicationServiceLead.Update(leadBase);
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

                LeadDTO leadBase = await _applicationServiceLead.GetById(leadDto.Id);

                await _applicationServiceLead.Delete(leadBase);
                return Ok(string.Format("Lead {0}-{1} deleted!", leadDto.Id, leadDto.FirstName));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   