using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekom.Core.Models
{
    public class UmbracoDomain
    {
        public UmbracoDomain()
        {
        }

        /// <summary>
        /// All node properties
        /// </summary>
        public Dictionary<string, string> Properties = new Dictionary<string, string>();
    }
}
