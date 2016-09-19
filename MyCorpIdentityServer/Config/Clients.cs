using IdentityServer3.Core.Models;
using MyCorp.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCorpIdentityServer.Config
{
    public static class Clients
    {
        public static List<Client> Get()
        {
            List<Client> clients = new List<Client>();
            Client clientMvc = new Client
            {
                ClientId = Constants.MyCorpMvcAppId,
                ClientName = "My MVC client",
                Flow = Flows.ClientCredentials,
                ClientSecrets = new List<Secret>
                {
                    new Secret(Constants.MyCorpMvcAppSecret.Sha256())//sha256
                },
                AllowAccessToAllScopes = true
                //AllowedScopes = new List<string> { "testscope" }
            };
            clients.Add(clientMvc);



            Client clientMvcAuthorizationCode = new Client
            {
                ClientId = "mymvcclient_authrorization_code",
                ClientName = "MVC (Authorization Code Flow)",
                Flow = Flows.AuthorizationCode,
                AllowAccessToAllScopes = true,
                RedirectUris = new List<string>
                {
                    "http://mvcclientdemo.azurewebsites.net/home/callback"
                },
                ClientSecrets = new List<Secret>
                {
                    new Secret(Constants.MyCorpMvcAppSecret.Sha256())
                },
                AllowedScopes = new List<string>
                {
                    "testscope"
                }
            };

            clients.Add(clientMvcAuthorizationCode);

            return clients;
        }
    }
}