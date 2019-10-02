using ApiFvj.Data.VO;
using System.Collections.Generic;

namespace ApiFvj.Business
{
    public interface ICommentBusiness
    {
        CommentVO Create(CommentVO item);
        CommentVO FindById(int Id);
        List<CommentVO> FindAll();
        CommentVO Update(CommentVO item);
        void Delete(int id);

        bool Exist(int id);
    }
}
