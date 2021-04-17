namespace MutableStringLibrary.Comparers
{
    public interface IEqualityComparer
    {
        bool Equals(bool ignoreCase, string? a, string? b);
    }
}