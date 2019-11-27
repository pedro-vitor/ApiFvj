using ApiFvj.Data.Converter;
using ApiFvj.Data.VO;
using ApiFvj.Models.Base;
using System.Collections.Generic;
using System.Linq;

namespace ApiFvj.Data.Converters
{
    public class UserConverter : IParser<UserVO, User>, IParser<User, UserVO>
    {
        public User Parse(UserVO origin)
        {
            if (origin == null) return new User();
            return new User()
            {
                Id = origin.ExternId,
                Name = origin.name,
                Email = origin.email,
                Password = origin.password,
                Active = origin.active,
                Createdat = origin.createdat,
                Permission = origin.Permission
            };
        }

        public List<User> Parse(List<UserVO> origin)
        {
            if (origin == null) return new List<User>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public UserVO Parse(User origin)
        {
            if (origin == null) return new UserVO();
            return new UserVO()
            {
                ExternId = origin.Id,
                name = origin.Name,
                email = origin.Email,
                password = origin.Password,
                active = origin.Active,
                createdat = origin.Createdat,
                Permission = origin.Permission
            };
        }

        public UserVO ParseToCreate(User origin, int id)
        {
            if (origin == null) return new UserVO();
            return new UserVO()
            {
                Id = id,
                ExternId = origin.Id,
                name = origin.Name,
                email = origin.Email,
                password = origin.Password,
                active = origin.Active,
                createdat = origin.Createdat,
                Permission = origin.Permission
            };
        }

        public List<UserVO> Parse(List<User> origin)
        {
            if (origin == null) return new List<UserVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}