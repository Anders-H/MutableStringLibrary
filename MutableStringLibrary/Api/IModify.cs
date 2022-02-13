using MutableStringLibrary.Comparers;

namespace MutableStringLibrary.Api;

public interface IModify
{
    void Reset();
    bool MiddleTrim();
    bool LimitToCharacters(string characters);
    MutableString CutAt(int position, int length);
    MutableString CutAt(IPositionAndLengthFinder position);
    MutableString CutBeginningAt(int position);
    MutableString CutBeginningAt(IPositionFinder position);
    MutableString CutEndAt(int position);
    MutableString CutEndAt(IPositionFinder position);
}