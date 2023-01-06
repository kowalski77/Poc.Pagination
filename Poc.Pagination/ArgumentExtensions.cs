using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Poc.Pagination;

public static class ArgumentExtensions
{
    public static T NonNull<T>([NotNull] this T value, [CallerArgumentExpression("value")] string? paramName = null) =>
        value ??
        throw new ArgumentNullException(paramName);

    public static int NonNegativeOrZero(this int value, [CallerArgumentExpression("value")] string? paramName = null) =>
        value >= 0
            ? value
            : throw new ArgumentOutOfRangeException(paramName, value, "Value must be non-negative or zero.");
}
