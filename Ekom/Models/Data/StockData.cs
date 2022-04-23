using LinqToDB.Mapping;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ekom.Models
{
    /// <summary>
    /// Current stock of a given item
    /// </summary>
    [Table(Name = "EkomStock")]
    public class StockData
    {
        /// <summary>
        /// With per store stock this id has the following format
        /// {Two letter country code}_{Guid} or:
        /// IS_d6da9d30-9246-4856-b66b-5411086b84d9
        /// In other cases this is simply a Guid
        /// </summary>
        [StringLength(39)]
        [PrimaryKey]
        public string UniqueId { get; internal set; }

        /// <summary>
        /// Unit count
        /// </summary>
        [Column]
        public int Stock { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        [Column]
        public DateTime CreateDate { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [Column]
        public DateTime UpdateDate { get; internal set; }
    }
}
