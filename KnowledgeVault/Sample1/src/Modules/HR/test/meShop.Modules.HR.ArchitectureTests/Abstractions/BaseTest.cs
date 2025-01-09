using meShop.Modules.HR.Infrastructure;
using System.Reflection;

namespace meShop.Modules.HR.ArchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected static readonly Assembly CoreAssembly = HR.Core.AssemblyReference.Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(HRModule).Assembly;
    protected static readonly Assembly PersistenceAssembly = typeof(Persistence.PersistenceConfiguration).Assembly;
    protected static readonly Assembly PresentationAssembly = HR.Presentation.AssemblyReference.Assembly;
}