// <copyright file="Class1.cs" company="MarkZither">
// Copyright (c) MarkZither. All rights reserved.
// </copyright>

using System.Xml.Linq;
using Dawn;
using Microsoft.Extensions.Logging;

namespace PerformanceOfSomething.Lib;

/// <summary>
/// placeholder class.
/// </summary>
public class Class1
{
    private readonly ILogger<Class1> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Class1"/> class.
    /// </summary>
    /// <param name="logger">A logger.</param>
    public Class1(ILogger<Class1> logger)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// return the same bool passed in, broken on purpose to show stryker in action.
    /// </summary>
    /// <param name="boolIn">the bool that will be returned.</param>
    /// <returns>a bool.</returns>
    public bool ReturnBool(bool boolIn)
    {
        Guard.Argument(boolIn, nameof(boolIn)).True();
        this.logger.LogInformation("The bool was {boolIn}", boolIn);
        return true;
    }
}
