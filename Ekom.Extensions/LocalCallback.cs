﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.NetPayment;

namespace Ekom.Extensions
{
    public class LocalCallback
    {
        /// <summary>
        /// Raises the success event on successful payment verification
        /// </summary>
        /// <param name="o"></param>
        internal static void OnSuccess(OrderStatus o)
        {
            Success?.Invoke(o);
            LocalCallbacks.OnSuccess(o);

        }

        /// <summary>
        /// Raises the success event on successful payment verification
        /// </summary>
        /// <param name="o"></param>
        /// <param name="ex"></param>
        internal static void OnError(OrderStatus o, Exception ex)
        {
            Error?.Invoke(o, ex);
            LocalCallbacks.OnError(o, ex);
        }

        /// <summary>
        /// Event fired on successful payment verification
        /// </summary>
        public static event LocalCallbacks.successCallback Success;
        /// <summary>
        /// Event fired on payment verification error
        /// </summary>
        public static event LocalCallbacks.errorCallback Error;
    }
}