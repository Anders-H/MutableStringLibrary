# MutableStringLibrary

A simple wrapper around the .NET String class that allows for easy value comparison and modification, with or without case sensitivity.

## For analyzing a string:

- `Has` checks for a substring in a string.
- `Is` compares the string value with the value of another string.
- `IsLimitedToCharacters` checks if the characters of a string are limited to a given set of characters.

## For modifying a string:
- `LimitToCharacters` removes any character that is not represented in a given set of characters.
- `MiddleTrim` changes any whitespaces to a single space.
- `Reset` sets the value to the default value, depending on the `DefaultsToNull` flag.

## Flags:

- `AutoTrim`
- `DefaultsToNull`
- `IgnoreCase`
