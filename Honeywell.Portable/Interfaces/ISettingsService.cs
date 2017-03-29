using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.Portable.Interfaces
{
    public interface ISettingsService
    {
        T Get<T>(string key) where T : class;
        bool Set(string key, object value);
    }
}
