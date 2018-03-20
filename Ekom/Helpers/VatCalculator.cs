﻿using System;

namespace Ekom.Helpers
{
    static class VatCalculator
    {
        /// <summary>
        /// Removes VAT from amount.
        /// </summary>
        /// <param name="withVatVal">The with vat.</param>
        /// <param name="vatVal">The vat.</param>
        /// <returns></returns>
        public static decimal WithoutVat(decimal withVatVal, decimal vatVal)
        {
            return PerformRounding(withVatVal / (1 + vatVal));
        }

        /// <summary>
        /// Returns the amount with VAT included.
        /// </summary>
        /// <returns></returns>
        public static decimal WithVat(decimal withoutVatVal, decimal vatVal)
        {
            return PerformRounding(withoutVatVal * (1 + vatVal));
        }

        /// <summary>
        /// Calculates the VAT amount that would be added if VAT would be applied.
        /// </summary>
        /// <returns></returns>
        public static decimal VatAmountFromWithoutVat(decimal withoutVatVal, decimal vatVal)
        {
            return WithVat(withoutVatVal, vatVal) - withoutVatVal;
        }

        /// <summary>
        /// Calculates the VAT amount included in a price including VAT already.
        /// </summary>
        /// <returns></returns>
        public static decimal VatAmountFromWithVat(decimal withoutVatVal, decimal vatVal)
        {
            return withoutVatVal - WithoutVat(withoutVatVal, vatVal);
        }

        private static decimal PerformRounding(decimal val)
        {
            switch (Configuration.Current.VatCalculationRounding)
            {
                case Rounding.None:
                    return val;

                case Rounding.RoundDown:
                    return Math.Floor(val);

                case Rounding.RoundUp:
                    return Math.Ceiling(val);

                case Rounding.RoundToEven:
                    return Math.Round(val, MidpointRounding.ToEven);

                case Rounding.AwayFromZero:
                    return Math.Round(val, MidpointRounding.AwayFromZero);

                default:
                    // impossible
                    throw new Exception("Unknown rounding specified");
            }
        }
    }
}
