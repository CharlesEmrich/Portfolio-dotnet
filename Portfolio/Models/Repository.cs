using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Portfolio.Models
{
    public class Repository
    {
        public static List<Repository> GetRepos()
        {
            var client = new RestClient("https://api.github.com/?access_token=" + EnvironmentVariables.AuthToken);
            var request = new RestRequest("user/CharlesEmrich/repos", Method.GET);
            // client.Authenticator = new HttpBasicAuthenticator("{{Account SID}}", "{{Auth Token}}");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var repoList = JsonConvert.DeserializeObject<List<Repository>>(jsonResponse["messages"].ToString());
            return repoList;
        }
        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}

