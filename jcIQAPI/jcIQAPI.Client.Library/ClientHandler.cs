using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using jcIQAPI.Universal.Library.Transports;
using Newtonsoft.Json;

namespace jcIQAPI.Client.Library {
    public class ClientHandler {
        private readonly string _webAPI;
        private readonly string _controllerName;

        public ClientHandler(string webAPIBaseAddress, string controllerName = "Query") {
            _webAPI = webAPIBaseAddress;
            _controllerName = controllerName;
        }

        private HttpClient HC {
            get {
                var handler = new HttpClientHandler();

                var client = new HttpClient(handler) { Timeout = TimeSpan.FromMinutes(1) };
                
                return client;
            }
        }

        public async Task<T> GET<T>(string urlArguments) {
            var str = await HC.GetStringAsync($"{_webAPI}{_controllerName}{parseUrlArguments(urlArguments)}");

            return JsonConvert.DeserializeObject<T>(str);
        }

        private string parseUrlArguments(string urlArguments) {
            return string.IsNullOrEmpty(urlArguments) ? "" : $"?{urlArguments}";
        }

        public async Task<List<QueryResponseItem>> GetQueryResults(string query) {
            return await GET<List<QueryResponseItem>>($"query={query}");
        }
    }
}