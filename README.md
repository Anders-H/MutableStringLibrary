# MutableStringLibrary

A simple wrapper around the .NET String class that allows for easy value comparison and modification, with or without case sensitivity.

[NuGet:](https://www.nuget.org/packages/MutableStringLibrary/) `Install-Package MutableStringLibrary`

## For analyzing a string:

- `Has` checks for a substring in a string.
- `Is` compares the string value with the value of another string.
- `IsLimitedToCharacters` checks if the characters of a string are limited to a given set of characters.

## For modifying a string:
- `CutAt` removes a given section from the string and returns the removed part.
- `CutBeginningAt` returns the characters until the given position and keeps the remainder.
- `CutEntAt` returns the characters efter the given position and keeps the beginning.
- `LimitToCharacters` removes any character that is not represented in a given set of characters.
- `MiddleTrim` changes any whitespaces to a single space.
- `Reset` sets the value to the default value, depending on the `DefaultsToNull` flag.

## Flags:

- `AutoTrim`
- `DefaultsToNull`
- `IgnoreCase`

## CutBeginningAt

The function `CutBeginningAt` removes the beginning of a string and returns the removed part as a mutable string with the same flags.

**Basic example:**

```
var s1 = new MutableString("Paul Stanley");
var s2 = s1.Modify.CutBeginningAt(5);
Console.WriteLine(s2.Value); // Paul
Console.WriteLine(s1.Value); // Stanley
```

**Advanced example:**

```
class PositionFinder : IPositionFinder
{
    public int Find(MutableString value) =>
        5;
}

var s1 = new MutableString("Paul Stanley");
var s2 = s1.Modify.CutBeginningAt(new PositionFinder());
Console.WriteLine(s2.Value); // Paul
Console.WriteLine(s1.Value); // Stanley
```
