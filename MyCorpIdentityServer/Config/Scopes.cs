using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCorpIdentityServer.Config
{
    public static class Scopes
    {
        public static List<Scope> Get()
        {
            List<Scope> scopes = new List<Scope>();
            scopes.Add(new Scope
            {
                Name="testscope",
                DisplayName = "Just to see how tings work",
                Description = "Setting up private identity server",
                Type = ScopeType.Resource
            });

            return scopes;
        }
    }
}