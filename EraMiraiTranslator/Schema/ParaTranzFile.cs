namespace EraMiraiTranslator.Schema;

public class ParaTranzFile
{
    public string Key         { get; set; } = string.Empty;
    public string Original    { get; set; } = string.Empty;
    public string Translation { get; set; } = string.Empty;
    public int Stage          { get; set; } = 0;
}