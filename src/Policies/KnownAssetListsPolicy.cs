using Sitecore.Commerce.Core;

namespace Commerce.Plugin.Asset.Policies
{
    public class KnownAssetListsPolicy : Policy
    {
        public KnownAssetListsPolicy()
        {
            this.Asset = nameof(Asset);
        }

        public string Asset { get; set; }
    }
}
