using MutableStringLibrary;

var helloWorld = new MutableString("Hello world!");
var has = helloWorld.Has("Ello", out var start, out var length);

Console.WriteLine(has);
Console.WriteLine(start);
Console.WriteLine(length);
