using Commerce.Plugin.Asset.Pipelines.Arguments;
using Microsoft.Extensions.Logging;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Pipelines;

namespace Commerce.Plugin.Asset.Pipelines
{
    public class CreateAssetPipeline : CommercePipeline<CreateAssetArgument, AssetContentArgument>, ICreateAssetPipeline, IPipeline<CreateAssetArgument, AssetContentArgument, CommercePipelineExecutionContext>, IPipelineBlock<CreateAssetArgument, AssetContentArgument, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
        public CreateAssetPipeline(IPipelineConfiguration<ICreateAssetPipeline> configuration, ILoggerFactory loggerFactory) : base(configuration, loggerFactory)
        {
        }
    }
}
