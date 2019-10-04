using ApiFvj.Data.VO;
using ApiFvj.Models;
using System.Collections.Generic;

namespace ApiFvj.Business
{
    public interface ILeadBusiness 
    {
        List<LeadVO> Create(List<LeadVO> item);
        LeadVO FindById(int Id);
        List<LeadVO> FindAll();
        List<LeadVO> Update(List<LeadVO> item);
        void Delete(int id);

        bool Exist(int id);
    }
}
