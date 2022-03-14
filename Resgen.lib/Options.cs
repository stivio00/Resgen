namespace Resgen.lib;
public class Options
{
    public string InputFile { get; set; }
    public string OutputDirectory { get; set; }
    public List<string> OutputFiles { get; set; }

    public Options()
    {
        InputFile = "";
        OutputFiles = new ();
        OutputDirectory = "";
    }

    public override string ToString()
    {
        return $"files={InputFile}; output={OutputDirectory}; files={string.Join(", ", OutputFiles)}";
    }
}
