using System.Collections.Generic;

namespace EkomCore.Models
{
    public class Metavalue
    {
        public Metafield Field { get; set; }
        public List<Dictionary<string,string>> Values { get; set; } = new List<Dictionary<string, string>>();

    }
}
