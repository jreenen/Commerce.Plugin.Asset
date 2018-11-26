using Commerce.Plugin.Asset.Pipelines;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Core.Commands;
using Sitecore.Commerce.Plugin.Catalog;
using System;
using System.Threading.Tasks;

namespace Commerce.Plugin.Asset.Commands
{
    public class AssociateAssetToParentCommand : CommerceCommand
    {
        private readonly IAssociateAssetToParentPipeline _associateAssetToParentPipeline;

        public AssociateAssetToParentCommand(IAssociateAssetToParentPipeline associateAssetToParentPipeline, IServiceProvider serviceProvider)
          : base(serviceProvider)
        {
            this._associateAssetToParentPipeline = associateAssetToParentPipeline;
        }

        public async Task<CatalogContentArgument> Process(CommerceContext commerceContext, string catalogId, string parentId, string assetId)
        {
            CatalogContentArgument result = null;

            using (CommandActivity.Start(commerceContext, this))
            {
                await this.PerformTransaction(commerceContext, async () =>
                {
                    CommercePipelineExecutionContextOptions pipelineContextOptions = commerceContext.GetPipelineContextOptions();
                    result = await this._associateAssetToParentPipeline.Run(new CatalogReferenceArgument(catalogId, parentId, assetId), pipelineContextOptions).ConfigureAwait(false);
                });
            }
            return result;
        }
    }
}
