namespace Commerce.Plugin.Asset.Entities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Sitecore.Commerce.Core;

    public class Asset : CommerceEntity
    {
        public Asset()
        {
            this.Components = new List<Component>();
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = this.DateCreated;
        }

        public Asset(string id) : this()
        {
            this.Id = id;
        }

        public Uri ImageUrl { get; set; }

        public Uri FileUrl { get; set; }

        public long FileSize { get; set; }

        public string FileExtension { get; set; }
    }
}