using Commerce.Plugin.Asset.Pipelines.Arguments;
using Commerce.Plugin.Asset.Policies;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.ManagedLists;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Plugin.Asset.Pipelines.Blocks
{
    [PipelineDisplayName("Assets.block.CreateAsset")]
    public class CreateAssetBlock : PipelineBlock<CreateAssetArgument, AssetContentArgument, CommercePipelineExecutionContext>
    {
        private readonly IDoesEntityExistPipeline _doesEntityExistPipeline;

        public CreateAssetBlock(IDoesEntityExistPipeline doesEntityExistPipeline) : base(null)
        {
            this._doesEntityExistPipeline = doesEntityExistPipeline;
        }

        public override async Task<AssetContentArgument> Run(CreateAssetArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");
            string assetId = CommerceEntity.IdPrefix<Entities.Asset>() + arg.AssetId;
            var assetAlreadyExist = await this._doesEntityExistPipeline.Run(new FindEntityArgument(typeof(Entities.Asset), assetId), context);

            if (assetAlreadyExist)
            {
                string validationError = context.GetPolicy<KnownResultCodes>().ValidationError;
                string commerceTermKey = "AssetIdAlreadyInUse";

                var args = new object[1]
                {
                   arg.AssetId
                };

                string defaultMessage = string.Format($"The product id {assetId} is already in use.");
                context.Abort(await context.CommerceContext.AddMessage(validationError, commerceTermKey, args, defaultMessage), context);
                context = null;
                return null;
            }

            var asset = new Entities.Asset()
            {
                Id = assetId,
                FriendlyId = arg.AssetId,
                Name = arg.Name,
                DisplayName = arg.DisplayName
            };

            var listMembershipComponent = asset.GetComponent<ListMembershipsComponent>();
            listMembershipComponent.Memberships.Add(string.Format($"{CommerceEntity.ListName<Entities.Asset>()}"));
            listMembershipComponent.Memberships.Add(context.GetPolicy<KnownAssetListsPolicy>().Asset);

            return new AssetContentArgument()
            {
                Assets = new List<Entities.Asset>()
                {
                    asset
                }
            };
        }
    }
}
