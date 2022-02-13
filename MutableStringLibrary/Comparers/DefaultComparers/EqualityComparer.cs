using System.Globalization;

namespace MutableStringLibrary.Comparers.DefaultComparers;

public class EqualityComparer : IEqualityComparer
{
    public bool Equals(bool ignoreCase, string? a, string? b)
    {
        if (a == null)
            return b == null;

        var options = ignoreCase
            ? CompareOptions.IgnoreCase
            : CompareOptions.None;

        return string.Compare(a, b, CultureInfo.CurrentCulture, options) == 0;
    }
}