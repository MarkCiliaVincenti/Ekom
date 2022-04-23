using LinqToDB.Mapping;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ekom.Models
{
    /// <summary>
    /// Current stock of a given item
    /// </summary>
    [Table(Name = Configuration.DiscountStockTableName)]
    public class DiscountStockData
    {
        /// <summary>
        /// Composed from discount <see cref="Guid"/> and coupon name if present.
        /// <para />
        /// $"{uniqueId}_{coupon}" or:
        /// d6da9d30-9246-4856-b66b-5411086b84d9_supercoupon
        /// <para />
        /// In other cases this is simply a Guid
        /// </summary>
        [StringLength(137)]
        [PrimaryKey]
        public string UniqueId { get; set; }

        /// <summary>
        /// Unit count
        /// </summary>
        [Column]
        public int Stock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        public DateTime UpdateDate { get; set; }
    }
}
