using Honeywell.Portable.Interfaces;
using ModernHttpClient;
using MvvmCross.Platform.Platform;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.Portable.Services
{
    public class RestService : IRestService
    {
        public async Task<T> GetDataAsync<T>(string url) where T : class
        {
            // try-catch darum bauen
            try
            {
                var client = new HttpClient(new NativeMessageHandler());
                var json = await client.GetStringAsync(url);
                if (typeof(T) == typeof(string))
                    return json as T;
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                MvxTrace.Error(ex.Message);
                return null;
            }
        }
    }
}
