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
                    new Secret(Constants.MyCorpMvcAppSecret)
                },
                AllowedScopes = new List<string> { "testscope" }
            };

            return clients;
        }
    }
}