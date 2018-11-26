using Sitecore.Commerce.Core;
using Sitecore.Framework.Conditions;

namespace Commerce.Plugin.Asset.Pipelines.Arguments
{
    public class CreateAssetArgument : PipelineArgument
    {
        public CreateAssetArgument(string assetId, string name, string displayName)
        {
            Condition.Requires<string>(assetId).IsNotNullOrEmpty("The asset identifier can not be null");
            Condition.Requires<string>(name).IsNotNullOrEmpty("The name can not be null");
            Condition.Requires<string>(displayName).IsNotNullOrEmpty("The display name can not be null");

            this.AssetId = assetId;
            this.Name = name;
            this.DisplayName = displayName;
        }

        public string AssetId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
}
