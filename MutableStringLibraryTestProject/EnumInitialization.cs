using MutableStringLibrary;
using Xunit;

namespace MutableStringLibraryTestProject;

public class EnumInitialization
{
    [Fact]
    public void CanIgnoreCase()
    {
        var x = new MutableString("Ignore CASE", StringFeature.IgnoreCase);
        Assert.True(x.IgnoreCase);
        Assert.False(x.AutoTrim);
        Assert.False(x.DefaultsToNull);
        Assert.True(x.Is("IGNORE Case"));
    }

    [Fact]
    public void CanAutoTrim()
    {
        var x = new MutableString(" autotrim   ", StringFeature.AutoTrim);
        Assert.False(x.IgnoreCase);
        Assert.True(x.AutoTrim);
        Assert.False(x.DefaultsToNull);
        Assert.True(x.Is("autotrim"));
    }

    [Fact]
    public void CanDefaultToNull()
    {
        var x = new MutableString(StringFeature.DefaultsToNull);
        x.Modify.Reset();
        Assert.False(x.IgnoreCase);
        Assert.False(x.AutoTrim);
        Assert.True(x.DefaultsToNull);
        Assert.True(x.Value == null);
        Assert.False(x.Value == "");

        var y = new MutableString(StringFeature.None);
        y.Modify.Reset();
        Assert.False(y.DefaultsToNull);
        Assert.False(y.Value == null);
        Assert.True(y.Value == "");
    }

    [Fact]
    public void CanUseAsFlag()
    {
        var x = new MutableString(StringFeature.DefaultsToNull | StringFeature.IgnoreCase);
        Assert.True(x.IgnoreCase);
        Assert.False(x.AutoTrim);
        Assert.True(x.DefaultsToNull);

        x = new MutableString(StringFeature.IgnoreCase | StringFeature.AutoTrim);
        Assert.True(x.IgnoreCase);
        Assert.True(x.AutoTrim);
        Assert.False(x.DefaultsToNull);
    }
}