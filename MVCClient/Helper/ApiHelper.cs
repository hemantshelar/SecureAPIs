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


        //IF AuthenticationStyle.PostValues then

        //POST http://mycorpidentityserverapp.azurewebsites.net/identity/connect/token    HTTP/1.1

        //Accept: application/json
        //Host: mycorpidentityserverapp.azurewebsites.net
        //Content-Length: 101

        //grant_type=client_credentials&scope=testscope&client_id=mymvcclient&client_secret=mymvcclientsecret


        public const string API_BASE_URI =    @"http://securedwebapidemo.azurewebsites.net";

        public HttpClient GetHtttpClientClientCredentialFlow()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API_BASE_URI);

            if (HttpContext.Current.Request.Cookies["auth"] == null)
            {
                TokenClient tokenClient = new TokenClient("http://mycorpidentityserverapp.azurewebsites.net/identity/connect/token",
                Constants.MyCorpMvcAppId, Constants.MyCorpMvcAppSecret);
                tokenClient.AuthenticationStyle = AuthenticationStyle.PostValues;
                var r = tokenClient.RequestClientCredentialsAsync(scope: "testscope").Result;
                
                HttpContext.Current.Response.Cookies["auth"]["accessToken"] = r.AccessToken;
                
            }
            string strAccessToken = HttpContext.Current.Request.Cookies["auth"]["accessToken"] as string;
            client.SetBearerToken(strAccessToken);
            return client;
        }

        public void TestWithClientCredentials()
        {
            //TokenClient tokenClient = new TokenClient("http://mycorpidentityserverapp.azurewebsites.net/identity/connect/token",
            //    Constants.MyCorpMvcAppId,Constants.MyCorpMvcAppSecret);
            //var r = tokenClient.RequestClientCredentialsAsync(scope: "testscope").Result;


            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(API_BASE_URI);
            //client.SetBearerToken(r.AccessToken);

            HttpClient client = GetHtttpClientClientCredentialFlow();
            var result = client.GetAsync("/api/values").Result;
        }


        public HttpClient GetClientAuthorizationCodeFlow()
        {
            HttpClient client = new HttpClient();

            if (HttpContext.Current.Request.Cookies["AuthAuthorizationCode"] == null)
            {
                //Trigger Authorization Code flow here.

                AuthorizeRequest authorizeRequest = new AuthorizeRequest("https://mycorpidentityserverapp.azurewebsites.net/identity/connect/authorize");
                var state = "https://mvcclientdemo.azurewebsites.net/Home/Index";
                var url = authorizeRequest.CreateAuthorizeUrl("mymvcclient_authrorization_code", "code", "testscope", "http://mvcclientdemo.azurewebsites.net/home/callback", state);
                HttpContext.Current.Response.Redirect(url);

                var r = HttpContext.Current.Request.Path;
            }

            return client;
        }

        public void TestWithAuthorizationCode()
        {
            //Request access token authorization code.
            HttpClient client = GetClientAuthorizationCodeFlow();

          
        }
    }
}