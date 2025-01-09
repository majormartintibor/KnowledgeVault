﻿using FluentAssertions;
using NetArchTest.Rules;

namespace meShop.Modules.Product.ArchitectureTests.Abstractions;

internal static class TestResultExtensions
{
    internal static void ShouldBeSuccessful(this TestResult testResult)
    {
        testResult.FailingTypes?.Should().BeEmpty();
    }
}