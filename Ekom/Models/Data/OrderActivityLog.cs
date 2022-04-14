using LinqToDB.Mapping;
using System;

namespace Ekom.Core.Models
{
    /// <summary>
    /// Activity log of order
    /// </summary>
    [Table(Name = "EkomOrdersActivityLog")]
    public class OrderActivityLog
    {
        [PrimaryKey]
        public Guid UniqueID { get; set; }
        [Column]
        public Guid Key { get; set; }
        [Column]
        public string Log { get; set; }
        [Column]
        public string UserName { get; set; }
        [Column]
        public DateTime Date { get; set; }

        public string OrderNumber { get; set; }
    }
}
