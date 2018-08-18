﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public async Task<T> GetAsync<T>(string path, CancellationToken token = default(CancellationToken))
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

            var response = await ParseResponse<T>(result);
            return response;
        }

        private async Task<T> ParseResponse<T>(HttpResponseMessage result)
        {
            var jsonResult = await result.Content.ReadAsStringAsync();
            object a = null;
            try
            {
                a = JsonConvert.DeserializeObject<T>(jsonResult);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return (T)a;
        }
    }
}