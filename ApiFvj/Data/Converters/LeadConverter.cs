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
                Name = origin.name,
                Phone = origin.numberphone,
                Course = origin.desiredcourse,
                Town = origin.town,
                Address = origin.address,
                Email = origin.email,
                Active = origin.active,
                Createdat = origin.createdat
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
                name = origin.Name,
                numberphone = origin.Phone,
                desiredcourse = origin.Course,
                town = origin.Town,
                address = origin.Address,
                email = origin.Email,
                active = origin.Active,
                createdat = origin.Createdat
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
                name = origin.Name,
                numberphone = origin.Phone,
                desiredcourse = origin.Course,
                town = origin.Town,
                address = origin.Address,
                email = origin.Email,
                active = origin.Active,
                createdat = origin.Createdat
            };
        }

        public List<LeadVO> Parse(List<Lead> origin)
        {
            if (origin == null) return new List<LeadVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}