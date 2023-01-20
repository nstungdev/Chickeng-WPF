using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.Domain.Helpers
{
    public static class Normalizer
    {
        public static T NormalizeForm<T>(this T form) where T : class, new()
        {
            var type = form.GetType();
            var dest = new T();
            var props = type.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                .Where(e => e.PropertyType == typeof(string));
            foreach (var p in props)
            {
                string? value = p.GetValue(form)?.ToString();
                value = value?.Trim();
                value = string.IsNullOrEmpty(value) ? null : value;
                p.SetValue(dest, value);
            }
            return dest;
        }
    }
}
