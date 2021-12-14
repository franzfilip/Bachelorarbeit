using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EF {
    public class EnumCollectionJsonValueConverter<T> : ValueConverter<ICollection<T>, string> where T : Enum {
        public EnumCollectionJsonValueConverter() : base(
            v => JsonConvert
                .SerializeObject(v.Select(e => e.ToString()).ToList()),
            v => JsonConvert
                .DeserializeObject<ICollection<string>>(v)
                .Select(e => (T)Enum.Parse(typeof(T), e)).ToList()) {
        }
    }
}
