using ApiFvj.Data.VO;
using ApiFvj.Models;
using System.Collections.Generic;

namespace ApiFvj.Business
{
    public interface IUserBusiness
    {
        List<UserVO> Create(List<UserVO> item);
        UserVO FindById(int Id);
        List<UserVO> FindAll();
        List<UserVO> Update(List<UserVO> item);
        void Delete(int id);

        bool Exist(int id);
    }
}
