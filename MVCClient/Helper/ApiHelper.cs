using IdentityModel.Client;
using MyCorp.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MVCClient.Helper
{
    public class ApiHelper
    {

        //Accept: application/json
        //Authorization: Basic bXltdmNjbGllbnQ6bXltdmNjbGllbnRzZWNyZXQ=
        //Content-Type: application/x-www-form-urlencoded
        //Host: mycorpidentityserverapp.azurewebsites.net
        //Content-Length: 45
        //Expect: 100-continue

        //Request Body:
        //grant_type=client_credentials&scope=testscope

        public const string API_BASE_URI =    @"http://securedwebapidemo.azurewebsites.net";

        public void Test()
        {
            TokenClient tokenClient = new TokenClient("http://mycorpidentityserverapp.azurewebsites.net/identity/connect/token",
                Constants.MyCorpMvcAppId,Constants.MyCorpMvcAppSecret);
            var r = tokenClient.RequestClientCredentialsAsync(scope: "testscope").Result;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_BASE_URI);
            client.SetBearerToken(r.AccessToken);
            var result = client.GetAsync("/api/values").Result;
        }
    }
}