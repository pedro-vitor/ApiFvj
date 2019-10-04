using ApiFvj.Business;
using ApiFvj.Business.Implamentation;
using ApiFvj.Data.VO;
using ApiFvj.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ApiFvj.Controllers
{
    [RoutePrefix("api/Lead")]
    public class LeadController : ApiController
    {
        private ILeadBusiness _leadBusiness;

        public LeadController()
        {
            _leadBusiness = new LeadBusinessImpl();
        }

        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_leadBusiness.FindAll());
        }

        // GET api/<controller>/5

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_leadBusiness.FindById(id));
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody]List<LeadVO> lead)
        {
            if (lead == null) return BadRequest();
            return Ok(_leadBusiness.Create(lead));
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put([FromBody]List<LeadVO> lead)
        {
            if (lead == null) return BadRequest();
            return Ok(_leadBusiness.Update(lead));
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _leadBusiness.Delete(id);
        }
    }
}