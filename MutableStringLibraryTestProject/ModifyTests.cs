using MutableStringLibrary;
using MutableStringLibraryTestProject.TestObjects;
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

        [Theory]
        [InlineData("ABCDEF", 1, 4, "BCDE", "AF")]
        [InlineData("ABCDEF", 1, 0, "", "ABCDEF")]
        [InlineData("ABCDEF", 0, 6, "ABCDEF", "")]
        [InlineData("ABCDEF", -1, 6, "ABCDEF", "")]
        [InlineData("ABCDEF", 0, 7, "ABCDEF", "")]
        [InlineData("ABCDEF", -1, 20, "ABCDEF", "")]
        [InlineData("ABCDEF", 4, 20, "EF", "ABCD")]
        public void CutAt(string source, int position, int length, string result, string remain)
        {
            var s = new MutableString(source);
            var x = s.Modify.CutAt(position, length);
            Assert.True(x.Value == result);
            Assert.True(s.Value == remain);
        }

        [Theory]
        [InlineData("ABC", -1, "", "ABC")]
        [InlineData("ABC", 0, "", "ABC")]
        [InlineData("ABC", 1, "A", "BC")]
        [InlineData("ABC", 2, "AB", "C")]
        [InlineData("ABC", 3, "ABC", "")]
        [InlineData("ABC", 4, "ABC", "")]
        public void CutBeginningAt(string source, int position, string result, string remain)
        {
            var s = new MutableString(source);
            var x = s.Modify.CutBeginningAt(position);
            Assert.True(x.Value == result);
            Assert.True(s.Value == remain);
        }

        [Theory]
        [InlineData("ABC", -1, "ABC", "")]
        [InlineData("ABC", 0, "ABC", "")]
        [InlineData("ABC", 1, "BC", "A")]
        [InlineData("ABC", 2, "C", "AB")]
        [InlineData("ABC", 3, "", "ABC")]
        [InlineData("ABC", 4, "", "ABC")]
        public void CutEndAt(string source, int position, string result, string remain)
        {
            var s = new MutableString(source);
            var x = s.Modify.CutEndAt(position);
            Assert.True(x.Value == result);
            Assert.True(s.Value == remain);
        }

        [Fact]
        public void CanCutWithPositionFinder()
        {
            var s = new MutableString("ABC123");
            var x = s.Modify.CutBeginningAt(new PositionFinder());
            Assert.True(x.Value == "ABC");
            Assert.True(s.Value == "123");
            s = new MutableString("ABC123");
            x = s.Modify.CutEndAt(new PositionFinder());
            Assert.True(x.Value == "123");
            Assert.True(s.Value == "ABC");
        }
    }
}