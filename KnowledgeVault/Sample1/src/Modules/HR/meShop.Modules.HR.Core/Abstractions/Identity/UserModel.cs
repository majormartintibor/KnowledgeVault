namespace meShop.Modules.HR.Core.Abstractions.Identity;

public sealed record UserModel(string Email, string Password, string FirstName, string LastName);
