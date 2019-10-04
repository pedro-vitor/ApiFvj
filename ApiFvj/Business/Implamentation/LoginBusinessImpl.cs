using ApiFvj.Models.Base;
using ApiFvj.Repository;
using ApiFvj.Repository.Implamentation;

namespace ApiFvj.Business.Implamentation
{
    public class LoginBusinessImpl : ILoginBusiness
    {
        private ILoginRepository _repository;

        public LoginBusinessImpl()
        {
            _repository = new LoginRepositoryImpl();
        }

        public User FindByLogin(string email, string password)
        {
            return _repository.FindByLogin(email,password);
        }
    }
}