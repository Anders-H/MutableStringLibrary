namespace MutableStringLibrary.Pointers;

public class RangePointer
{
    public int Position { get; }
    public int Length { get; }

    public RangePointer(int position, int length)
    {
        Position = position;
        Length = length;
    }
}