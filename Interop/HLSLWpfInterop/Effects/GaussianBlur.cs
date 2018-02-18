using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SharpDX.D3DCompiler;

namespace HLSLWpfInterop.Effects
{
    public class GaussianBlur :
        PixelShaderEffect
    {
        private const string sourceName = "GaussianBlur.hlsl";
        static GaussianBlur()
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
