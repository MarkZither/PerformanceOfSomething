// <copyright file="Class1.cs" company="MarkZither">
// Copyright (c) MarkZither. All rights reserved.
// </copyright>

namespace PerformanceOfSomething.Lib;

/// <summary>
/// placeholder class.
/// </summary>
public class Class1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Class1"/> class.
    /// ctor.
    /// </summary>
    protected Class1()
    {
    }

    /// <summary>
    /// return the same bool passed in, broken on purpose to show stryker in action.
    /// </summary>
    /// <param name="boolIn">the bool that will be returned.</param>
    /// <returns>a bool.</returns>
    public static bool ReturnBool(bool boolIn)
    {
        return true;
    }
}
