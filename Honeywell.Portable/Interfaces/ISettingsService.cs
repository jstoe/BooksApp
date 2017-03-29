using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.Portable.Interfaces
{
    public interface ISettingsService
    {
        object Get(string key);
        bool Set(string key, object value);
    }
}
