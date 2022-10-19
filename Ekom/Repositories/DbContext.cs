using Ekom.Models;
using LinqToDB;

namespace Ekom.Repositories
{
    public class DbContext : LinqToDB.Data.DataConnection
    {
        public DbContext(string connectionString) : base(LinqToDB.ProviderName.SqlServer, connectionString) { }

        public ITable<CouponData> CouponData => GetTable<CouponData>();
        public ITable<CustomerData> CustomerData => GetTable<CustomerData>();
        public ITable<DiscountStockData> DiscountStockData => GetTable<DiscountStockData>();
        public ITable<OrderActivityLog> OrderActivityLog => GetTable<OrderActivityLog>();
        public ITable<OrderData> OrderData => GetTable<OrderData>();
        public ITable<StockData> StockData => GetTable<StockData>();
    }
}
