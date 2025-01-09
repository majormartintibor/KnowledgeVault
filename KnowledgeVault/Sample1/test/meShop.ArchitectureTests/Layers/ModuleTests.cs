using meShop.ArchitectureTests.Abstractions;
using meShop.Modules.HR.Infrastructure;
using meShop.Modules.Pricing.Infrastructure;
using meShop.Modules.Product.Infrastructure;
using NetArchTest.Rules;
using System.Reflection;

namespace meShop.ArchitectureTests.Layers;

public sealed class ModuleTests : BaseTest
{
    [Fact]
    public void HRModule_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [PricingNamespace, ProductNamespace];
        string[] integrationEventsModules =
        [
            PricingIntegrationEventsNamespace,
            ProductIntegrationEventsNamespace            
        ];

        List<Assembly> hrAssemblies =
        [
            Modules.HR.Core.AssemblyReference.Assembly,
            Modules.HR.Presentation.AssemblyReference.Assembly,
            typeof(HRModule).Assembly,
            typeof(Modules.HR.Persistence.PersistenceConfiguration).Assembly
        ];

        Types.InAssemblies(hrAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void PricingModule_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [HRNamespace, ProductNamespace];
        string[] integrationEventsModules =
        [
            HRIntegrationEventsNamespace,
            ProductIntegrationEventsNamespace,
        ];

        List<Assembly> pricingAssemblies =
        [
            Modules.Pricing.Core.AssemblyReference.Assembly,
            Modules.Pricing.Presentation.AssemblyReference.Assembly,
            typeof(PricingModule).Assembly,
            typeof(Modules.Pricing.Persistence.PersistenceConfiguration).Assembly
        ];     

        Types.InAssemblies(pricingAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }

    [Fact]
    public void ProductModule_ShouldNotHaveDependencyOn_AnyOtherModule()
    {
        string[] otherModules = [HRNamespace, PricingNamespace];
        string[] integrationEventsModules =
        [
            HRIntegrationEventsNamespace,
            PricingIntegrationEventsNamespace,
        ];

        List<Assembly> hrAssemblies =
        [
            Modules.Product.Core.AssemblyReference.Assembly,
            Modules.Product.Presentation.AssemblyReference.Assembly,
            typeof(ProductModule).Assembly,
            typeof(Modules.Product.Persistence.PersistenceConfiguration).Assembly
        ];

        Types.InAssemblies(hrAssemblies)
            .That()
            .DoNotHaveDependencyOnAny(integrationEventsModules)
            .Should()
            .NotHaveDependencyOnAny(otherModules)
            .GetResult()
            .ShouldBeSuccessful();
    }
}
