using ApiFvj.Business;
using ApiFvj.Business.Implamentation;
using ApiFvj.Data.VO;
using ApiFvj.Fiilters;
using ApiFvj.Models;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Web.Http;

namespace ApiFvj.Controllers
{
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
            return Ok(_repository.FindAll());
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
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}