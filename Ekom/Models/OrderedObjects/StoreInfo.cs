﻿using Ekom.Interfaces;
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Ekom.Models.OrderedObjects
{
    /// <summary>
    /// Frozen representation of <see cref="IStore"/>
    /// </summary>
    public class StoreInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonConstructor]
        public StoreInfo(
            Guid key,
            string currency,
            string culture,
            string alias,
            bool vatIncludedInPrice,
            decimal vat)
        {
            Key = key;
            Currency = new CultureInfo(currency);
            Culture = culture;
            Alias = alias;
            VatIncludedInPrice = vatIncludedInPrice;
            Vat = vat;
        }

        public StoreInfo(IStore store)
        {
            if (store != null)
            {
                Key = store.Key;
                Currency = store.Currency;
                Culture = store.Culture.Name;
                Alias = store.Alias;
                VatIncludedInPrice = store.VatIncludedInPrice;
                Vat = store.Vat;
            }
        }

        public Guid Key { get; }
        public CultureInfo Currency { get; }
        public string Culture { get; }
        public string Alias { get; }
        public bool VatIncludedInPrice { get; }
        /// <summary>
        /// Stored VAT value: 0.285<para></para>
        /// Effective VAT value: 28.5%<para></para>
        /// </summary>
        public decimal Vat { get; }
    }
}
