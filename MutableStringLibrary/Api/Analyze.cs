using System.Globalization;
using System.Linq;
using MutableStringLibrary.Comparers;
using MutableStringLibrary.Comparers.DefaultComparers;

namespace MutableStringLibrary.Api
{
    public class Analyze
    {
        private readonly MutableString _mutableString;

        private string? V =>
            _mutableString.Value;

        internal Analyze(MutableString mutableString)
        {
            _mutableString = mutableString;
        }

        public bool Is(string? other) =>
            (_mutableString.EqualityComparer ?? new EqualityComparer())
                .Equals(_mutableString.IgnoreCase, V, other);

        public bool Is(string? other, IEqualityComparer equalityComparer) =>
            equalityComparer
                .Equals(_mutableString.IgnoreCase, V, other);

        public bool Has(string? other) =>
            Has(other, out _, out _);

        public bool Has(string? other, out int start) =>
            Has(other, out start, out _);

        public bool Has(string? other, out int start, out int length) =>
            (_mutableString.SubsetComparer ?? new SubsetComparer())
                .Has(_mutableString.IgnoreCase, V, other, out start, out length);

        public bool Has(string? other, out int start, out int length, ISubsetComparer subsetComparer) =>
            subsetComparer
                .Has(_mutableString.IgnoreCase, V, other, out start, out length);

        public bool IsLimitedToCharacters(string? characters)
        {
            if (_mutableString!.Value == null && characters == null)
                return true;

            if (V == "" && characters == "")
                return true;

            if (string.IsNullOrEmpty(characters))
                return false;

            var allowed = _mutableString.IgnoreCase
                ? characters.ToLower(CultureInfo.CurrentCulture) + characters.ToUpper(CultureInfo.CurrentCulture)
                : characters;

            return V!.All(c => allowed!.IndexOf(c) > -1);
        }
    }
}