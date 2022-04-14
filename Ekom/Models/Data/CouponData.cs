using LinqToDB.Mapping;
using System;

namespace Ekom.Core.Models
{
    /// <summary>
    /// Current stock of a given item
    /// </summary>
    [Table(Name = "EkomCoupon")]
    public class CouponData
    {
        /// <summary>
        /// Identity column in the database primary key
        /// </summary>
        [PrimaryKey, Identity]
        public int Id { get; set; }
        /// <summary>
        /// String that is distrubuted as the coupon
        /// </summary>
        [Column]
        public string CouponCode { get; set; }
        /// <summary>
        /// How many times the coupon can be used
        /// </summary>
        [Column]
        public int NumberAvailable { get; set; }
        /// <summary>
        /// Unique identifier for the Key that can be exposed
        /// </summary>
        [Column]
        public Guid CouponKey { get; set; }
        /// <summary>
        /// The node Key for the discount 
        /// </summary>
        [Column]
        public Guid DiscountId { get; set; }
    }
}
