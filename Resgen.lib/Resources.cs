namespace Resgen.lib;

using System.IO;
using System.Reflection;

public static class Resources 
{
    private static Assembly _assembly = Assembly.GetExecutingAssembly();
    public static string CsLiquidTemplate () 
    {
        string resourceName = "Resgen.lib.Resources.cs.scriban";
        using (Stream stream = _assembly.GetManifestResourceStream(resourceName))
        using (StreamReader reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }

    public static string SqlLiquidTemplate () 
    {
        string resourceName = "Resgen.lib.Resources.sql.scriban";
        using (Stream stream = _assembly.GetManifestResourceStream(resourceName))
        using (StreamReader reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
}