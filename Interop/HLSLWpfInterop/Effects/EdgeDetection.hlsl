#include "WPFBinding.hlsl"
#include "Convolution.hlsl"

static const float3x3 EdgeDetect =
{
    -1, -1, -1,
    -1, +8, -1,
    -1, -1, -1,
};

//static const float3x3 EdgeDetect =
//{
//    +1, +2, +1,
//    +2, +4, +2,
//    +1, +2, +1,
//};

float ToGreyScale(float4 tex : COLOR) : COLOR0
{
    //return dot(tex.rgb, float3(0.3, 0.59, 0.11));
    return length(tex.rgb);
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
    float convolved = Convolve3x3(EdgeDetect, data);
    float4 ret;
    ret.r = convolved;
    ret.g = convolved;
    ret.b = convolved;
    ret.a = 1;
    return normalize(ret);

}