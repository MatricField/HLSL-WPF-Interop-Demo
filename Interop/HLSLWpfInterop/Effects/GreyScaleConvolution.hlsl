#include "WPFBinding.hlsl"
#include "Convolution.hlsl"

struct ConvolutionParam
{
    float constant;
    float3x3 kernal;
};

ConvolutionParam param : register(c1);

float ToGreyScale(float4 tex : COLOR) : COLOR0
{
    return dot(tex.rgb, float3(0.3, 0.59, 0.11));
}

float4 main(float2 uv : TEXCOORD) : COLOR
{
    
    float3x3 data;
    for (int y = -1; y <= 1; ++y)
    {
        for (int x = -1; x <= 1; ++x)
        {
            data[x + 1][y + 1] = ToGreyScale(GetNearByPixel(uv, float2(x, y)));
        }
    }
    float convolved = Convolve3x3(param.kernal, data, param.constant);
    float4 ret;
    ret.r = convolved;
    ret.g = convolved;
    ret.b = convolved;
    ret.a = 1;
    return ret;

}