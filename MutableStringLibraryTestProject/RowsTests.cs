using MutableStringLibrary;
using Xunit;

namespace MutableStringLibraryTestProject;

public class RowsTests
{
    [Fact]
    public void CanSplit()
    {
        var x = new MutableString(@"  a  
b

c ", false, false, false).Rows();
        Assert.True(x.Count == 4);
        Assert.True(x[0].Value == "  a  ");
        Assert.True(x[1].Value == "b");
        Assert.True(x[2].Value == "");
        Assert.True(x[3].Value == " c ");
    }

    [Fact]
    public void CanSplitWithTrim()
    {
        var x = new MutableString(@"  a  
b

c ", false, false, true).Rows();
        Assert.True(x.Count == 4);
        Assert.True(x[0].Value == "a");
        Assert.True(x[1].Value == "b");
        Assert.True(x[2].Value == "");
        Assert.True(x[3].Value == "c");
    }

    [Fact]
    public void RemoveNullOrWhiteSpace()
    {
        var x = new MutableStringList
        {
            new MutableString("a"),
            new MutableString(""),
            new MutableString(null, false, true, false),
            new MutableString("b"),
            new MutableString("       ")
        };
        x.RemoveIfIsNullOrWhiteSpace();
        Assert.True(x.Count == 2);
        Assert.True(x[0].Value == "a");
        Assert.True(x[1].Value == "b");
    }

    [Fact]
    public void RemoveIfIsNullOrEmpty()
    {
        var x = new MutableStringList
        {
            new("a"),
            new(""),
            new(null, false, true, false),
            new("b"),
            new("       ")
        };
        x.RemoveIfIsNullOrEmpty();
        Assert.True(x.Count == 2);
        Assert.True(x[0].Value == "a");
        Assert.True(x[1].Value == "b");
    }
}