using System.Collections.Generic;
using System.Globalization;

namespace Ekom.Core.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStore : INodeEntity
    {
        /// <summary>
        /// Umbraco input: 28.5 <para></para>
        /// Stored VAT value: 0.285<para></para>
        /// Effective VAT value: 28.5%<para></para>
        /// </summary>
        decimal Vat { get; }

        /// <summary>
        /// Gets the culture.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        CultureInfo Culture { get; }
        CurrencyModel Currency { get; }

        CurrencyModel GetCurrentCurrency();

        List<CurrencyModel> Currencies { get; }
        string Alias { get; }
        IEnumerable<UmbracoDomain> Domains { get; }
        string OrderNumberPrefix { get; }
        string OrderNumberTemplate { get; }
        int StoreRootNode { get; }
        string Url { get; }
        bool VatIncludedInPrice { get; }
    }
}
