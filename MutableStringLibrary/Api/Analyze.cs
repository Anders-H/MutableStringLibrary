using System;
using System.Globalization;
using System.Linq;

namespace MutableStringLibrary.Api
{
    public class Analyze : IDisposable
    {
        private bool _disposed;
        private MutableString? _mutableString;
        
        private CompareOptions Options =>
            _mutableString!.IgnoreCase
                ? CompareOptions.IgnoreCase
                : CompareOptions.None;

        private StringComparison Comparison =>
            _mutableString!.IgnoreCase
                ? StringComparison.CurrentCultureIgnoreCase
                : StringComparison.CurrentCulture;

        internal Analyze(MutableString mutableString)
        {
            _disposed = false;
            _mutableString = mutableString;
        }

        public bool Is(string? other)
        {
            if (_mutableString!.Value == null)
                return other == null;

            return string.Compare(_mutableString.Value, other, CultureInfo.CurrentCulture, Options) == 0;
        }

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

        public void Dispose()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);

            _disposed = true;
            _mutableString = null;
        }
    }
}