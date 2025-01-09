using meShop.Modules.Product.Infrastructure;
using System.Reflection;

namespace meShop.Modules.Product.ArchitectureTests.Abstractions;
public abstract class BaseTest
{
    protected static readonly Assembly CoreAssembly = Product.Core.AssemblyReference.Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(ProductModule).Assembly;
    protected static readonly Assembly PersistenceAssembly = typeof(Persistence.PersistenceConfiguration).Assembly;
    protected static readonly Assembly PresentationAssembly = Product.Presentation.AssemblyReference.Assembly;
}