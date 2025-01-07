using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EraMiraiTranslator.Schema;
using EraMiraiTranslator.Utils;


public static class Configs
{
    public const string Version = "0.58a";
    public static HashSet<string> extensions { get; private set; }
    // 常用的有UTF-8、UTF-8 with BOM、Shift JIS
    public static Encoding fileEncoding { get; private set; }

    // 解析表达式需要的符号集合
    public static List<string> operators { get; private set; }

    // 允许担当变量名的字符
    public static List<string> var_operators { get; private set; }
    // 强力过滤变量名
    public static bool forceFilter = true;
    // 执行完毕后自动打开文件夹
    public static bool autoOpenFolder = false;

    // 刷完字典后参考CSV文件进行ERB全局替换，在项目初期可以解决一些内插变量名的错误，不是所有项目都需要的
    public static bool autoReplace = false;

    public static bool hideEngText = true;

    public static bool mergeSameText = true;

    public static bool hideVarOutput = false;

    public static bool mergeString = false;

    public static  string[] autoReplaceRefer = new string[0];
    private static bool     isFirstInit       = false;
    public static void Init()
    {
        // Config读取配置
        string configPath = PathUtils.ConfigPath;
        var    configs     =ConfigSchema.Default;
        if (!File.Exists(configPath))
        {
            isFirstInit = true;

            var json = JsonConvert.SerializeObject(configs, Formatting.Indented);
            File.WriteAllText(configPath, json);
            Console.WriteLine("首次运行，已生成配置文件，请按任意键继续！");
            Console.ReadKey();
        }

        if (!isFirstInit)
        {
            string jsonContent = File.ReadAllText(configPath);
            configs = JsonConvert.DeserializeObject<ConfigSchema>(jsonContent)!;
        }
        Console.WriteLine("读取配置文件成功！");
        Console.WriteLine(JsonConvert.SerializeObject(configs, Formatting.Indented));
        extensions = configs.extensions;

        // Encoding.GetEncoding无法获取带BOM的UTF-8，这里做特殊处理
        var encoding = configs.fileEncoding;
        fileEncoding = encoding.Contains("BOM") ? Encoding.UTF8 : Encoding.GetEncoding(encoding);

        operators = configs.operators;

        var_operators = configs.var_operators;

        forceFilter = configs.forceFilter;
        autoOpenFolder = configs.autoOpenFolder;
        autoReplace = configs.autoReplace;
        autoReplaceRefer =configs.autoReplaceRefer;
        hideEngText =configs.hideEngText;
        mergeSameText = configs.mergeSameText;
        hideVarOutput =configs.hideVarOutput;
        mergeString = configs.mergeString;
    }
}
