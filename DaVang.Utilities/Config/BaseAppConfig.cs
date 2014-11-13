using Davang.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Utilities.Config
{
    public abstract class BaseAppConfig<TConfigKey>
    {
        private static IDictionary<TConfigKey, object> _memConfigs;
        private static string _clientId;

        static BaseAppConfig()
        {
            _memConfigs = new Dictionary<TConfigKey, object>();
        }

        public static string ClientId
        {
            get
            {
                if (string.IsNullOrEmpty(_clientId))
                {
                    _clientId = StorageHelper.LoadConfig("clientId").ToString();
                    if (string.IsNullOrEmpty(_clientId))
                    {
                        _clientId = Guid.NewGuid().ToString();
                        StorageHelper.SaveConfig("clientId", _clientId);
                    }
                }

                return _clientId;
            }
        }

        protected static T GetPersistentConfig<T>(TConfigKey key, T defaultValue)
        {
            object value = StorageHelper.LoadConfig(key.ToString());
            if (value != null)
                return (T)value;
            return defaultValue;
        }

        protected static void SetPersistentConfig<T>(TConfigKey key, T value)
        {
            StorageHelper.SaveConfig(key.ToString(), value);
        }

        protected static T GetConfig<T>(TConfigKey key, T defaultValue)
        {
            if (!_memConfigs.ContainsKey(key))
            {
                var persistentValue = GetPersistentConfig<T>(key, defaultValue);
                _memConfigs[key] = persistentValue;
            }

            return (T)_memConfigs[key];
        }

        protected static void SetConfig<T>(TConfigKey key, T value)
        {
            if (!_memConfigs.ContainsKey(key))
                _memConfigs.Add(key, value);
            else
                _memConfigs[key] = value;
            SetPersistentConfig(key, value);
        }
    }
}
