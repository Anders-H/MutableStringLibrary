namespace MutableStringLibrary;

public class MutableStringFactory
{
    private readonly MutableString _template;

    public MutableStringFactory(bool ignoreCase, bool defaultsToNull, bool autoTrim)
    {
        _template = new MutableString("", ignoreCase, defaultsToNull, autoTrim);
        _template.Modify.Reset();
    }

    public MutableStringFactory(StringFeature features)
    {
        _template = new MutableString("", features);
        _template.Modify.Reset();
    }

    public MutableString Get()
    {
        var result = _template.Copy();
        result.Modify.Reset();
        return result;
    }

    public MutableString Get(string value) =>
        _template.Copy(value);

    public MutableString Get(MutableString value) =>
        _template.Copy(value.Value);
}