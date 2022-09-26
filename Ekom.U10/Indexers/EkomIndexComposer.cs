using Ekom.U10.Indexers;
using Umbraco.Cms.Core;
using Examine;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Infrastructure.Examine;

public class EkomIndexComposer: IComposer
{
    public void Compose(IUmbracoBuilder composition)
    {
        composition.Components().Append<EkomIndexComponent>();
        composition.RegisterUnique<EkomIndexCreator>();
        composition.Services.AddExamineLuceneIndex<ProductIndex, ConfigurationEnabledDirectoryFactory>("ProductIndex");
        composition.Services.ConfigureOptions<ConfigureCustomIndexOptions>();
        composition.Services.AddSingleton<ProductIndexValueSetBuilder>();
        composition.Services.AddSingleton<ProductIndexPopulator>();
    }
}
