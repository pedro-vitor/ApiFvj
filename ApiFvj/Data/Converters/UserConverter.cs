using System.Collections.Generic;
using System.Linq;
using ApiFvj.Data.Converter;
using ApiFvj.Data.VO;
using ApiFvj.Models;

namespace ApiFvj.Data.Converters
{
    public class UserConverter : IParse<UserVO, Users>, IParse<Users, UserVO>
    {
        public Users Parse(UserVO origin)
        {
            if (origin == null) return new Users();
            return new Users()
            {
                Id = origin.Id,
                name = origin.name,
                email = origin.email,
                password = origin.password,
                active = origin.active,
                createdat = origin.createdat
            };
        }

        public List<Users> Parse(List<UserVO> origin)
        {
            if (origin == null) return new List<Users>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public UserVO Parse(Users origin)
        {
            if (origin == null) return new UserVO();
            return new UserVO()
            {
                Id = origin.Id,
                name = origin.name,
                email = origin.email,
                password = origin.password,
                active = origin.active,
                createdat = origin.createdat
            };
        }

        public List<UserVO> Parse(List<Users> origin)
        {
            if (origin == null) return new List<UserVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}