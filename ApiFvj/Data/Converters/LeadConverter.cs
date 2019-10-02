using ApiFvj.Data.Converter;
using ApiFvj.Data.VO;
using ApiFvj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFvj.Data.Converters
{
    public class LeadConverter : IParse<LeadVO, Lead>, IParse<Lead, LeadVO>
    {
        public Lead Parse(LeadVO origin)
        {
            if (origin == null) return new Lead();
            return new Lead()
            {
                Id = origin.Id,
                UsersId = origin.UsersId,
                name = origin.name,
                numberphone = origin.numberphone,
                desiredcourse = origin.desiredcourse,
                town = origin.town,
                adress = origin.adress,
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
                Id = origin.Id,
                UsersId = origin.UsersId,
                name = origin.name,
                numberphone = origin.numberphone,
                desiredcourse = origin.desiredcourse,
                town = origin.town,
                adress = origin.adress,
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