namespace MutableStringLibrary.Comparers
{
    public interface ISubsetComparer
    {
        public bool Has(bool ignoreCase, string? a, string? b, out int start, out int length);
    }
}