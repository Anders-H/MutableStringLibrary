using MutableStringLibrary.Comparers;

namespace MutableStringLibrary.Api
{
    public interface ICutter<T>
    {
        T CutAt(int position, int length);
        T CutAt(IPositionAndLengthFinder<T> position);
        T CutBeginningAt(int position);
        T CutBeginningAt(IPositionFinder<T> position);
        T CutEndAt(int position);
        T CutEndAt(IPositionFinder<T> position);
    }
}