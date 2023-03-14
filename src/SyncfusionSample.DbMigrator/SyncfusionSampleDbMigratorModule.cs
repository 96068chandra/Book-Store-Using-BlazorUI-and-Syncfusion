using SyncfusionSample.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SyncfusionSample.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SyncfusionSampleEntityFrameworkCoreModule),
    typeof(SyncfusionSampleApplicationContractsModule)
    )]
public class SyncfusionSampleDbMigratorModule : AbpModule
{

}
