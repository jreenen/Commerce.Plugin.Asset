using Sitecore.Commerce.Core;
using Sitecore.Framework.Pipelines;

namespace Commerce.Plugin.Asset.Pipelines
{
    [PipelineDisplayName("Assets.pipeline.persistasset")]
    public interface IPersistAssetPipeline : IPipeline<Entities.Asset, Entities.Asset, CommercePipelineExecutionContext>, IPipelineBlock<Entities.Asset, Entities.Asset, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
    }
}
