using System;

namespace MutableStringLibrary;

[Flags]
public enum StringFeature
{
    None = 0,
    IgnoreCase = 1,
    AutoTrim = 2,
    DefaultsToNull = 4
}