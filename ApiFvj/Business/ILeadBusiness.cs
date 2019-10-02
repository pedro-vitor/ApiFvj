using ApiFvj.Data.VO;
using System.Collections.Generic;

namespace ApiFvj.Business
{
    public interface ILeadBusiness 
    {
        LeadVO Create(LeadVO item);
        LeadVO FindById(int Id);
        List<LeadVO> FindAll();
        LeadVO Update(LeadVO item);
        void Delete(int id);

        bool Exist(int id);
    }
}
