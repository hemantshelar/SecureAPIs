using IdentityServer3.Core.Configuration;
using MyCorp.Framework;
using MyCorpIdentityServer.Config;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace MyCorpIdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", appBuilder =>
            {
                IdentityServerServiceFactory factory = new IdentityServerServiceFactory()
                .UseInMemoryClients(Clients.Get())
                .UseInMemoryScopes(Scopes.Get())
                .UseInMemoryUsers(Users.Get());

                IdentityServerOptions options = new IdentityServerOptions
                {
                    Factory = factory,
                    SiteName = "MyCorp Identity Server",
                    RequireSsl = false,
                    SigningCertificate = GetSigningCertificate(), //This is mandatory
                    IssuerUri = Constants.IssuireURI,
                    PublicOrigin = Constants.STSPublicOrigin,
                    EnableWelcomePage = true,
                    LoggingOptions = new LoggingOptions
                    {
                        EnableHttpLogging = true
                    }
                };

                appBuilder.UseIdentityServer(options);
            });
        }

        public X509Certificate2 GetSigningCertificate()
        {
            X509Certificate2 cert = null;
            try
            {
                //string path = Assembly.GetExecutingAssembly().CodeBase;
                string path = AppDomain.CurrentDomain.BaseDirectory;
                path = Path.Combine(path, @"SigningCertificate\idsrv3test.pfx");

                cert = new X509Certificate2(path, "idsrv3test");
            }
            catch (Exception ex)
            {
                throw;
            }
            return cert;
        }
    }
}