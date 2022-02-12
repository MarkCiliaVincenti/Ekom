using NPoco;
using System;

namespace Ekom.Core.Models
{
    /// <summary>
    /// Current stock of a given item
    /// </summary>
    [TableName("EkomCoupon")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class CouponData
    {
        /// <summary>
        /// Identity column in the database primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// String that is distrubuted as the coupon
        /// </summary>
        public string CouponCode { get; set; }
        /// <summary>
        /// How many times the coupon can be used
        /// </summary>
        public int NumberAvailable { get; set; }
        /// <summary>
        /// Unique identifier for the Key that can be exposed
        /// </summary>
        public Guid CouponKey { get; set; }
        /// <summary>
        /// The node Key for the discount 
        /// </summary>
        public Guid DiscountId { get; set; }
    }
}
