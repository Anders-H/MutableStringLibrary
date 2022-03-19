using MutableStringLibrary.Pointers;

namespace MutableStringLibrary.Comparers;

public interface IPositionAndLengthFinder<T>
{
    RangePointer Find(T value);
}