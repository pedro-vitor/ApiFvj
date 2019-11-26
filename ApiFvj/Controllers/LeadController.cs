using ApiFvj.Business;
using ApiFvj.Business.Implamentation;
using ApiFvj.Data.VO;
using ApiFvj.Models;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Web.Http;
// using System.Web.Http.Cors;

namespace ApiFvj.Controllers
{
 // [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
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
        [SwaggerResponse(200, Type = typeof(List<LeadVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IHttpActionResult Get()
        {
            return Json(new {Result = _leadBusiness.FindAll(),Deleted = _leadBusiness.DeletedLeads()});
        }

        // GET api/<controller>/5

        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(200, Type = typeof(List<LeadVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IHttpActionResult Get(int id)
        {
            return Ok(_leadBusiness.FindById(id));
        }

        // POST api/<controller>
        [HttpPost]
        [SwaggerResponse(201, Type = typeof(List<LeadVO>))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IHttpActionResult Post([FromBody]List<LeadVO> lead)
        {
            if (lead == null) return BadRequest();
            return Ok(_leadBusiness.Create(lead));
        }

        // PUT api/<controller>/5
        [HttpPut]
        [SwaggerResponse(202, Type = typeof(List<LeadVO>))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IHttpActionResult Put([FromBody]List<LeadVO> lead)
        {
            if (lead == null) return BadRequest();
            return Ok(_leadBusiness.Update(lead));
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public void Delete(List<LeadVO> itens)
        {
            _leadBusiness.Delete(itens);
        }
    }
}