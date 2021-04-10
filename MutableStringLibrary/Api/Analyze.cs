using System.Globalization;

namespace MutableStringLibrary.Api
{
    public class Analyze
    {
        private readonly MutableString _mutableString;

        internal Analyze(MutableString mutableString)
        {
            _mutableString = mutableString;
        }

        public bool Is(string? other)
        {
            if (_mutableString.Value == null)
                return other == null;

            var options = _mutableString.IgnoreCase
                ? CompareOptions.IgnoreCase
                : CompareOptions.None;

            return string.Compare(_mutableString.Value, other, CultureInfo.CurrentCulture, options) == 0;
        }
    }
}