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
    internal class GaussianBlur :
        EmbeddedEffect
    {
        private const string sourceName = "GaussianBlur.hlsl";
        static GaussianBlur() => RegisterPixelShaderEffectWithName(sourceName);
    }
}
