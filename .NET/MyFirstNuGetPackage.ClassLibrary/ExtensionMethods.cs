namespace MyFirstNuGetPackage.ClassLibrary;

public static class ExtensionMethods
{
    public static string MyToUpperCase2(this string str)
    {
        string name = "Taner Saydam";
        name.MyYoUpperCase();
        return str.ToUpper();
    }
}
