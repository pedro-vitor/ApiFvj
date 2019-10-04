using ApiFvj.Data.Converters;
using ApiFvj.Data.VO;
using ApiFvj.Models.Base;
using ApiFvj.Repository.Generic;
using System.Collections.Generic;

namespace ApiFvj.Business.Implamentation
{
    public class LeadBusinessImpl : ILeadBusiness
    {
        private IRepository<Lead> _repository;
        private readonly LeadConverter _converter; 
        private List<LeadVO> idList;

        public LeadBusinessImpl()
        {
            _repository = new GenericRepository<Lead>();
            _converter = new LeadConverter();
            idList = new List<LeadVO>();
        }

        public List<LeadVO> Create(List<LeadVO> item)
        {
            foreach (LeadVO lead in item)
            {
                var leadEntity = _converter.Parse(lead);
                var result = _repository.Create(leadEntity);

                if (result != null)
                {
                    idList.Add(_converter.ParseToCreate(result,lead.Id));
                }
            }
            return idList;
        }

        public LeadVO FindById(int Id)
        {
            return _converter.Parse(_repository.FindById(Id));
        }

        public List<LeadVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public List<LeadVO> Update(List<LeadVO> item)
        {
            foreach (LeadVO lead in item)
            {
                var leadEntity = _converter.Parse(lead);
                var result = _repository.Update(leadEntity);

                if (result != null)
                {
                    idList.Add(_converter.ParseToCreate(result, lead.Id));
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
    }
}