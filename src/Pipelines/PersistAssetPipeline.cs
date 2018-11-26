using Microsoft.Extensions.Logging;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Pipelines;

namespace Commerce.Plugin.Asset.Pipelines
{
    public class PersistAssetPipeline : CommercePipeline<Entities.Asset>, IPersistAssetPipeline, IPipeline<Entities.Asset, Entities.Asset, CommercePipelineExecutionContext>, IPipelineBlock<Entities.Asset, Entities.Asset, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
        public PersistAssetPipeline(IPipelineConfiguration configuration, ILoggerFactory loggerFactory) : base(configuration, loggerFactory)
        {
        }
    }
}
