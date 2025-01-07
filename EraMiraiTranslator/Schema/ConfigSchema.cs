using System.Text;
using Newtonsoft.Json;

namespace EraMiraiTranslator.Schema;

public class ConfigSchema
{public static ConfigSchema Default = new ConfigSchema();
    [JsonProperty("读取这些扩展名的游戏文件")]
    public HashSet<string> extensions { get; set; } = [ ".csv", ".erb", ".erh"];
    // 常用的有UTF-8、UTF-8 with BOM、Shift JIS
    [JsonProperty("读取文件使用的编码")]
    public  string fileEncoding { get;  set; } =  "UTF8-BOM";

    // 解析表达式需要的符号集合
    [JsonProperty("需要处理的操作符")]
    public  List<string> operators { get;  set; } = [      "(", ")", "{", "}",
                                                        "?", "#",
                                                        "=", "+=", "-=", "*=", "/=",
                                                        ">", "<", "==", "!=", ">=", "<=",
                                                        "&&", "||", "&", "|", "!",
                                                        "+", "-", "*", "/", "%",
                                                        "++", "--",
                                                        ",", ":", "TO"];

    // 允许担当变量名的字符
    [JsonProperty("允许构成变量名的字符")]
    public List<string> var_operators { get; set; } = [ "☆", "♡", "∀", "←", "→" ];
    // 强力过滤变量名
    [JsonProperty("强力过滤变量名")]
    public  bool forceFilter { get;  set; } = true;
    // 执行完毕后自动打开文件夹
    [JsonProperty("执行完毕后自动打开文件夹")]
    public  bool autoOpenFolder { get;  set; } = true;

    // 刷完字典后参考CSV文件进行ERB全局替换，在项目初期可以解决一些内插变量名的错误，不是所有项目都需要的
    [JsonProperty("变量自动修正")]
    public  bool autoReplace { get;  set; } = true;
    
    [JsonProperty("隐藏英文词条")]
    public  bool hideEngText { get;  set; } = true;

    [JsonProperty("合并同一文件的相同词条")]
    public  bool mergeSameText { get;  set; } = false;

    [JsonProperty("屏蔽变量输出")]
    public  bool hideVarOutput { get;  set; } = false;
    
    [JsonProperty("合并联立字符串")]
    public  bool mergeString { get;  set; } = true;
    
    [JsonProperty("变量自动修正参考文件")]
    public  string[] autoReplaceRefer { get;  set; } = [        "Abl", "Base", "CFlag", "CSTR", "Ex",
                                                           "Exp", "Flag", "Global", "Item", "Juel",
                                                           "Mark", "Nowex", "Palam", "Source", "Stain",
                                                           "Talent", "TCVAR", "TEquip", "Tflag", "Train",
                                                           "TSTR", "修正字典"];
}