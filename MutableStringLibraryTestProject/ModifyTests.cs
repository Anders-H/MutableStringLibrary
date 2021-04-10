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
    }
}
