using ApiFvj.Models.Base;

namespace ApiFvj.Business
{
    public interface ILoginBusiness 
    {
        User FindByLogin(string email, string password);
    }
}
