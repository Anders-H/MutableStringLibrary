namespace MutableStringLibrary.Comparers
{
    public interface IPositionAndLengthFinder
    {
        (int position, int length) Find(MutableString value);
    }
}