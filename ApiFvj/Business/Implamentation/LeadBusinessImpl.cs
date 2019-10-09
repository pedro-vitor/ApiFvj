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
        private IRepository<Comment> _repositoryComment;
        private readonly LeadConverter _converter;
        private readonly CommentConverter _converterComments;
        private List<LeadVO> _idList;
        private readonly ICommentBusiness _comments;

        public LeadBusinessImpl()
        {
            _repository         = new GenericRepository<Lead>();
            _repositoryComment  = new GenericRepository<Comment>();
            _converter          = new LeadConverter();
            _converterComments  = new CommentConverter();
            _idList             = new List<LeadVO>();
            _comments           = new CommentBusinessImpl();
        }

        public List<LeadVO> Create(List<LeadVO> item)
        {
            foreach (LeadVO lead in item)
            {
                var leadEntity = _converter.Parse(lead);
                var result = _repository.Create(leadEntity);

                if (result != null)
                {
                    _idList.Add(_converter.ParseToCreate(result,lead.Id));
                }
            }
            return _idList;
        }

        public LeadVO FindById(int Id)
        {
            return _converter.Parse(_repository.FindById(Id));
        }

        public List<LeadVO> FindAll()
        {
            List<LeadVO> listLeads = new List<LeadVO>();
            var leads = _converter.Parse(_repository.FindAll());
            foreach (LeadVO lds in leads)
            {
                if (lds.active != 0)
                {
                    listLeads.Add(lds);
                }
            }
            return listLeads;
        }

        public List<LeadVO> Update(List<LeadVO> item)
        {
            foreach (LeadVO lead in item)
            {
                var leadEntity = _converter.Parse(lead);
                var result = _repository.Update(leadEntity);

                if (result != null)
                {
                    _idList.Add(_converter.ParseToCreate(result, lead.Id));
                }
            }
            return _idList;
        }

        public void Delete(List<LeadVO> itens)
        {
            foreach (LeadVO lead in itens)
            {
                var leadEntity = _converter.Parse(lead);
                var listComments = _comments.FindAll();
                foreach (CommentVO cmm in listComments)
                {
                    if (cmm.LeadId == lead.ExternId)
                    {
                        cmm.active = 0;
                        _repositoryComment.Delete(_converterComments.Parse(cmm));
                    }
                }
                _repository.Delete(leadEntity);
                
            }
        }

        public bool Exist(int id)
        {
            return _repository.Exist(id);
        }
    }
}