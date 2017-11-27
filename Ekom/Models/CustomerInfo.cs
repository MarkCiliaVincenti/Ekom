﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekom.Models
{
    public class CustomerInfo
    {
        public string CustomerIpAddress { get; set; }
        public Customer Customer { get; set; }
        public ShippingInfo Shipping { get; set; }
    }
}
