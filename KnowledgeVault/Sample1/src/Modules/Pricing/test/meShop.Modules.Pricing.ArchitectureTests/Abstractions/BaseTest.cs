using meShop.Modules.Pricing.Infrastructure;
using System.Reflection;

namespace meShop.Modules.Pricing.ArchitectureTests.Abstractions;
public abstract class BaseTest
{
    protected static readonly Assembly CoreAssembly = Pricing.Core.AssemblyReference.Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(PricingModule).Assembly;
    protected static readonly Assembly PersistenceAssembly = typeof(Persistence.PersistenceConfiguration).Assembly;
    protected static readonly Assembly PresentationAssembly = Pricing.Presentation.AssemblyReference.Assembly;
}