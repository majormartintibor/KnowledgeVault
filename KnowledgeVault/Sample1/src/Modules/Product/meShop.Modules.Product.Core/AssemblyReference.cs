using System.Reflection;

namespace meShop.Modules.Product.Core;
public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}