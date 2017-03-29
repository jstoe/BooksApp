using Honeywell.Portable.Interfaces;
using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.File;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Honeywell.Portable.Services
{
    public class SimpleFileSettingsService : ISettingsService
    {
        private IPlatformInfo m_PlatformInfo;
        private IMvxFileStore m_FileStore;
        const string m_FileName = "settings.json";
        Dictionary<string, string> m_Data;

        public SimpleFileSettingsService(IMvxFileStore fileStore, IPlatformInfo platformInfo)
        {
            m_FileStore = fileStore;
            m_PlatformInfo = platformInfo;
            Load();
        }

        private void Load()
        {
            string fileContent;
            if (m_FileStore.TryReadTextFile(Path.Combine(m_PlatformInfo.BaseDirectory, m_FileName), out fileContent))
            {
                m_Data = JsonConvert.DeserializeObject<Dictionary<string, string>>(fileContent);
            }
            else
                m_Data = new Dictionary<string, string>();
        }

        private void Save()
        {
            try
            {
                string fileContent = JsonConvert.SerializeObject(m_Data);
                m_FileStore.WriteFile(Path.Combine(m_PlatformInfo.BaseDirectory, m_FileName), fileContent);
            }
            catch (Exception ex)
            {
                MvxTrace.Error(ex.StackTrace);
            }
        }

        public T Get<T>(string key) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(m_Data[key]);
            }
            catch (Exception ex)
            {
                MvxTrace.Error(ex.StackTrace);
                return null;
            }
        }

        public bool Set(string key, object value)
        {
            m_Data[key] = JsonConvert.SerializeObject(value);
            Save();
            return true;
        }
    }
}
