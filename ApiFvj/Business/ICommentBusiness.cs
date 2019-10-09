using ApiFvj.Data.VO;
using ApiFvj.Models;
using System.Collections.Generic;

namespace ApiFvj.Business
{
    public interface ICommentBusiness
    {
        List<CommentVO> Create(List<CommentVO> item);
        CommentVO FindById(int Id);
        List<CommentVO> FindAll();
        List<CommentVO> Update(List<CommentVO> item);
        void Delete(List<CommentVO> id);

        bool Exist(int id);
    }
}
