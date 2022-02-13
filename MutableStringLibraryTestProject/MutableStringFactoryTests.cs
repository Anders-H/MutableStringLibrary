using MutableStringLibrary;
using Xunit;

namespace MutableStringLibraryTestProject;

public class MutableStringFactoryTests
{
    [Fact]
    public void CanCreateNotNullableStrings()
    {
        var f = new MutableStringFactory(false, false, false);
        var s = f.Get();
        Assert.True(s.Value == "");
    }

    [Fact]
    public void CanCreateNullableStrings()
    {
        var f = new MutableStringFactory(false, true, false);
        var s = f.Get();
        Assert.True(s.Value == null);
    }
}