using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MyCorpIdentityServer.Config
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            List<InMemoryUser> result = new List<InMemoryUser>();

            result.Add(
                        new InMemoryUser
                        {
                            Username = "Hemant",
                            Password = "password",
                            Subject = "{D0B44C95-D2C8-4B41-9534-C47EA8C66858}",//users unique identifier.               
                        }
                       );
            result.Add(new InMemoryUser
            {
                Username = "Aaroh",
                Password = "password",
                Subject = "{C24BC65E-F2D7-4AEB-81B8-1040C24B73C6}",//users unique identifier.               
            });
            return result;
        }
    }
}