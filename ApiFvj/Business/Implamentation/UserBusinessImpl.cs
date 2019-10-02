using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiFvj.Data.Converters;
using ApiFvj.Data.VO;
using ApiFvj.Models;
using ApiFvj.Repository.Generic;

namespace ApiFvj.Business.Implamentation
{
    public class UserBusinessImpl : IUserBusiness
    {
        private IRepository<Users> _repository;
        private readonly UserConverter _converter;

        public UserBusinessImpl()
        {
            _repository = new GenericRepository<Users>();
            _converter = new UserConverter();
        }

        public UserVO Create(UserVO item)
        {
            var userEntity = _converter.Parse(item);
            userEntity = _repository.Create(userEntity);
            return _converter.Parse(userEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool Exist(int id)
        {
            return _repository.Exist(id);
        }

        public List<UserVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public UserVO FindById(int Id)
        {
            return _converter.Parse(_repository.FindById(Id));
        }

        public UserVO Update(UserVO item)
        {
            var userEntity = _converter.Parse(item);
            userEntity = _repository.Update(userEntity);
            return _converter.Parse(userEntity);
        }
    }
}