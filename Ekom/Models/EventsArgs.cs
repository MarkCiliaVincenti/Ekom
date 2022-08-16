using Ekom.Interfaces;
using Ekom.Models;
using System;

namespace Ekom.Extensions.Models
{
    public class PayEventArgs : EventArgs
    {
        public IOrderInfo OrderInfo { get; set; }

        public PaymentSettings PaymentSettings { get; set; }
    }

    public class ProcessingEventArgs : EventArgs
    {
        public IOrderInfo OrderInfo { get; set; }
    }
}
