using System;
using MutableStringLibrary.Comparers;

namespace MutableStringLibraryTestProject.TestObjects
{
    public class EqualityComparer : IEqualityComparer
    {
        public bool Equals(bool ignoreCase, string? a, string? b) =>
            a == "GOOD" && b == "DOG";
    }
}