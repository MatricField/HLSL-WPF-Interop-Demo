sampler2D sample : register(s0);
float4 DdxUvDdyUv : register(c0);

float4 GetNearByPixel(float2 uv : TEXCOORD, float2 dxdy) : COLOR
{
    float2 nextPixelUV = uv + DdxUvDdyUv.xy * dxdy;
    return tex2D(sample, nextPixelUV);
}