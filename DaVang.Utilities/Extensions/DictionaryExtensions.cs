using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.Utilities.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AppendValue<T>(this IDictionary<T, int> dictionary, T id, int value = 1)
        {
            if (dictionary.ContainsKey(id))
                dictionary[id] += value;
            else
                dictionary.Add(id, value);
        }
    }
}
