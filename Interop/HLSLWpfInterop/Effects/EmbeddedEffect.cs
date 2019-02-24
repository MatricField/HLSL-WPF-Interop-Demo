using System.IO;

namespace HLSLWpfInterop.Effects
{
    internal class EmbeddedEffect:
        PixelShaderEffectBase
    {
        protected static void RegisterPixelShaderEffectWithName(string shaderSourceName)
        {
            using (var includer = new EmbeddedFileIncluder())
            using (var sourceFile = includer.Open(shaderSourceName))
            {
                var reader = new StreamReader(sourceFile);
                var source = reader.ReadToEnd();
                RegisterPixelShaderEffect(source, includer);
            }
                
        }
    }
}
