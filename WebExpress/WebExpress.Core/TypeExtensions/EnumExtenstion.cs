using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core.Enums;

namespace WebExpress.Core.TypeExtensions
{
    public static class EnumExtenstion
    {
        public static IEnumItem[] GetEnumItems<T>()
        {
            var items = Enum.GetValues(typeof(T));
            var result = new List<IEnumItem>();
            foreach (var item in items)
            {
                var vt = new EnumItem { Value = (int)item, Text = item.ToString() };
                result.Add(vt);
            }
            return result.ToArray();
        }
    }
}
