namespace HLSLWpfInterop.Effects
{
    internal class ColorComplementEffect:
        EmbeddedEffect
    {
        private const string sourceName = "ColorComplement.hlsl";
        static ColorComplementEffect() => RegisterPixelShaderEffectWithName(sourceName);
    }
}
