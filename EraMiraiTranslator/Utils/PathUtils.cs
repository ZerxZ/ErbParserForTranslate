namespace EraMiraiTranslator.Utils;

public static class PathUtils
{
    public static string RootPath   => AppDomain.CurrentDomain.BaseDirectory;
    public static string ConfigPath => GetPath( "config.json");
    public static string GetPath(string path) => Path.Combine(RootPath, path);
}