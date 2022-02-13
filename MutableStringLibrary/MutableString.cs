using System.Linq;
using System.Text.RegularExpressions;
using MutableStringLibrary.Api;
using MutableStringLibrary.Comparers;

namespace MutableStringLibrary;

public class MutableString : IAnalyze, IModify
{
    private string? _value;
    private bool _autoTrim;

    public bool IgnoreCase { get; set; }
    public bool DefaultsToNull { get; set; }
    public Analyze Analyze { get; }
    public Modify Modify { get; }

    public IEqualityComparer? EqualityComparer { get; set; }
    public ISubsetComparer? SubsetComparer { get; set; }

    public MutableString() : this("", true, false, true)
    {
    }

    public MutableString(bool defaultsToNull) : this(defaultsToNull ? null : "", true, defaultsToNull, true)
    {
    }

    public MutableString(string value) : this(value, true, false, true)
    {
    }

    public MutableString(string? value, bool ignoreCase, bool defaultsToNull, bool autoTrim)
    {
        IgnoreCase = ignoreCase;
        DefaultsToNull = defaultsToNull;
        AutoTrim = autoTrim;
        Analyze = new Analyze(this);
        Modify = new Modify(this);
        Value = value;
    }

    public MutableString(string? value, StringFeature features) : this(
        value,
        (features & StringFeature.IgnoreCase) > 0,
        (features & StringFeature.DefaultsToNull) > 0,
        (features & StringFeature.AutoTrim) > 0
    )
    {
    }

    public MutableString(StringFeature features) : this(
        "",
        (features & StringFeature.IgnoreCase) > 0,
        (features & StringFeature.DefaultsToNull) > 0,
        (features & StringFeature.AutoTrim) > 0
    )
    {
        Modify.Reset();
    }

    public MutableString Copy() =>
        Copy(Value);

    public MutableString Copy(string? newValue) =>
        new(newValue, IgnoreCase, DefaultsToNull, AutoTrim)
        {
            EqualityComparer = EqualityComparer,
            SubsetComparer = SubsetComparer
        };
    
    public string? Value
    {
        get => _value;
        set
        {
            if (DefaultsToNull && value == null)
            {
                _value = null;
                return;
            }

            _value = AutoTrim
                ? value!.Trim()
                : value;
        }
    }

    public bool AutoTrim
    {
        get => _autoTrim;
        set
        {
            _autoTrim = value;
            if (_autoTrim)
                _value = _value?.Trim();
        }
    }

    public string? DefaultValue =>
        DefaultsToNull ? null : "";

    public override string ToString() =>
        Value ?? "";

    public MutableStringList Rows()
    {
        if (ToString() == "")
            return new MutableStringList();

        var split = Regex.Split(Value!, @"\r\n");
        var result = new MutableStringList();

        result.AddRange(
            split.Select(s => new MutableString(s, IgnoreCase, DefaultsToNull, AutoTrim))
        );

        return result;
    }

    public bool IsNullOrEmpty() =>
        string.IsNullOrEmpty(Value);

    public bool IsNullOrWhiteSpace() =>
        string.IsNullOrWhiteSpace(Value);

    // *** IAnalyze ***

    public bool Is(string? other) =>
        Analyze.Is(other);

    public bool Is(string? other, IEqualityComparer equalityComparer) =>
        Analyze.Is(other, equalityComparer);

    public bool Has(string? other) =>
        Analyze.Has(other);

    public bool Has(string? other, out int start) =>
        Analyze.Has(other, out start);

    public bool Has(string? other, out int start, out int length) =>
        Analyze.Has(other, out start, out length);

    public bool Has(string? other, out int start, out int length, ISubsetComparer subsetComparer) =>
        Analyze.Has(other, out start, out length, subsetComparer);

    public bool IsLimitedToCharacters(string? characters) =>
        Analyze.IsLimitedToCharacters(characters);

    // *** IModify ***

    public void Reset() =>
        Modify.Reset();

    public bool MiddleTrim() =>
        Modify.MiddleTrim();

    public bool LimitToCharacters(string characters) =>
        Modify.LimitToCharacters(characters);

    public MutableString CutAt(int position, int length) =>
        Modify.CutAt(position, length);

    public MutableString CutAt(IPositionAndLengthFinder position) =>
        Modify.CutAt(position);

    public MutableString CutBeginningAt(int position) =>
        Modify.CutBeginningAt(position);

    public MutableString CutBeginningAt(IPositionFinder position) =>
        Modify.CutBeginningAt(position);

    public MutableString CutEndAt(int position) =>
        Modify.CutEndAt(position);

    public MutableString CutEndAt(IPositionFinder position) =>
        Modify.CutEndAt(position);
}