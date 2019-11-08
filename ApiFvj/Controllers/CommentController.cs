using ApiFvj.Business;
using ApiFvj.Business.Implamentation;
using ApiFvj.Data.VO;
using ApiFvj.Fiilters;
using ApiFvj.Models;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiFvj.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    [RoutePrefix("api/Comment")]
    public class CommentController : ApiController
    {
        private ICommentBusiness _repository;

        public CommentController()
        {
            _repository = new CommentBusinessImpl();
        }

        // GET api/<controller>
        [HttpGet]
        [SwaggerResponse(200, Type = typeof(List<CommentVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IHttpActionResult Get()
        {
             return Json(new { Result = _repository.FindAll(), Deleted = _repository.DeletedLeads() });
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
            return Ok(_repository.FindById(id));
        }

        // POST api/<controller>
        [HttpPost]
        [SwaggerResponse(201, Type = typeof(List<LeadVO>))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IHttpActionResult Post([FromBody] List<CommentVO> comment)
        {
            if (comment == null) return BadRequest();

            return Ok(_repository.Create(comment));
        }

        // PUT api/<controller>/5
        [HttpPut]
        [SwaggerResponse(202, Type = typeof(List<CommentVO>))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IHttpActionResult Put([FromBody]List<CommentVO> comment)
        {
            if (comment != null) BadRequest();
            return Ok(_repository.Update(comment));
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public void Delete(List<CommentVO> itens)
        {
            _repository.Delete(itens);
        }
    }
}