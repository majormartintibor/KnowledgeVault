using meShop.Modules.Pricing.ArchitectureTests.Abstractions;
using NetArchTest.Rules;

namespace meShop.Modules.Pricing.ArchitectureTests.Layers;

public class LayerTests : BaseTest
{
    [Fact]
    public void CoreLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        Types
            .InAssembly(CoreAssembly)
            .Should()
            .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void CoreLayer_ShouldNotHaveDependencyOn_PersistenceLayer()
    {
        Types.InAssembly(CoreAssembly)
            .Should()
            .NotHaveDependencyOn(PersistenceAssembly.GetName().Name)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void CoreLayer_ShouldNotHaveDependencyOn_PresentationLayer()
    {
        Types.InAssembly(CoreAssembly)
            .Should()
            .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void PresentationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        Types.InAssembly(PresentationAssembly)
            .Should()
            .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void PresentationLayer_ShouldNotHaveDependencyOn_PersistenceLayer()
    {
        Types.InAssembly(PresentationAssembly)
            .Should()
            .NotHaveDependencyOn(PersistenceAssembly.GetName().Name)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void PersistenceLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        Types.InAssembly(PersistenceAssembly)
            .Should()
            .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void PersistenceLayer_ShouldNotHaveDependencyOn_PresentationLayer()
    {
        Types.InAssembly(PersistenceAssembly)
            .Should()
            .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
            .GetResult()
            .ShouldBeSuccessful();
    }
}
