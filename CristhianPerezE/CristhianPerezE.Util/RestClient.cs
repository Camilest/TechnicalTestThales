using CristhianPerezE.Util.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CristhianPerezE.Util
{
    public class RestClient : IRestClient
    {
        public string GetResponse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await RequestAsync(HttpMethod.Get, url).ConfigureAwait(false);
            GetResponse = response.ToString();
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (typeof(T) == typeof(string))
            {
                return GetValue<T>(content);
            }
            return JsonConvert.DeserializeObject<T>(content);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        private Task<HttpResponseMessage> RequestAsync(HttpMethod method, string url, object payload = null)
        {
            try
            {
                var request = PrepareRequest(method, url, payload);
                return GetClient().SendAsync(request, HttpCompletionOption.ResponseContentRead);
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        private HttpRequestMessage PrepareRequest(HttpMethod method, string url, object payload)
        {
            try
            {
                var uri = new Uri(url);
                var request = new HttpRequestMessage(method, uri);
                if (payload != null)
                {
                    var json = JsonConvert.SerializeObject(payload);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }
                return request;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private T GetValue<T>(string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        private HttpClient GetClient(HttpClientHandler handler = null)
        {
            var client = handler == null ? new HttpClient() : new HttpClient(handler, true);
            client.Timeout = TimeSpan.FromSeconds(360);
            return client;
        }
    }
}
