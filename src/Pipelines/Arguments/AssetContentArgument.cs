using Sitecore.Commerce.Core;
using System.Collections.Generic;

namespace Commerce.Plugin.Asset.Pipelines.Arguments
{
    public class AssetContentArgument : PipelineArgument
    {
        public List<Entities.Asset> Assets { get; set; }
    }
}
