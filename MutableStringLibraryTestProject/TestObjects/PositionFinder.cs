using MutableStringLibrary;
using MutableStringLibrary.Comparers;

namespace MutableStringLibraryTestProject.TestObjects
{
    public class PositionFinder : IPositionFinder
    {
        public int Find(MutableString value) =>
            3;
    }
}