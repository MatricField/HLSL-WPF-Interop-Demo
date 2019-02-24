using SharpDX.D3DCompiler;
using System;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.IO;
using System.Windows;
using SharpDX;

namespace HLSLWpfInterop.Effects
{
    public abstract class PixelShaderEffectBase :
        ShaderEffect
    {
        private const string DEFAULT_SHADER_VER = "ps_3_0";

        private const string DEFAULT_ENTRY_POINT = "main";

        private static PixelShader _Shader = null;

        private string _EffectName;

        public virtual string EffectName => _EffectName ?? (_EffectName = GetType().Name);

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        // Using a DependencyProperty as the backing store for brush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InputProperty =
            RegisterPixelShaderSamplerProperty(
                nameof(Input),
                typeof(PixelShaderEffectBase),
                0,
                SamplingMode.NearestNeighbor);

        public PixelShaderEffectBase()
        {
            PixelShader = _Shader;
            DdxUvDdyUvRegisterIndex = 0;
            UpdateShaderValue(InputProperty);
        }

        protected static void RegisterPixelShaderEffect(string sourceCode, string entryPoint = DEFAULT_ENTRY_POINT, string shaderVersion = DEFAULT_SHADER_VER)
        {
            using (var compilationResult = ShaderBytecode.Compile(sourceCode, entryPoint, shaderVersion))
            {
                if(compilationResult.Bytecode == null)
                {
                    throw new CompilationException(compilationResult.ResultCode, compilationResult.Message);
                }
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

        protected static void RegisterPixelShaderEffect(string shaderSource, Include includeHandler, string entryPoint = DEFAULT_ENTRY_POINT, string shaderVersion = DEFAULT_SHADER_VER)
        {
            var processedSource = ShaderBytecode.Preprocess(shaderSource, include: includeHandler);
            RegisterPixelShaderEffect(processedSource, entryPoint, shaderVersion);
        }
    }
}
