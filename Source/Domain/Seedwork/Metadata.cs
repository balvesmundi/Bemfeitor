using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Benfeitor.Domain.Seedwork {

    public class Metadata {

        public Metadata() {
            Data = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Data { get; set; }

        public string Json {
            get {

                if (Data == null || Data.Any() == false) return null;

                return JsonConvert.SerializeObject(Data);
            }
            set {

                if (string.IsNullOrEmpty(value)) return;

                var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);

                Data = data ?? new Dictionary<string, string>();
            }
        }
    }
}
