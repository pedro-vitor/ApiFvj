using ApiFvj.Business;
using ApiFvj.Business.Implamentation;
using ApiFvj.Data.VO;
using ApiFvj.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ApiFvj.Controllers
{
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
        public IHttpActionResult Get()
        {
            return Ok(_repository.FindAll());
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_repository.FindById(id));
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody] List<CommentVO> comment)
        {
            if (comment == null) return BadRequest();

            return Ok(_repository.Create(comment));
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put([FromBody]List<CommentVO> comment)
        {
            if (comment != null) BadRequest();
            return Ok(_repository.Update(comment));
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}