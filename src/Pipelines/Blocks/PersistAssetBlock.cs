using Commerce.Plugin.Asset.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Plugin.Asset.Pipelines.Blocks
{
    [PipelineDisplayName("Assets.block.PersistAsset")]
    public class PersistAssetBlock : PipelineBlock<AssetContentArgument, Entities.Asset, CommercePipelineExecutionContext>
    {
        private readonly IPersistEntityPipeline _persistPipeline;
        
        public PersistAssetBlock(IPersistEntityPipeline persistEntityPipeline)
        {
            this._persistPipeline = persistEntityPipeline;
        }

        public override async Task<Entities.Asset> Run(AssetContentArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg)
                     .IsNotNull($"{this.Name}: The asset can not be null.");

            var persistEntityArgument = await this._persistPipeline.Run(new PersistEntityArgument(arg.Assets.FirstOrDefault()), context);

            return arg.Assets.FirstOrDefault();
        }
    }
}
