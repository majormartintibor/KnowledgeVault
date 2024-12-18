﻿using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.HR.Core.Abstractions.Identity;

public static class IdentityProviderErrors
{
    public static readonly Error EmailIsNotUnique = Error.Conflict(
        "Identity.EmailIsNotUnique",
        "The specified email is not unique.");
}