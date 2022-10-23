// <copyright file="TestHelper.cs" company="MarkZither">
// Copyright (c) MarkZither. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using PerformanceOfSomething.Lib.Configuration;

namespace PerformanceOfSomething.Tests
{
    /// <summary>
    /// TestHelper to get configuration.
    /// </summary>
    public static class TestHelper
    {
        /// <summary>
        /// Get the configuration.
        /// </summary>
        /// <param name="outputPath">config location.</param>
        /// <returns>a configuration root.</returns>
        public static IConfiguration GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                    .SetBasePath(outputPath)
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddEnvironmentVariables()
                    .AddUserSecrets<TestBase>()
                    .Build();
        }

        /// <summary>
        /// Get the root configuration.
        /// </summary>
        /// <param name="outputPath">Path to the config file.</param>
        /// <returns>The root configuration.</returns>
        public static PerformanceOfSomethingOptions GetApplicationConfiguration(string outputPath)
        {
            var iConfig = GetIConfigurationRoot(outputPath);
            var options = iConfig.Get(typeof(PerformanceOfSomethingOptions)) as PerformanceOfSomethingOptions;
            return options ?? new PerformanceOfSomethingOptions();
        }
    }
}
