namespace HLSLWpfInterop.Effects
{
    internal class EdgeDetection:
        EmbeddedEffect
    {
        private const string sourceName = "EdgeDetection.hlsl";
        static EdgeDetection() => RegisterPixelShaderEffectWithName(sourceName);
    }
}
