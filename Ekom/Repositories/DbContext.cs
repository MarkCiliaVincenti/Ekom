using Ekom.Core.Models;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekom.Core.Repositories
{
    public class DbContext : LinqToDB.Data.DataConnection
    {
        public DbContext() : base("umbracoDbDSN") { }

        public ITable<CouponData> CouponData => GetTable<CouponData>();
        public ITable<CustomerData> CustomerData => GetTable<CustomerData>();
        public ITable<DiscountStockData> DiscountStockData => GetTable<DiscountStockData>();
        public ITable<OrderActivityLog> OrderActivityLog => GetTable<OrderActivityLog>();
        public ITable<OrderData> OrderData => GetTable<OrderData>();
        public ITable<StockData> StockData => GetTable<StockData>();
    }
}
