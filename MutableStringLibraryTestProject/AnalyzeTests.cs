using MutableStringLibrary;
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
                Assert.True(s.Analyze.Is(s2));
            else
                Assert.False(s.Analyze.Is(s2));
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
                Assert.True(s.Analyze.Is(s2));
            else
                Assert.False(s.Analyze.Is(s2));
        }
    }
}