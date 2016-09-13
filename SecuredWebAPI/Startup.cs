using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using IdentityServer3.AccessTokenValidation;
using MyCorp.Framework;

[assembly: OwinStartup(typeof(SecuredWebAPI.Startup))]

namespace SecuredWebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = Constants.MyCorpSTS,
                RequiredScopes = new List<string>() { "testscope" }
            });
            ConfigureAuth(app);
        }
    }
}
