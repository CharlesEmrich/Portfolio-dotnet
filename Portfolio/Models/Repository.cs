using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Portfolio.Models
{
    public class Repository
    {
        public string name { get; set; }
        public string html_url { get; set; }
        public int forks { get; set; }
        public string description { get; set; }

        public static List<Repository> GetRepos()
        {
            var client = new RestClient("https://api.github.com/");

            RestRequest request = new RestRequest("users/CharlesEmrich/repos", Method.GET);
            request.AddHeader("User-Agent", EnvironmentVariables.UserAgent);
            request.AddHeader("token", EnvironmentVariables.AuthToken);
            request.AddHeader("Accept", "application/json");

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
                Debug.WriteLine(response.Content);
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var repoList = JsonConvert.DeserializeObject<List<Repository>>(jsonResponse["items"].ToString());
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

