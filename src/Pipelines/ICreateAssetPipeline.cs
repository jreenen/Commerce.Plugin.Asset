using Commerce.Plugin.Asset.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Pipelines;

namespace Commerce.Plugin.Asset.Pipelines
{
    [PipelineDisplayName("Assets.pipeline.createasset")]
    public interface ICreateAssetPipeline : IPipeline<CreateAssetArgument, AssetContentArgument, CommercePipelineExecutionContext>, IPipelineBlock<CreateAssetArgument, AssetContentArgument, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
    }
}
