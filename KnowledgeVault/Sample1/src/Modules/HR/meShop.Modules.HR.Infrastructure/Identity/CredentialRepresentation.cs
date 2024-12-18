namespace meShop.Modules.HR.Infrastructure.Identity;

internal sealed record CredentialRepresentation(string Type, string Value, bool Temporary);