using System;

namespace Ekom.Core.Models
{
    public class OrderUpdatedEventArgs : EventArgs
    {
        public IOrderInfo OrderInfo { get; set; }
    }
}
