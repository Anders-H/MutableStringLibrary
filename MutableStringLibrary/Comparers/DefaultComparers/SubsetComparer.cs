using System;

namespace MutableStringLibrary.Comparers.DefaultComparers
{
    public class SubsetComparer : ISubsetComparer
    {
        public bool Has(bool ignoreCase, string? a, string? b, out int start, out int length)
        {
            start = -1;
            length = -1;

            if (a == null && b == null)
            {
                start = 0;
                length = 0;
                return true;
            }

            if (a == null || b == null)
                return false;

            var comparison = ignoreCase
                    ? StringComparison.CurrentCultureIgnoreCase
                    : StringComparison.CurrentCulture;

            var foundAt = a.IndexOf(b, comparison);
            if (foundAt < 0)
                return false;

            start = foundAt;
            length = b.Length;
            return true;
        }
    }
}