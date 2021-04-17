using System.Globalization;
using System.Text;
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

        public void Reset() =>
            _mutableString!.Value = _mutableString.DefaultValue;

        public bool MiddleTrim()
        {
            if (string.IsNullOrWhiteSpace(_mutableString!.Value))
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

        public bool LimitToCharacters(string characters)
        {
            if (string.IsNullOrEmpty(_mutableString!.Value))
                return true;

            var allowed = _mutableString.IgnoreCase
                ? characters.ToLower(CultureInfo.CurrentCulture) + characters.ToUpper(CultureInfo.CurrentCulture)
                : characters;

            var modified = false;
            var result = new StringBuilder();

            foreach (var c in _mutableString.Value)
            {
                if (allowed.IndexOf(c) > -1)
                    result.Append(c);
                else
                    modified = true;
            }

            _mutableString.Value = _mutableString.AutoTrim
                ? result.ToString().Trim()
                : result.ToString();
            
            return modified;
        }

        public MutableString CutBeginningAt(int position)
        {
            if (string.IsNullOrEmpty(_mutableString.Value))
            {
                _mutableString.Modify.Reset();
                return _mutableString.Copy(_mutableString.DefaultValue);
            }

            if (position <= 0)
            {
                return _mutableString.Copy(_mutableString.DefaultValue);
            }

            if (position >= _mutableString.Value.Length)
            {
                var result = _mutableString.Value;
                _mutableString.Modify.Reset();
                return _mutableString.Copy(result);
            }

            var cutaway = _mutableString.Value.Substring(0, position);
            _mutableString.Value = _mutableString.Value.Substring(position);

            return new MutableString(cutaway);
        }
    }
}