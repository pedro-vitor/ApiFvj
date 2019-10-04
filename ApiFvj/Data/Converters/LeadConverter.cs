using ApiFvj.Data.Converter;
using ApiFvj.Data.VO;
using ApiFvj.Models.Base;
using System.Collections.Generic;
using System.Linq;

namespace ApiFvj.Data.Converters
{
    public class LeadConverter : IParser<LeadVO, Lead>, IParser<Lead, LeadVO>
    {
        public Lead Parse(LeadVO origin)
        {
            if (origin == null) return new Lead();
            return new Lead()
            {
                Id = origin.ExternId,
                UserId = origin.UserId,
                name = origin.name,
                numberphone = origin.numberphone,
                desiredcourse = origin.desiredcourse,
                town = origin.town,
                address = origin.address,
                email = origin.email,
                active = origin.active,
                createdat = origin.createdat
            };
        }

        public List<Lead> Parse(List<LeadVO> origin)
        {
            if (origin == null) return new List<Lead>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public LeadVO Parse(Lead origin)
        {
            if (origin == null) return new LeadVO();
            return new LeadVO()
            {
                ExternId = origin.Id,
                UserId = origin.UserId,
                name = origin.name,
                numberphone = origin.numberphone,
                desiredcourse = origin.desiredcourse,
                town = origin.town,
                address = origin.address,
                email = origin.email,
                active = origin.active,
                createdat = origin.createdat
            };
        }

        public LeadVO ParseToCreate(Lead origin, int id)
        {
            if (origin == null) return new LeadVO();
            return new LeadVO()
            {
                Id = id,
                ExternId = origin.Id,
                UserId = origin.UserId,
                name = origin.name,
                numberphone = origin.numberphone,
                desiredcourse = origin.desiredcourse,
                town = origin.town,
                address = origin.address,
                email = origin.email,
                active = origin.active,
                createdat = origin.createdat
            };
        }

        public List<LeadVO> Parse(List<Lead> origin)
        {
            if (origin == null) return new List<LeadVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}