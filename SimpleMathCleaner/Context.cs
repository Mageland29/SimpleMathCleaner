using dnlib.DotNet;
using dnlib.DotNet.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Logger;

public static class Context
{
    public static ModuleDefMD module = null;
    public static Assembly AssemblyRef = null;
    public static string FileName = null;
    public static void LoadModule(string filename)
    {
        try
        {
            FileName = filename;
            byte[] data = File.ReadAllBytes(filename);
            ModuleContext modCtx = ModuleDef.CreateModuleContext();
            module = ModuleDefMD.Load(data, modCtx);
            Write("Module Loaded : " + module.Name, TypeMessage.Info);
        }
        catch
        {
            Write("Error for Loade Module", TypeMessage.Error);
        }
    }
    public static void SaveModule()
    {
        try
        {
            string filename = string.Concat(new string[] { Path.GetDirectoryName(FileName), "\\", Path.GetFileNameWithoutExtension(FileName), "_MathFix", Path.GetExtension(FileName) });
            if (module.IsILOnly)
            {
                ModuleWriterOptions writer = new ModuleWriterOptions(module);
                writer.MetadataOptions.Flags = MetadataFlags.PreserveAll;
                writer.MetadataLogger = DummyLogger.NoThrowInstance;
                module.Write(filename, writer);
            }
            else
            {
                NativeModuleWriterOptions writer = new NativeModuleWriterOptions(module, false);
                writer.MetadataOptions.Flags = MetadataFlags.PreserveAll;
                writer.MetadataLogger = DummyLogger.NoThrowInstance;
                module.NativeWrite(filename, writer);
            }
            Write("Module Saved " + filename, TypeMessage.Info);
        }
        catch (ModuleWriterException ex)
        {
            Write("Fail to save current module\n" + ex.ToString(), TypeMessage.Error);
        }
    }
}
