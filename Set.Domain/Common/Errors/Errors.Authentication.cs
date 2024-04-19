using ErrorOr;

namespace Set.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Conflict(
        code: "Auth.InvalidCredentials",
        description: "Invalid credentials.");
    }
}