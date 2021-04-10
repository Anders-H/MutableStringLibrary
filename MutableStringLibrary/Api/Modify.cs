using System.Text.RegularExpressions;

namespace MutableStringLibrary.Api
{
    public class Modify
    {
        private readonly MutableString _mutableString;

        internal Modify(MutableString mutableString)
        {
            _mutableString = mutableString;
        }

        public bool MiddleTrim()
        {
            if (string.IsNullOrWhiteSpace(_mutableString.Value))
            {
                _mutableString.Value = _mutableString.DefaultValue;
                return false;
            }

            var original = _mutableString.Value;

            _mutableString.Value = _mutableString.AutoTrim
                ? _mutableString.Value.Trim()
                : _mutableString.Value;
            
            var parts = Regex.Split(_mutableString.Value, @"\s+");
            _mutableString.Value = string.Join(' ', parts);
            return _mutableString.Value != original;
        }
    }
}