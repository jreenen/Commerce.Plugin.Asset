// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSitecore.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Sample
{
    using System.Reflection;
    using global::Commerce.Plugin.Asset.Pipelines;
    using global::Commerce.Plugin.Asset.Pipelines.Blocks;
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Configuration;
    using Sitecore.Framework.Pipelines.Definitions.Extensions;

    /// <summary>
    /// The configure sitecore class.
    /// </summary>
    public class ConfigureSitecore : IConfigureSitecore
    {
        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            services.Sitecore().Pipelines(config => config
            .AddPipeline<IPersistAssetPipeline, PersistAssetPipeline>(
                configure =>
                    {
                        configure.Add<PersistAssetBlock>();
                    })
            .AddPipeline<ICreateAssetPipeline, CreateAssetPipeline>(
                configure =>
                    {
                        configure.Add<CreateAssetBlock>()
                                 .Add<IPersistAssetPipeline>();
                    })
            .AddPipeline<IAssociateAssetToParentPipeline, AssociateAssetToParentPipeline>(
                configure =>
                {
                    configure.Add<AssociateAssetToParentBlock>();
                })
             .ConfigurePipeline<IConfigureServiceApiPipeline>(configure => configure.Add<ConfigureServiceApiBlock>()));

            services.RegisterAllCommands(assembly);
        }
    }
}