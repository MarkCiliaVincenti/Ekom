using LinqToDB.Mapping;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ekom.Models
{
    /// <summary>
    /// SQL Representation of <see cref="OrderInfo"/>
    /// </summary>
    [Table(Name = "EkomOrders")]
    public class OrderData : ICloneable
    {
        /// <summary>
        /// Primary means of identifying orders
        /// 
        /// Install creates as Unique clustered which is not supported by
        /// umbraco database annotation attributes
        /// </summary>
        [Column]
        public Guid UniqueId { get; set; }

        /// <summary>
        /// Required by some payment providers and bookkeeping software
        /// </summary>
        [PrimaryKey, Identity]
        public int ReferenceId { get; set; }

        /// <summary>
        /// <see cref="Models.OrderInfo"/> Json
        /// </summary>
        [StringLength(int.MaxValue, MinimumLength = 3)]
        [Column]
        public string OrderInfo { get; set; }

        [StringLength(100)]
        [Column]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The database representation of the enum.
        /// This is necessary for the creation of the column.
        /// </summary>
        [Column]
        public int OrderStatusCol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public OrderStatus OrderStatus
        {
            get { return (OrderStatus)OrderStatusCol; }
            set { OrderStatusCol = (int)value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(200)]
        [Column]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(200)]
        [Column]
        public string CustomerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column]
        public int CustomerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(200)]
        [Column]
        public string CustomerUsername { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(50)]
        [Column]
        public string ShippingCountry { get; set; }

        /// <summary>
        /// 
        /// </summary>
        // [Length(9)] // decimal (9,9) https://stackoverflow.com/questions/19811180/best-data-annotation-for-a-decimal18-2
        [Column]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Contains the culture (e: "is-IS" or "is")
        /// </summary>
        [StringLength(5)]
        [Column]
        public string Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(50)]
        [Column]
        public string StoreAlias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Last update date
        /// </summary>
        [Column]
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// <see cref="DateTime"/> payment was verified.
        /// </summary>
        [Column]
        public DateTime? PaidDate { get; set; }

        /// <summary>
        /// Creates a shallow copy of the current Object.
        /// </summary>
        /// <returns></returns>
        public object Clone() => MemberwiseClone();
    }
}
