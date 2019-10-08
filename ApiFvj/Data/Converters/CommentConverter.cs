using ApiFvj.Data.Converter;
using ApiFvj.Data.VO;
using ApiFvj.Models.Base;
using System.Collections.Generic;
using System.Linq;

namespace ApiFvj.Data.Converters
{
    public class CommentConverter : IParser<CommentVO, Comment>, IParser<Comment, CommentVO>
    {
        public Comment Parse(CommentVO origin)
        {
            if (origin == null) return new Comment();
            return new Comment()
            {
                Id = origin.ExternId,
                UserId = origin.UserId,
                LeadId = origin.LeadId,
                Text = origin.text,
                Createdat = origin.createdat
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
                ExternId = origin.Id,
                UserId = origin.UserId,
                LeadId = origin.LeadId,
                text = origin.Text,
                createdat = origin.Createdat,
            };
        }

        public CommentVO ParseToCreate(Comment origin, int id)
        {
            if (origin == null) return new CommentVO();
            return new CommentVO()
            {
                Id = id,
                ExternId = origin.Id,
                UserId = origin.UserId,
                LeadId = origin.LeadId,
                text = origin.Text,
                createdat = origin.Createdat,
            };
        }

        public List<CommentVO> Parse(List<Comment> origin)
        {
            if (origin == null) return new List<CommentVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}