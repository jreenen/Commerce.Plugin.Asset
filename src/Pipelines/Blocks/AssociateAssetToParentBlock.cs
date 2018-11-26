using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;
using System.Threading.Tasks;

namespace Commerce.Plugin.Asset.Pipelines.Blocks
{
    [PipelineDisplayName("Assets.block.associateassettoparent")]
    public class AssociateAssetToParentBlock : PipelineBlock<CatalogReferenceArgument, CatalogContentArgument, CommercePipelineExecutionContext>
    {
        private readonly IFindEntityPipeline _findEntityPipeline;
        private readonly CreateRelationshipCommand _createRelationshipCommand;

        public AssociateAssetToParentBlock(IFindEntityPipeline findEntityPipeline, CreateRelationshipCommand createRelationshipCommand) : base(null)
        {
            this._findEntityPipeline = findEntityPipeline;
            this._createRelationshipCommand = createRelationshipCommand;
        }

        public override async Task<CatalogContentArgument> Run(CatalogReferenceArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull(string.Format($"{this.Name}: The argument can not be null"));
            Condition.Requires(arg.CatalogId).IsNotNullOrEmpty(string.Format($"{this.Name}: The catalog identifier can not be null or empty"));
            Condition.Requires(arg.ParentId).IsNotNullOrEmpty(string.Format($"{this.Name}: The parent identifier can not be null or empty"));
            Condition.Requires(arg.ReferenceId).IsNotNullOrEmpty(string.Format($"{this.Name}: The reference identifier can not be null or empty"));

            var catalog = await this._findEntityPipeline.Run(new FindEntityArgument(typeof(Catalog), arg.CatalogId, false), context);
            var commerceEntity = await this._findEntityPipeline.Run(new FindEntityArgument(typeof(Entities.Asset), arg.ReferenceId, false), context);

            if (catalog == null || commerceEntity == null)
            {
                return new CatalogContentArgument();
            }

            var relationshipArgument = await this._createRelationshipCommand.Process(context.CommerceContext, arg.ParentId, commerceEntity.Id, "AssetToSellableItem" );
            return new CatalogContentArgument()
            {
                Catalog = (Catalog)catalog
            };
        }
    }
}
