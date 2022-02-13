using MutableStringLibrary.Comparers;

namespace MutableStringLibrary.Api;

public interface IAnalyze
{
    bool Is(string? other);
    bool Is(string? other, IEqualityComparer equalityComparer);
    bool Has(string? other);
    bool Has(string? other, out int start);
    bool Has(string? other, out int start, out int length);
    bool Has(string? other, out int start, out int length, ISubsetComparer subsetComparer);
    bool IsLimitedToCharacters(string? characters);
}