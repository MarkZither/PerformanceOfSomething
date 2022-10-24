// <copyright file="UnitTest1.cs" company="MarkZither">
// Copyright (c) MarkZither. All rights reserved.
// </copyright>

using FluentAssertions;

using Microsoft.Extensions.Logging;

using NSubstitute;

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
        var logger = Substitute.For<ILogger<Class1>>();
        var class1 = new Class1(logger);

        // Act
        var inTrue = true;
        var retBool = class1.ReturnBool(inTrue);

        // Assert
        Assert.True(retBool);
    }

    /// <summary>
    /// Placeholder test.
    /// </summary>
    [Fact]
    public void ReturnBool_Throws_ArgumentException_When_Given_False()
    {
        // Arrange
        var logger = Substitute.For<ILogger<Class1>>();
        var sut = new Class1(logger);

        // Act
        var inFalse = false;
        Action act = () => sut.ReturnBool(inFalse);

        // Assert
        act.Should().ThrowExactly<ArgumentException>().WithMessage("boolIn must be true. (Parameter 'boolIn')");
    }
}