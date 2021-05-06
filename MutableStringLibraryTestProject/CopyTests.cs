using MutableStringLibrary;
using Xunit;

namespace MutableStringLibraryTestProject
{
    public class CopyTests
    {
        [Fact]
        public void CanCopyAttributes()
        {
            var original1 = new MutableString("Abc", true, true, true);
            var copy1 = original1.Copy("Cde");
            Assert.True(copy1.DefaultsToNull);
            Assert.True(copy1.IgnoreCase);
            Assert.True(copy1.AutoTrim);
            Assert.True(copy1.Value == "Cde");

            var original2 = new MutableString("Abc", true, true, true);
            var copy2 = original2.Copy();
            Assert.True(copy2.DefaultsToNull);
            Assert.True(copy2.IgnoreCase);
            Assert.True(copy2.AutoTrim);
            Assert.True(copy2.Value == "Abc");
        }
    }
}
