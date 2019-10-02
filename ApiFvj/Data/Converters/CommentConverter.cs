using ApiFvj.Data.Converter;
using ApiFvj.Data.VO;
using ApiFvj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFvj.Data.Converters
{
    public class CommentConverter : IParse<CommentVO, Comment>, IParse<Comment, CommentVO>
    {
        public Comment Parse(CommentVO origin)
        {
            if (origin == null) return new Comment();
            return new Comment()
            {
                Id = origin.Id,
                UsersId = origin.UsersId,
                LeadId = origin.LeadId,
                text = origin.text,
                createdat = origin.createdat
            };
        }

        public List<Comment> Parse(List<CommentVO> origin)
        {
            if (origin == null) return new List<Comment>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public CommentVO Parse(Comment origin)
        {
            if (origin == null) return new CommentVO();
            return new CommentVO()
            {
                Id = origin.Id,
                UsersId = origin.UsersId,
                LeadId = origin.LeadId,
                text = origin.text,
                createdat = origin.createdat
            };
        }

        public List<CommentVO> Parse(List<Comment> origin)
        {
            if (origin == null) return new List<CommentVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}