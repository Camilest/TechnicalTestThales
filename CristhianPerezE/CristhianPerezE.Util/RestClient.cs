using CristhianPerezE.Util.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CristhianPerezE.Util
{
    public class RestClient
    {
        public string GetResponse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetApiData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                string contentType = "application/json";
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                var userAgent = "d-fens HttpClient";
                httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
                var response = httpClient.GetStringAsync(new Uri(url)).Result;
                return response;
            }
        }
    }
}
