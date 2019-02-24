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
    internal class EdgeDetection:
        EmbeddedEffect
    {
        private const string sourceName = "EdgeDetection.hlsl";
        static EdgeDetection() => RegisterPixelShaderEffectWithName(sourceName);
    }
}
