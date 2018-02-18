using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.D3DCompiler;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.IO;
using System.Windows;

namespace HLSLWpfInterop.Effects
{
    public class ColorComplementEffect:
        PixelShaderEffect
    {

        private const string sourceName = "ColorComplement.hlsl";
        static ColorComplementEffect()
        {
            using (var resolver = new ShaderSourceResolver())
            using (var sourceStream = resolver.Open(IncludeType.Local, sourceName, null))
            {
                var reader = new StreamReader(sourceStream);
                var unprocessed = reader.ReadToEnd();
                var source = ShaderBytecode.Preprocess(unprocessed, include: resolver, sourceFileName: sourceName);
                RegisterPixelShaderEffect(source, "main");
            }
        }
    }
}
