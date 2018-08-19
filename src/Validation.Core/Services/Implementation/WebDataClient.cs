using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Validation.Core.Models;

namespace Validation.Core.Services.Implementation
{
    public class WebDataClient : IDataClient
    {
        private const string ApiBaseUrl = "https://restcountries.eu/rest/v2";

        private readonly HttpClient _client;

        public WebDataClient()
        {
            _client = new HttpClient();
        }

        public async Task<List<Countries>> GetAsync(string path, CancellationToken token = default(CancellationToken))
        {
            var uriBuilder = new UriBuilder(ApiBaseUrl);
            uriBuilder.Path += path;
            HttpResponseMessage result = null;
            try
            {
                result = _client.GetAsync(uriBuilder.Uri, token).Result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            var response = await ParseResponse<List<Countries>>(result);
            return response;
        }

        private async Task<List<Countries>> ParseResponse<T>(HttpResponseMessage result)
        {
            var jsonResult = await result.Content.ReadAsStringAsync();
            var countries = JsonConvert.DeserializeObject<T>(jsonResult);
            List<Countries> countriesList = new List<Countries>();
            foreach (var country in (IEnumerable) countries)
            {
                countriesList.Add((Countries)country);
            }
            return countriesList;
        }
    }
}