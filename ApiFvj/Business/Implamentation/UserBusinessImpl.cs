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

        public void Delete(List<UserVO> itens)
        {
            foreach (UserVO user in itens)
            {
                var userEntity = _converter.Parse(user);
                _repository.Delete(userEntity);
            }
        }

        public bool Exist(int id)
        {
            return _repository.Exist(id);
        }

        public List<UserVO> FindAll()
        {
            List<UserVO> listUsers = new List<UserVO>();
            var leads = _converter.Parse(_repository.FindAll());
            foreach (UserVO usr in leads)
            {
                if (usr.active != 0)
                {
                    listUsers.Add(usr);
                }
            }
            return listUsers;
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

        public List<int> DeletedLeads()
        {
            List<int> ids = new List<int>();
            var users = _converter.Parse(_repository.FindAll());
            foreach (UserVO usr in users)
            {
                if (usr.active == 0)
                {
                    ids.Add(usr.ExternId);
                }
            }
            return ids;
        }
    }
}