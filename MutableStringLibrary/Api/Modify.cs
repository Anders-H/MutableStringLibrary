using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using MutableStringLibrary.Comparers;

namespace MutableStringLibrary.Api;

public class Modify
{
    private readonly MutableString _mutableString;

    private string? V
    {
        get => _mutableString.Value;
        set => _mutableString.Value = value;
    }

    internal Modify(MutableString mutableString)
    {
        _mutableString = mutableString;
    }

    public void Reset() =>
        V = _mutableString.DefaultValue;

    public bool MiddleTrim()
    {
        if (string.IsNullOrWhiteSpace(_mutableString!.Value))
        {
            V = _mutableString.DefaultValue;
            return false;
        }

        var original = V;

        V = _mutableString.AutoTrim
            ? V!.Trim()
            : V;
        
        var parts = Regex.Split(V!, @"\s+");
        V = string.Join(' ', parts);
        return V != original;
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

        foreach (var c in V!)
        {
            if (allowed.IndexOf(c) > -1)
                result.Append(c);
            else
                modified = true;
        }

        V = _mutableString.AutoTrim
            ? result.ToString().Trim()
            : result.ToString();
        
        return modified;
    }

    public MutableString CutAt(int position, int length)
    {
        if (string.IsNullOrEmpty(V))
        {
            _mutableString.Modify.Reset();
            return _mutableString.Copy(_mutableString.DefaultValue);
        }

        if (length <= 0)
            return _mutableString.Copy(_mutableString.DefaultValue);

        if (position <= 0)
            position = 0;

        if (position >= V.Length)
            return _mutableString.Copy(_mutableString.DefaultValue);

        if (position + length > V.Length)
            length = V.Length - position;

        var cutaway = V.Substring(position, length);
        V = $"{V.Substring(0, position)}{V[(position + length)..]}";

        return _mutableString.Copy(cutaway);
    }

    public MutableString CutAt(IPositionAndLengthFinder position)
    {
        var (p, l) = position.Find(_mutableString);
        return CutAt(p, l);
    }

    public MutableString CutBeginningAt(int position)
    {
        if (string.IsNullOrEmpty(V))
        {
            _mutableString.Modify.Reset();
            return _mutableString.Copy(_mutableString.DefaultValue);
        }

        if (position <= 0)
        {
            return _mutableString.Copy(_mutableString.DefaultValue);
        }

        if (position >= V.Length)
        {
            var result = V;
            _mutableString.Modify.Reset();
            return _mutableString.Copy(result);
        }

        var cutaway = V.Substring(0, position);
        V = V.Substring(position);

        return _mutableString.Copy(cutaway);
    }

    public MutableString CutBeginningAt(IPositionFinder position) =>
        CutBeginningAt(position.Find(_mutableString));

    public MutableString CutEndAt(int position)
    {
        if (string.IsNullOrEmpty(V))
        {
            _mutableString.Modify.Reset();
            return _mutableString.Copy(_mutableString.DefaultValue);
        }

        if (position <= 0)
        {
            var result = V;
            _mutableString.Modify.Reset();
            return _mutableString.Copy(result);
        }

        if (position >= V.Length)
        {
            return _mutableString.Copy(_mutableString.DefaultValue);
        }

        var cutaway = V.Substring(position);
        V = V.Substring(0, position);

        return _mutableString.Copy(cutaway);
    }

    public MutableString CutEndAt(IPositionFinder position) =>
        CutEndAt(position.Find(_mutableString));
}