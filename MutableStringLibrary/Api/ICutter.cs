using MutableStringLibrary.Comparers;

namespace MutableStringLibrary.Api
{
    public interface ICutter<T>
    {
        T CutAt(int position, int length);
        T CutAt(IPositionAndLengthFinder position);
        T CutBeginningAt(int position);
        T CutBeginningAt(IPositionFinder position);
        T CutEndAt(int position);
        T CutEndAt(IPositionFinder position);
    }
}