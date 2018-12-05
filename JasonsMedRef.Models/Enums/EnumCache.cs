using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Collections;

namespace JasonsMedRef.Models.Enums
{
    public class EnumCache
    {
        private Dictionary<Type, Dictionary<string, int>> _dict;

        private static readonly Lazy<EnumCache> lazy =
            new Lazy<EnumCache>(() => new EnumCache());

        public static EnumCache Instance { get { return lazy.Value; } }

        private EnumCache()
        {
            _dict = new Dictionary<Type, Dictionary<string, int>>();
            Initialize();
        }

        private void Initialize()
        {
            Assembly a = Assembly.GetAssembly(this.GetType());
            var enums = a.GetTypes().Where( x=> x.IsEnum );

            foreach (var type in enums)
            {
                if (!_dict.ContainsKey(type))
                {
                    _dict[type] = new Dictionary<string, int>();
                }

                foreach (var field in type.GetFields())
                {
                    if (field.Name == "value__")
                        continue;

                    var attribute = Attribute.GetCustomAttribute(field,
                        typeof(EnumImportValueAttribute)) as EnumImportValueAttribute;
                    if (attribute != null)
                    {
                        foreach (string name in attribute.Names)
                        {
                            if (!_dict[type].ContainsKey(name.ToLowerInvariant()))
                                _dict[type].Add(name.ToLowerInvariant(), (int) field.GetValue(null));
                        }
                    }

                    if (!_dict[type].ContainsKey(field.Name.ToLowerInvariant()))
                        _dict[type].Add(field.Name.ToLowerInvariant(), (int)field.GetValue(null));
                }
            }
        }

        public int? GetNullableValue(Type t, string name)
        {
            if (!_dict.ContainsKey(t))
                return null;
            
            if(!_dict[t].ContainsKey(name.ToLowerInvariant()))
                return null;

            return _dict[t][name.ToLowerInvariant()];
        }
    }

}
