namespace MutableStringLibrary.Api;

public interface IModify
{
    void Reset();
    bool MiddleTrim();
    bool LimitToCharacters(string characters);
}