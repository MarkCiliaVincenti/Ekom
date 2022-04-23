using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekom.Core.Models
{
    /// <summary>
    /// Unfinished
    /// </summary>
    public class PaymentRequest
    {
        public Guid PaymentProvider { get; set; }

        public Guid ShippingProvider { get; set; }
        public string CustomerEmail { get; set; }
    }
}
