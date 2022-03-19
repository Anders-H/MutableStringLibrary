using System.Linq;
using MutableStringLibrary;
using Xunit;

namespace MutableStringLibraryTestProject;

public class MutableStringListTests
{
    [Fact]
    public void AddFromTemplate()
    {
        var f = new MutableStringFactory(true, false, false);
        var l = f.GetList();
        l.Add("Hello!");
        Assert.True(l.First().IgnoreCase);
        Assert.False(l.First().DefaultsToNull);
        Assert.False(l.First().AutoTrim);

        f = new MutableStringFactory(false, true, true);
        l = f.GetList();
        l.Add("Hello!");
        Assert.False(l.First().IgnoreCase);
        Assert.True(l.First().DefaultsToNull);
        Assert.True(l.First().AutoTrim);
    }

    [Fact]
    public void CanCompareAll()
    {
        var s = new MutableStringList(true, false, true)
        {
            "a", "B", "c", "  D  "
        };

        Assert.True(s.IsSameAs("a", "b", "c", "d"));
        Assert.False(s.IsSameAs("a", "b", "c"));
    }

    [Fact]
    public void CanCutAt()
    {
        var s1 = new MutableStringList(true, false, true)
        {
            "A", "B", "C", "D"
        };

        var x1 = s1.CutAt(1, 2);

        // What is cut off?
        Assert.True(x1.IsSameAs("B", "C"));

        // What remains?
        Assert.True(s1.IsSameAs("A", "D"));
    }

    [Fact]
    public void CanCutBeginningAt()
    {
        var s1 = new MutableStringList(true, false, true)
        {
            "A", "B", "C", "D"
        };

        var x1 = s1.CutBeginningAt(2);

        // What is cut off?
        Assert.True(x1.IsSameAs("A", "B"));

        // What remains?
        Assert.True(s1.IsSameAs("C", "D"));
    }

    [Fact]
    public void CanCutEndAt()
    {
        var s1 = new MutableStringList(true, false, true)
        {
            "A", "B", "C", "D"
        };

        var x1 = s1.CutEndAt(2);

        // What is cut off?
        Assert.True(x1.IsSameAs("C", "D"));

        // What remains?
        Assert.True(s1.IsSameAs("A", "B"));
    }
}