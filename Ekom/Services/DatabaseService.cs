using Ekom.Models;
using LinqToDB;
using LinqToDB.SchemaProvider;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ekom.Services
{
    internal class DatabaseService
    {
        readonly DatabaseFactory _databaseFactory;
        public DatabaseService(DatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        internal virtual void CreateTables()
        {

            using (var db = _databaseFactory.GetDatabase())
            {
                var sp = db.DataProvider.GetSchemaProvider();

                var dbSchema = sp.GetSchema(db);

                if (!dbSchema.Tables.Any(x => x.TableName == "EkomStock"))
                {
                    db.CreateTable<StockData>();
                }
            }

            //if (!TableExists(TableInfo.FromPoco(typeof(StockData)).TableName))
            //{
            //    _logger.Info<MigrationCreateTables>(
            //        "Creating {TableName} table",
            //        TableInfo.FromPoco(typeof(StockData)).TableName);

            //    Create.Table<StockData>().Do();
            //}
            //if (!TableExists(TableInfo.FromPoco(typeof(OrderActivityLog)).TableName))
            //{
            //    _logger.Info<MigrationCreateTables>(
            //        "Creating {TableName} table",
            //        TableInfo.FromPoco(typeof(OrderActivityLog)).TableName);

            //    Create.Table<OrderActivityLog>().Do();
            //}
            //if (!TableExists(TableInfo.FromPoco(typeof(OrderData)).TableName))
            //{
            //    _logger.Info<MigrationCreateTables>(
            //        "Creating {TableName} table",
            //        TableInfo.FromPoco(typeof(OrderData)).TableName);

            //    Create.Table<OrderData>().Do();
            //    Execute.Sql($"ALTER TABLE {TableInfo.FromPoco(typeof(OrderData)).TableName} ALTER COLUMN OrderInfo NVARCHAR(MAX)").Do();
            //    Execute.Sql($"CREATE CLUSTERED INDEX [{EkomMigrationPlan.OrderDataUniqueIndex}] ON {TableInfo.FromPoco(typeof(OrderData)).TableName} ( [UniqueId] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]").Do();
            //}
            //if (!TableExists(TableInfo.FromPoco(typeof(CouponData)).TableName))
            //{
            //    _logger.Info<MigrationCreateTables>(
            //        "Creating {TableName} table",
            //        TableInfo.FromPoco(typeof(CouponData)).TableName);

            //    Create.Table<CouponData>().Do();
            //}
            //if (!TableExists(Configuration.DiscountStockTableName))
            //{
            //    _logger.Info<MigrationCreateTables>(
            //        "Creating {TableName} table",
            //        Configuration.DiscountStockTableName);

            //    Create.Table<DiscountStockData>().Do();
            //}
            //if (_config.StoreCustomerData
            //&& !TableExists(TableInfo.FromPoco(typeof(CustomerData)).TableName))
            //{
            //    _logger.Info<MigrationCreateTables>(
            //        "Creating {TableName} table",
            //        TableInfo.FromPoco(typeof(CustomerData)).TableName);

            //    Create.Table<CustomerData>().Do();
            //}
        }
    }
}
