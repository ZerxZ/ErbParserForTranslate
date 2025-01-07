using System.Diagnostics;

namespace EraMiraiTranslator.Utils;

public static class JsonFileOpener
{
    public static Process? OpenJsonFile(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("文件路径不能为空哦(｀・ω・´)");
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"找不到文件呢: {filePath}");
        }

        if (!filePath.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("这不是JSON文件啦！(╯°□°）╯︵ ┻━┻");
        }

        try
        {
            if (OperatingSystem.IsWindows())
            {
                var psi = new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true,
                    Verb = "open"
                };
               return Process.Start(psi);
            }
            if (OperatingSystem.IsLinux())
            {
                return   Process.Start(new ProcessStartInfo
                {
                    FileName = "xdg-open",
                    Arguments = filePath,
                    UseShellExecute = true
                });
            }
            if (OperatingSystem.IsMacOS())
            {
                return Process.Start(new ProcessStartInfo
                {
                    FileName = "open",
                    Arguments = filePath,
                    UseShellExecute = true
                });
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"打开JSON文件失败了喵: {ex.Message}", ex);
        }
        return null;
    }
}
