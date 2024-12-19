namespace meShop.Modules.HR.Infrastructure.Identity;

internal sealed record EmployeeRepresentation(
    string Username,
    string Email,
    string FirstName,
    string LastName,
    bool EmailVerified,
    bool Enabled,
    CredentialRepresentation[] Credentials);