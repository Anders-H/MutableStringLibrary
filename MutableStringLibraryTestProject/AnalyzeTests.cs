using MutableStringLibrary;
using MutableStringLibraryTestProject.TestObjects;
using Xunit;

namespace MutableStringLibraryTestProject
{
    public class AnalyzeTests
    {
        [Theory]
        [InlineData(true, "ABC", "Abcd", false)]
        [InlineData(true, "ABC", "Abc", true)]
        [InlineData(true, "ABC", "ABC", true)]
        [InlineData(false, "ABC", "Abc", false)]
        [InlineData(false, "ABC", "ABC", true)]
        public void Is(bool ignoreCase, string s1, string s2, bool result)
        {
            var s = new MutableString(s1, ignoreCase, false, false);
            if (result)
                Assert.True(s.Is(s2));
            else
                Assert.False(s.Is(s2));
        }

        [Theory]
        [InlineData(null, null, true)]
        [InlineData(null, "", false)]
        [InlineData("", null, false)]
        [InlineData("", "", true)]
        public void IsNull(string s1, string s2, bool result)
        {
            var s = new MutableString(s1, false, true, false);
            if (result)
                Assert.True(s.Is(s2));
            else
                Assert.False(s.Is(s2));
        }

        [Fact]
        public void EqualityComparer()
        {
            var s = new MutableString("Hello");
            Assert.True(s.Is("hello"));
            Assert.False(s.Is("Good bye"));
            s.EqualityComparer = new EqualityComparer();
            s.Value = "GOOD";
            Assert.True(s.Is("DOG"));
            Assert.False(s.Is("GOOD"));
            s.EqualityComparer = null;
            Assert.False(s.Is("DOG"));
            Assert.True(s.Is("GOOD"));
        }

        [Fact]
        public void Has()
        {
            var s = new MutableString("Conny Karlsson");
            Assert.True(s.Has("KARL", out var start, out var length));
            Assert.True(start == 6);
            Assert.True(length == 4);
            Assert.False(s.Has("SVEN", out start, out length));
            Assert.True(start == -1);
            Assert.True(length == -1);
        }

        [Fact]
        public void IsLimitedToCharacters()
        {
            var s = new MutableString("Sven Hedin");
            Assert.True(s.IsLimitedToCharacters("hedin svenne ju"));
            Assert.False(s.IsLimitedToCharacters("nide"));
        }
    }
}