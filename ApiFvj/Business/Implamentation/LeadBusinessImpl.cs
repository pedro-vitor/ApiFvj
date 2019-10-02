using System.Collections.Generic;
using ApiFvj.Data.Converters;
using ApiFvj.Data.VO;
using ApiFvj.Models;
using ApiFvj.Repository.Generic;

namespace ApiFvj.Business.Implamentation
{
    public class LeadBusinessImpl : ILeadBusiness
    {
        private IRepository<Lead> _repository;
        private readonly LeadConverter _converter;

        public LeadBusinessImpl()
        {
            _repository = new GenericRepository<Lead>();
            _converter = new LeadConverter();
        }

        public LeadVO Create(LeadVO item)
        {
            var leadEntity = _converter.Parse(item);
            leadEntity = _repository.Create(leadEntity);
            return _converter.Parse(leadEntity);
        }

        public LeadVO FindById(int Id)
        {
            return _converter.Parse(_repository.FindById(Id));
        }

        public List<LeadVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public LeadVO Update(LeadVO item)
        {
            var leadEntity = _converter.Parse(item);
            leadEntity = _repository.Update(leadEntity);
            return _converter.Parse(leadEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public bool Exist(int id)
        {
            return _repository.Exist(id);
        }
    }
}