using ApiFvj.Models.Base;

namespace ApiFvj.Repository
{
    interface ILoginRepository
    {
        User FindByLogin(string email, string password);
    }
}
