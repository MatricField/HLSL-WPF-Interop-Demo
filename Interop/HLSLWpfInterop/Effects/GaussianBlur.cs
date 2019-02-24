namespace HLSLWpfInterop.Effects
{
    internal class GaussianBlur :
        EmbeddedEffect
    {
        private const string sourceName = "GaussianBlur.hlsl";
        static GaussianBlur() => RegisterPixelShaderEffectWithName(sourceName);
    }
}
