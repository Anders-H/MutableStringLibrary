using MutableStringLibrary;
using Xunit;

namespace MutableStringLibraryTestProject
{
    public class ModifyTests
    {
        [Fact]
        public void MiddleTrim()
        {
            var s = new MutableString("abc");
            Assert.False(s.Modify.MiddleTrim());
            Assert.True(s.Value == "abc");
            s.Value = "abc 123";
            Assert.False(s.Modify.MiddleTrim());
            Assert.True(s.Value == "abc 123");
            s.Value = "abc  123";
            Assert.True(s.Modify.MiddleTrim());
            Assert.True(s.Value == "abc 123");
            s.Value = @"abc
def";
            Assert.True(s.Modify.MiddleTrim());
            Assert.True(s.Value == "abc def");
        }

        [Fact]
        public void LimitToCharacters()
        {
            var s = new MutableString("Abc");
            Assert.False(s.Modify.LimitToCharacters("abcd"));
            Assert.True(s.Value == "Abc");
            Assert.True(s.Modify.LimitToCharacters("BC"));
            Assert.True(s.Value == "bc");
        }
    }
}