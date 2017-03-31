using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data
{
    public static class ObjectExtensions
    {
        /// <summary>converts from couchbase document content to an object</summary>
        public static TObj ToObject<TObj>(this IDictionary<string, object> dic)
        {
            var json = JsonConvert.SerializeObject(dic);
            var obj = JsonConvert.DeserializeObject<TObj>(json);
            return obj;
        }
        /// <summary>converts from an object to couchbase document content</summary>
        public static Dictionary<string, object> ToDictionary(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var jsonToDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            return jsonToDic;
        }
    }

}
