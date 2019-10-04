using ApiFvj.Data.Converters;
using ApiFvj.Data.VO;
using ApiFvj.Models.Base;
using ApiFvj.Repository.Generic;
using System.Collections.Generic;

namespace ApiFvj.Business.Implamentation
{
    public class UserBusinessImpl : IUserBusiness
    {
        private IRepository<User> _repository;
        private readonly UserConverter _converter;
        private List<UserVO> idList;

        public UserBusinessImpl()
        {
            _repository = new GenericRepository<User>();
            _converter = new UserConverter();
            idList = new List<UserVO>();
        }

        public List<UserVO> Create(List<UserVO> item)
        {
            foreach (UserVO users in item)
            {
                var leadEntity = _converter.Parse(users);
                var result = _repository.Create(leadEntity);

                if (result != null)
                {
                    idList.Add(_converter.ParseToCreate(result,users.Id));
                }
            }
            return idList;
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

        public List<UserVO> Update(List<UserVO> item)
        {
            foreach (UserVO users in item)
            {
                var leadEntity = _converter.Parse(users);
                var result = _repository.Update(leadEntity);

                if (result != null)
                {
                    idList.Add(_converter.ParseToCreate(result, users.Id));
                }
            }
            return idList;
        }
    }
}