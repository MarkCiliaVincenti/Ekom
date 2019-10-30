using Ekom.Models.Data;
using NPoco;
using System;
using System.Collections.Generic;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Migrations;
using Umbraco.Core.Persistence;
using Umbraco.Core.Scoping;

namespace Ekom.App_Start
{
    class MigrationCreateTables : MigrationBase
    {
        readonly ILogger _logger;
        readonly Configuration _config;
        public MigrationCreateTables(
            ILogger logger,
            Configuration configuration,
            IMigrationContext context)
            : base(context)
        {
            _logger = logger;
            _config = configuration;
        }

        public override void Migrate()
        {
            if (!TableExists(TableInfo.FromPoco(typeof(StockData)).TableName))
            {
                _logger.Info<MigrationCreateTables>($"Creating {TableInfo.FromPoco(typeof(StockData)).TableName} table");

                Create.Table<StockData>().Do();
            }
            if (!TableExists(TableInfo.FromPoco(typeof(OrderActivityLog)).TableName))
            {
                _logger.Info<MigrationCreateTables>($"Creating {TableInfo.FromPoco(typeof(OrderActivityLog)).TableName} table");

                Create.Table<OrderActivityLog>().Do();
            }
            if (!TableExists(TableInfo.FromPoco(typeof(OrderData)).TableName))
            {
                _logger.Info<MigrationCreateTables>($"Creating {TableInfo.FromPoco(typeof(OrderData)).TableName} table");

                Create.Table<OrderData>().Do();
                Execute.Sql($"ALTER TABLE {TableInfo.FromPoco(typeof(OrderData)).TableName} ALTER COLUMN OrderInfo NVARCHAR(MAX)").Do();
            }
            if (!TableExists(TableInfo.FromPoco(typeof(CouponData)).TableName))
            {
                _logger.Info<MigrationCreateTables>($"Creating {TableInfo.FromPoco(typeof(CouponData)).TableName} table");

                Create.Table<CouponData>().Do();
            }
            if (!TableExists(Configuration.DiscountStockTableName))
            {
                _logger.Info<MigrationCreateTables>($"Creating {Configuration.DiscountStockTableName} table");

                Create.Table<DiscountStockData>().Do();
            }
            if (_config.StoreCustomerData
            && !TableExists(TableInfo.FromPoco(typeof(CustomerData)).TableName))
            {
                _logger.Info<MigrationCreateTables>($"Creating {TableInfo.FromPoco(typeof(CustomerData)).TableName} table");

                Create.Table<CustomerData>().Do();
            }
        }
    }

    class EkomMigrationContext : IMigrationContext
    {
        public EkomMigrationContext(IUmbracoDatabase database, ILogger logger)
        {
            Database = database;
            Logger = logger;
        }

        /// <inheritdoc />
        public ILogger Logger { get; }

        /// <inheritdoc />
        public IUmbracoDatabase Database { get; }

        /// <inheritdoc />
        public ISqlContext SqlContext => Database.SqlContext;

        /// <inheritdoc />
        public int Index { get; set; }

        /// <inheritdoc />
        public bool BuildingExpression { get; set; }

        // this is only internally exposed
        public List<Type> PostMigrations { get; } = new List<Type>();

        /// <inheritdoc />
        public void AddPostMigration<TMigration>()
            where TMigration : IMigration
        {
            // just adding - will be de-duplicated when executing
            PostMigrations.Add(typeof(TMigration));
        }
    }

    class EnsureTablesExist : IComponent
    {
        private readonly IScopeProvider scopeProvider;
        private readonly IMigrationBuilder migrationBuilder;
        private readonly ILogger logger;

        public EnsureTablesExist(
            IScopeProvider scopeProvider,
            IMigrationBuilder migrationBuilder,
            ILogger logger)
        {
            this.scopeProvider = scopeProvider;
            this.migrationBuilder = migrationBuilder;
            this.logger = logger;
        }

        public void Initialize()
        {
            logger.Debug<EnsureTablesExist>("Ensuring Ekom db tables exist");

            // perform any upgrades (as needed)

            // We hack the 'migration' execution together manually to ensure it runs on each startup
            // If we would like to use migrations at a later date we can refactor easily
            using (var scope = scopeProvider.CreateScope())
            {
                var context = new EkomMigrationContext(scope.Database, logger);
                var migration = migrationBuilder.Build(typeof(MigrationCreateTables), context);
                migration.Migrate();

                scope.Complete();
            }

            logger.Debug<EnsureTablesExist>("Done");
        }

        public void Terminate()
        {
        }
    }
}