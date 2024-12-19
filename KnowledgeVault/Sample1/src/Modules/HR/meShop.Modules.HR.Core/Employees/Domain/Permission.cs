namespace meShop.Modules.HR.Core.Employees.Domain;

public sealed class Permission
{
    public static readonly Permission Example = new("example:read");


    public string Code { get; } = string.Empty;

    private Permission() { }
    public Permission(string code)
    {
        Code = code;
    }
}