using ApiFvj.Data.Converters;
using ApiFvj.Data.VO;
using ApiFvj.Models.Base;
using ApiFvj.Repository.Generic;
using System.Collections.Generic;

namespace ApiFvj.Business.Implamentation
{
    public class CommentBusinessImpl : ICommentBusiness
    {
        private IRepository<Comment> _repository;
        private readonly CommentConverter _converter;
        private List<CommentVO> idList;

        public CommentBusinessImpl()
        {
            _repository = new GenericRepository<Comment>();
            _converter = new CommentConverter();
            idList = new List<CommentVO>();
        }

        public List<CommentVO> Create(List<CommentVO> item)
        {
            foreach (CommentVO comment in item)
            {
                var leadEntity = _converter.Parse(comment);
                var result = _repository.Create(leadEntity);
                if (result != null)
                {
                    idList.Add(_converter.ParseToCreate(result,comment.Id));
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

        public List<CommentVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public CommentVO FindById(int Id)
        {
            return _converter.Parse(_repository.FindById(Id));
        }

        public List<CommentVO> Update(List<CommentVO> item)
        {
            foreach (CommentVO comment in item)
            {
                var leadEntity = _converter.Parse(comment);
                var result = _repository.Update(leadEntity);
                if (result != null)
                {
                    idList.Add(_converter.ParseToCreate(result, comment.Id));
                }
            }
            return idList;
        }
    }
}
