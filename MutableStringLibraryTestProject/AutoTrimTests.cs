using MutableStringLibrary;
using Xunit;

namespace MutableStringLibraryTestProject
{
    public class AutoTrimTests
    {
        [Fact]
        public void CreateWithAutotrim()
        {
            var s1 = new MutableString(" abc ", true, false, false);
            Assert.True(s1.Value == " abc ");
            Assert.False(s1.Value == "abc");
            var s2 = new MutableString(" abc ", true, false, true);
            Assert.True(s2.Value == "abc");
            Assert.False(s2.Value == " abc ");
        }

        [Fact]
        public void SwitchToAutotrim()
        {
            var s1 = new MutableString(" abc ", true, false, false);
            Assert.True(s1.Value == " abc ");
            Assert.False(s1.Value == "abc");
            s1.AutoTrim = true;
            Assert.True(s1.Value == "abc");
            Assert.False(s1.Value == " abc ");
        }
    }
}