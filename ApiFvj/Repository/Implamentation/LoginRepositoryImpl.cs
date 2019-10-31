using ApiFvj.Models.Base;
using System.Linq;

namespace ApiFvj.Repository.Implamentation
{
    public class LoginRepositoryImpl : ILoginRepository
    {
        private StringConnection _context = new StringConnection();

        public User FindByLogin(string email, string password)
        {
            return _context.Users.Where(x => x.Email == email && x.Password == password && x.Active != 0).FirstOrDefault();
        }

    }
}