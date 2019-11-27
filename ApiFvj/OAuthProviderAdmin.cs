using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiFvj.Business;
using ApiFvj.Business.Implamentation;
using Microsoft.Owin.Security.OAuth;

namespace ApiFvj
{
    public class OAuthProviderAdmin : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                string userName = context.UserName;
                string pass = context.Password;

                ILoginBusiness user = new LoginBusinessImpl();
                var result = user.FindByLoginAdmin(userName,pass);

                if (result != null)
                {
                    List<Claim> claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, result.Name),
                        new Claim("UserAdminId", result.Id.ToString())
                    };
                    ClaimsIdentity OAuthIdentity = new ClaimsIdentity(claim, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new Microsoft.Owin.Security.AuthenticationTicket(OAuthIdentity, new Microsoft.Owin.Security.AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("Error", "Error, user Not Found");
                }
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}