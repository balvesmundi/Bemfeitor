using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Subscriber.Infrastructure.Data.Seedwork {

    public static class DataReaderExtensions {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetValue<T>(this IDataReader reader, string name) {

            var ordinal = reader.GetOrdinal(name);

            if (reader.IsDBNull(ordinal)) return default(T);

            var value = reader.GetValue(ordinal);
            var type = typeof(T);

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                type = Nullable.GetUnderlyingType(type);
            }

            return (T)Convert.ChangeType(value, type);
        }
    }
}
