using Ekom.Models;
using Microsoft.Extensions.Logging;
using NPoco;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;
using Umbraco.Cms.Infrastructure.Scoping;

namespace Ekom.App_Start
{
    class MigrationCreateTables : MigrationBase
    {

        readonly ILogger _logger;
        readonly Configuration _config;
        public MigrationCreateTables(
            ILogger<MigrationCreateTables> logger,
            Configuration configuration,
            IMigrationContext context)
            : base(context)
        {
            _logger = logger;
            _config = configuration;
        }

        protected override void Migrate()
        {
            if (!TableExists(TableInfo.FromPoco(typeof(StockData)).TableName))
            {
                _logger.LogInformation(
                    "Creating {TableName} table",
                    TableInfo.FromPoco(typeof(StockData)).TableName);

                Create.Table<StockData>().Do();
            }
            if (!TableExists(TableInfo.FromPoco(typeof(OrderActivityLog)).TableName))
            {
                _logger.LogInformation(
                    "Creating {TableName} table",
                    TableInfo.FromPoco(typeof(OrderActivityLog)).TableName);

                Create.Table<OrderActivityLog>().Do();
            }
            if (!TableExists(TableInfo.FromPoco(typeof(OrderData)).TableName))
            {
                _logger.LogInformation(
                    "Creating {TableName} table",
                    TableInfo.FromPoco(typeof(OrderData)).TableName);

                Create.Table<OrderData>().Do();
                Execute.Sql($"ALTER TABLE {TableInfo.FromPoco(typeof(OrderData)).TableName} ALTER COLUMN OrderInfo NVARCHAR(MAX)").Do();
                Execute.Sql($"CREATE UNIQUE CLUSTERED INDEX [{EkomMigrationPlan.OrderDataUniqueIndex}] ON {TableInfo.FromPoco(typeof(OrderData)).TableName} ( [UniqueId] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]").Do();
            }
            if (!TableExists(TableInfo.FromPoco(typeof(CouponData)).TableName))
            {
                _logger.LogInformation(
                    "Creating {TableName} table",
                    TableInfo.FromPoco(typeof(CouponData)).TableName);

                Create.Table<CouponData>().Do();
            }
            if (!TableExists(Configuration.DiscountStockTableName))
            {
                _logger.LogInformation(
                    "Creating {TableName} table",
                    Configuration.DiscountStockTableName);

                Create.Table<DiscountStockData>().Do();
            }
            if (_config.StoreCustomerData
            && !TableExists(TableInfo.FromPoco(typeof(CustomerData)).TableName))
            {
                _logger.LogInformation(
                    "Creating {TableName} table",
                    TableInfo.FromPoco(typeof(CustomerData)).TableName);

                Create.Table<CustomerData>().Do();
            }
        }
    }


    class EkomMigrationPlan : MigrationPlan
    {
        public const string OrderDataUniqueIndex = "IX_EkomOrders_UniqueId";

        public EkomMigrationPlan()
            : base("Ekom")
        {
            From(string.Empty)
                .To<MigrationCreateTables>("1")
                //.To<MigrationUpdatev2>("2")
                ;
        }
    }

    class EnsureTablesExist : IComponent
    {
        private readonly IScopeProvider scopeProvider;
        private readonly IMigrationPlanExecutor _migrationPlanExecutor;
        private readonly IKeyValueService keyValueService;
        private readonly ILogger logger;

        public EnsureTablesExist(
            IScopeProvider scopeProvider,
            IKeyValueService keyValueService,
            ILogger<EnsureTablesExist> logger,
            IMigrationPlanExecutor migrationPlanExecutor)
        {
            this.scopeProvider = scopeProvider;
            this.keyValueService = keyValueService;
            this.logger = logger;
            _migrationPlanExecutor = migrationPlanExecutor;
        }

        public void Initialize()
        {
            logger.LogDebug("Ensuring Ekom db tables exist");

            // perform any upgrades (as needed)
            var upgrader = new Upgrader(new EkomMigrationPlan());
            upgrader.Execute(_migrationPlanExecutor, scopeProvider, keyValueService);

            logger.LogDebug("Done");
        }

        public void Terminate() { }
    }
}
