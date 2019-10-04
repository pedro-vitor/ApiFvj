using ApiFvj.Business;
using ApiFvj.Business.Implamentation;
using ApiFvj.Data.VO;
using ApiFvj.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ApiFvj.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private IUserBusiness _repository;

        public UserController()
        {
            _repository = new UserBusinessImpl();
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
        public IHttpActionResult Post([FromBody] List<UserVO> user)
        {
            if (user == null) return BadRequest();
            return Ok(_repository.Create(user));
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put([FromBody]List<UserVO> user)
        {
            if (user != null) BadRequest();
            return Ok(_repository.Update(user));
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