namespace meShop.Modules.HR.Core.Employees.Domain;

public sealed class Role
{
    public static readonly Role Example = new("Example");

    private Role(string name)
    {
        Name = name;
    }

    private Role()
    {
    }

    public string Name { get; private set; } = string.Empty;
}