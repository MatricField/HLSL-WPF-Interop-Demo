using SharpDX.D3DCompiler;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.IO;
using System.Windows;

namespace HLSLWpfInterop.Effects
{
    public abstract class PixelShaderEffect:
        ShaderEffect
    {
        private static PixelShader _Shader = null;

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        // Using a DependencyProperty as the backing store for brush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InputProperty =
            RegisterPixelShaderSamplerProperty(
                nameof(Input),
                typeof(PixelShaderEffect),
                0,
                SamplingMode.NearestNeighbor);

        public PixelShaderEffect()
        {
            PixelShader = _Shader;
            DdxUvDdyUvRegisterIndex = 0;
            UpdateShaderValue(InputProperty);
        }

        protected static void RegisterPixelShaderEffect(string shaderSource, string entryPoint)
        {
            using (var compilationResult = ShaderBytecode.Compile(shaderSource, entryPoint, "ps_3_0"))
            using (var stream = new MemoryStream())
            {
                var data = compilationResult.Bytecode.Data;
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                _Shader = new PixelShader();
                _Shader.SetStreamSource(stream);
            }
            _Shader.Freeze();
        }
    }
}
