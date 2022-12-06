using System.Collections.Generic;

namespace EkomCore.Models
{
    public class Metavalue
    {
        public Metafield Field { get; set; }
        public List<string> Values { get; set; } = new List<string>();

        public string GetValue(string culture = "")
        {
            return "";
        }

    }
}
