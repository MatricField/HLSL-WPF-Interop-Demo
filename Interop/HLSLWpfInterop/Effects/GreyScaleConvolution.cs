using SharpDX.D3DCompiler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HLSLWpfInterop.Effects
{
    public class GreyScaleConvolution:
        PixelShaderEffect
    {
        // TODO: Find a way to make this work
        #region ConvolutionParam dp


        public ConvolutionParam ConvolutionParam
        {
            get { return (ConvolutionParam)GetValue(ConvolutionParamProperty); }
            set { SetValue(ConvolutionParamProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConvolutionParam.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConvolutionParamProperty =
            DependencyProperty.Register(
                nameof(ConvolutionParam),
                typeof(ConvolutionParam),
                typeof(GreyScaleConvolution),
                new PropertyMetadata(new ConvolutionParam(0,0,0,0,0,0,0,0,0), PixelShaderConstantCallback(1)));


        #endregion

        private const string sourceName = "GreyScaleConvolution.hlsl";
        static GreyScaleConvolution()
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
