// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandsController.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Sample
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http.OData;
    using global::Commerce.Plugin.Asset.Commands;
    using Microsoft.AspNetCore.Mvc;

    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// Defines a controller
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.CommerceController" />
    public class CommandsController : CommerceController
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Commerce.Plugin.Sample.CommandsController" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="globalEnvironment">The global environment.</param>
        public CommandsController(IServiceProvider serviceProvider, CommerceEnvironment globalEnvironment)
            : base(serviceProvider, globalEnvironment)
        {
        }

        [HttpPut]
        [Route("AssociateAssetToParent()")]
        public async Task<IActionResult> AssociateAssetToParent([FromBody] ODataActionParameters value)
        {
            if (!this.ModelState.IsValid || value == null)
            {
                return new BadRequestObjectResult(this.ModelState);
            }

            if (!value.ContainsKey("catalogid") || string.IsNullOrEmpty(value["catalogid"]?.ToString()))
            {
                return new BadRequestObjectResult(value);
            }

            if (!value.ContainsKey("parentid") || string.IsNullOrEmpty(value["parentid"]?.ToString()))
            {
                return new BadRequestObjectResult(value);
            }

            if (!value.ContainsKey("referenceid") || string.IsNullOrEmpty(value["referenceid"]?.ToString()))
            {
                return new BadRequestObjectResult(value);
            }

            var catalogId = value["catalogid"].ToString();
            var parentId = value["parentid"].ToString();
            var referenceId = value["referenceid"].ToString();

            var command = this.Command<AssociateAssetToParentCommand>();
            var asset = await command.Process(this.CurrentContext, catalogId, parentId, referenceId);
            return new ObjectResult(command);
        }


        [HttpPut]
        [Route("CreateAsset()")]
        public async Task<IActionResult> CreateAsset([FromBody] ODataActionParameters value)
        {
            if (!this.ModelState.IsValid || value == null)
            {
                return new BadRequestObjectResult(this.ModelState);
            }

            if (!value.ContainsKey("id") || string.IsNullOrEmpty(value["id"]?.ToString()))
            {
                return new BadRequestObjectResult(value);
            }

            if (!value.ContainsKey("name") || string.IsNullOrEmpty(value["name"]?.ToString()))
            {
                return new BadRequestObjectResult(value);
            }

            if (!value.ContainsKey("displayname") || string.IsNullOrEmpty(value["displayname"]?.ToString()))
            {
                return new BadRequestObjectResult(value);
            }

            var assetId = value["id"].ToString();
            var name = value["name"].ToString();
            var displayName = value["displayname"].ToString();

            var command = this.Command<CreateAssetCommand>();
            var asset = await command.Process(this.CurrentContext, assetId, name, displayName);
            return new ObjectResult(command);
        }
    }
}

