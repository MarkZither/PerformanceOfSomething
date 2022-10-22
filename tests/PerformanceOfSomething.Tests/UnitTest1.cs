// <copyright file="UnitTest1.cs" company="MarkZither">
// Copyright (c) MarkZither. All rights reserved.
// </copyright>

using PerformanceOfSomething.Lib;

namespace PerformanceOfSomething.Tests;

/// <summary>
/// placeholder unit test.
/// </summary>
public class UnitTest1
{
    /// <summary>
    /// Placeholder test.
    /// </summary>
    [Fact]
    public void ReturnBool_Returns_True_When_Given_True()
    {
        // Arrange

        // Act
        var inTrue = true;
        var retBool = Class1.ReturnBool(inTrue);

        // Assert
        Assert.True(retBool);
    }

    /// <summary>
    /// Placeholder test.
    /// </summary>
    [Fact]
    public void ReturnBool_Returns_True_When_Given_False()
    {
        // Arrange

        // Act
        var inFalse = false;
        var retBool = Class1.ReturnBool(inFalse);

        // Assert
        Assert.True(retBool);
    }
}