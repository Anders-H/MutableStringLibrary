using System;
using System.Globalization;
using System.Linq;
using MutableStringLibrary.Comparers.DefaultComparers;

namespace MutableStringLibrary.Api
{
    public class Analyze
    {
        private readonly MutableString _mutableString;
        
        private StringComparison Comparison =>
            _mutableString!.IgnoreCase
                ? StringComparison.CurrentCultureIgnoreCase
                : StringComparison.CurrentCulture;

        internal Analyze(MutableString mutableString)
        {
            _mutableString = mutableString;
        }

        public bool Is(string? other) =>
            (_mutableString.EqualityComparer ?? new EqualityComparer())
                .Equals(_mutableString.IgnoreCase, _mutableString.Value, other);

        public bool Has(string? other) =>
            Has(other, out _, out _);

        public bool Has(string? other, out int start) =>
            Has(other, out start, out _);

        public bool Has(string? other, out int start, out int length)
        {
            start = -1;
            length = -1;

            if (_mutableString!.Value == null && other == null)
            {
                start = 0;
                length = 0;
                return true;
            }

            if (_mutableString.Value == null || other == null)
                return false;

            var foundAt = _mutableString.Value.IndexOf(other, Comparison);
            if (foundAt < 0)
                return false;

            start = foundAt;
            length = other.Length;
            return true;
        }

        public bool IsLimitedToCharacters(string? characters)
        {
            if (_mutableString!.Value == null && characters == null)
                return true;

            if (_mutableString.Value == "" && characters == "")
                return true;

            if (string.IsNullOrEmpty(characters))
                return false;

            var allowed = _mutableString.IgnoreCase
                ? characters.ToLower(CultureInfo.CurrentCulture) + characters.ToUpper(CultureInfo.CurrentCulture)
                : characters;

            return _mutableString.Value!.All(c => allowed!.IndexOf(c) > -1);
        }
    }
}