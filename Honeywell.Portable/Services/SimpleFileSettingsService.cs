using Honeywell.Portable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.Portable.Services
{
    public class SimpleFileSettingsService : ISettingsService
    {
        public SimpleFileSettingsService()
        {
            
        }

        public object Get(string key)
        {
            throw new NotImplementedException();
        }

        public bool Set(string key, object value)
        {
            throw new NotImplementedException();
        }
    }
}
