using Commerce.Plugin.Asset.Pipelines;
using Commerce.Plugin.Asset.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Core.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Plugin.Asset.Commands
{
    public class CreateAssetCommand : CommerceCommand
    {
        private readonly ICreateAssetPipeline _createAssetPipeline;
        public CreateAssetCommand(ICreateAssetPipeline createAssetPipeline, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this._createAssetPipeline = createAssetPipeline;
        }

        public async Task<Entities.Asset> Process(CommerceContext commerceContext, string assetId, string name, string displayName)
        {
            AssetContentArgument result = null;
            using (CommandActivity.Start(commerceContext, this))
            {
                await this.PerformTransaction(commerceContext, async () =>
                {
                    result = await this._createAssetPipeline.Run(new CreateAssetArgument(assetId, name, displayName), commerceContext.GetPipelineContextOptions());
                });
            }

            return result?.Assets?.FirstOrDefault();
        }
    }
}
