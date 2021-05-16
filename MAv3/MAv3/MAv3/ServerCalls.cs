using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAv3
{
    public abstract class ServerCalls
    {
        protected string root;
        

        public ServerCalls()
        {

        }

        public abstract string ObjectExist(string Object, string Object2);
        public abstract string ObjectAdd(string Object, string Object2);
        public abstract string ObjectID(string Object, string Object2);

    }
    public class UserCall : ServerCalls
    {
       public UserCall()
        {
            root = "https://movingappwebapi20210511172030.azurewebsites.net/MovingApp/Users/";
        }

        public override string ObjectAdd(string Username, string Password)
        {
            string goTo = $"{root}/UserAdd/{Username}/{Password}";
            var client = new RestClient(goTo);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "ARRAffinity=a7849d6dae65d69222ffaa2af87b40c55ee92550e9f10aab92a25c888276c641; ARRAffinitySameSite=a7849d6dae65d69222ffaa2af87b40c55ee92550e9f10aab92a25c888276c641");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public override string ObjectExist(string Username, string Password = null)
        {
            string goTo;
            if (Password != null)
             goTo= $"{root}/UserExist/{Username}/{Password}";
            else goTo = $"{root}/UserExist/{Username}";
            var client = new RestClient(goTo);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "ARRAffinity=a7849d6dae65d69222ffaa2af87b40c55ee92550e9f10aab92a25c888276c641; ARRAffinitySameSite=a7849d6dae65d69222ffaa2af87b40c55ee92550e9f10aab92a25c888276c641");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public override string ObjectID(string Username, string Password)
        {
            string goTo = $"{root}/UserID/{Username}/{Password}";
            var client = new RestClient(goTo);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "ARRAffinity=a7849d6dae65d69222ffaa2af87b40c55ee92550e9f10aab92a25c888276c641; ARRAffinitySameSite=a7849d6dae65d69222ffaa2af87b40c55ee92550e9f10aab92a25c888276c641");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}
