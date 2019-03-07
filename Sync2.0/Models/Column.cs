using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Models
{
    public class Column
    {
        public Column(string name, Type dataType)
        {
            Name = name;
            DataType = dataType;
        }

        public string Name { get; set; }
        [JsonIgnore]
        public Type DataType { get; set; }

        [JsonProperty(PropertyName = "DataType")]
        private string DataTypeString => DataType.FullName;
    }
}
