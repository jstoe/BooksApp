using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.Portable.Interfaces
{
    public interface IRestService
    {
        Task<T> GetDataAsync<T>(string url) where T:class;
    }
}
