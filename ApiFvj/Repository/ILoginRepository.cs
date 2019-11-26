using ApiFvj.Models.Base;

namespace ApiFvj.Repository
{
    interface ILoginRepository
    {
        User FindByLogin(string email, string password);
        User FindByLoginAdmin(string email, string password);
    }
}
