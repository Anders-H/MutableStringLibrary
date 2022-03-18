using System;
using System.Collections.Generic;
using MutableStringLibrary.Api;
using MutableStringLibrary.Comparers;

namespace MutableStringLibrary;

public class MutableStringList : List<MutableString>, ICutter<MutableStringList>
{
    public bool IgnoreCase { get; set; }
    public bool DefaultsToNull { get; set; }
    public bool AutoTrim { get; set; }

    public MutableStringList() : this(true, false, true)
    {
    }

    public MutableStringList(bool ignoreCase, bool defaultsToNull, bool autoTrim)
    {
        IgnoreCase = ignoreCase;
        DefaultsToNull = defaultsToNull;
        AutoTrim = autoTrim;
    }

    public void Add(string value) =>
        Add(new MutableString(value, IgnoreCase, DefaultsToNull, AutoTrim));

    public MutableStringList BlankCopy() =>
        new MutableStringList(IgnoreCase, DefaultsToNull, AutoTrim);

    public void RemoveIf(Func<MutableString, bool> d)
    {
        var again = true;
        while (again)
        {
            again = false;
            var index = 0;
            foreach (var x in this)
            {
                if (d(x))
                {
                    RemoveAt(index);
                    again = true;
                    break;
                }
                index++;
            }
        }
    }

    public void RemoveIfIsNullOrWhiteSpace() =>
        RemoveIf(s => s.IsNullOrWhiteSpace());

    public void RemoveIfIsNullOrEmpty() =>
        RemoveIf(s => s.IsNullOrEmpty());

    public bool IsSameAs(params string[] values)
    {
        if (Count != values.Length)
            return false;

        if (Count <= 0)
            return true;

        for (var i = 0; i < Count; i++)
            if (!this[i].Is(values[i]))
                return false;

        return true;
    }

    public MutableStringList CutAt(int position, int length)
    {
        if (position < 0)
        {
            length += position;
            position = 0;
        }

        if (length <= 0)
            return BlankCopy();

        if (position >= Count)
            return BlankCopy();

        var result = BlankCopy();

        for (var i = 0; i < length; i++)
        {
            result.Add(this[position]);
            this.RemoveAt(position);
        }

        return result;
    }

    public MutableStringList CutAt(IPositionAndLengthFinder position)
    {
        return null;
    }

    public MutableStringList CutBeginningAt(int position)
    {
        return null;
    }

    public MutableStringList CutBeginningAt(IPositionFinder position)
    {
        return null;
    }

    public MutableStringList CutEndAt(int position)
    {
        return null;
    }

    public MutableStringList CutEndAt(IPositionFinder position)
    {
        return null;
    }
}