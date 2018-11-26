using Microsoft.Extensions.Logging;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Pipelines;

namespace Commerce.Plugin.Asset.Pipelines
{
    public class AssociateAssetToParentPipeline : CommercePipeline<CatalogReferenceArgument, CatalogContentArgument>, IAssociateAssetToParentPipeline, IPipeline<CatalogReferenceArgument, CatalogContentArgument, CommercePipelineExecutionContext>, IPipelineBlock<CatalogReferenceArgument, CatalogContentArgument, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
        public AssociateAssetToParentPipeline(IPipelineConfiguration<IAssociateAssetToParentPipeline> configuration, ILoggerFactory loggerFactory) : base(configuration, loggerFactory)
        {
        }
    }
}
