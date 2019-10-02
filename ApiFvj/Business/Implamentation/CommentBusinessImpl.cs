using System.Collections.Generic;
using ApiFvj.Data.Converters;
using ApiFvj.Data.VO;
using ApiFvj.Models;
using ApiFvj.Repository.Generic;

namespace ApiFvj.Business.Implamentation
{
    public class CommentBusinessImpl : ICommentBusiness
    {
        private IRepository<Comment> _repository;
        private readonly CommentConverter _converter;

        public CommentBusinessImpl()
        {
            _repository = new GenericRepository<Comment>();
            _converter = new CommentConverter();
        }

        public CommentVO Create(CommentVO item)
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

        public List<CommentVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public CommentVO FindById(int Id)
        {
            return _converter.Parse(_repository.FindById(Id));
        }

        public CommentVO Update(CommentVO item)
        {
            var userEntity = _converter.Parse(item);
            userEntity = _repository.Update(userEntity);
            return _converter.Parse(userEntity);
        }
    }
}