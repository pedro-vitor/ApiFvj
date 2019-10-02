using ApiFvj.Data.VO;
using System.Collections.Generic;

namespace ApiFvj.Business
{
    public interface IUserBusiness
    {
        UserVO Create(UserVO item);
        UserVO FindById(int Id);
        List<UserVO> FindAll();
        UserVO Update(UserVO item);
        void Delete(int id);

        bool Exist(int id);
    }
}
