using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Plugin.Asset.Pipelines
{
    [PipelineDisplayName("Assets.pipeline.associateassettoparent")]
    public interface IAssociateAssetToParentPipeline : IPipeline<CatalogReferenceArgument, CatalogContentArgument, CommercePipelineExecutionContext>, IPipelineBlock<CatalogReferenceArgument, CatalogContentArgument, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
    }
}
