using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

namespace ApiFvj
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OAuthOptions);
        }
        static Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(365),
                AllowInsecureHttp = true,
                TokenEndpointPath = new Microsoft.Owin.PathString("/api/token"),
                Provider = new OAuthProvider()
            };
        }
    }
}