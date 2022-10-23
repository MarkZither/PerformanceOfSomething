// <copyright file="TestBase.cs" company="MarkZither">
// Copyright (c) MarkZither. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using PerformanceOfSomething.Lib.Configuration;

namespace PerformanceOfSomething.Tests
{
    /// <summary>
    /// TestBase to setup services and configuration.
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// The root configuration.
        /// </summary>
        private readonly PerformanceOfSomethingOptions configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase"/> class.
        /// </summary>
        public TestBase()
        {
            this.configuration = TestHelper.GetApplicationConfiguration(Directory.GetCurrentDirectory());
        }
    }
}
