#include "WPFBinding.hlsl"
#include "Convolution.hlsl"

static const float3x3 GaussianBlur =
{
    1, 2, 1,
    2, 4, 2,
    1, 2, 1
};

static const float GaussianBlurConstant = 1.0 / 16.0;

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 data[9];
    int i = 0;
    for (int y = -1; y <= 1; ++y)
    {
        for (int x = -1; x <= 1; ++x)
        {
            data[i] = GetNearByPixel(uv, float2(x, y));
            ++i;
        }
    }
    float3x3 red, green, blue, w;
    GetComponents3x3(data, red, green, blue, w);
    float4 ret =
    {
        Convolve3x3(GaussianBlur, red, GaussianBlurConstant),
		Convolve3x3(GaussianBlur, green, GaussianBlurConstant),
		Convolve3x3(GaussianBlur, blue, GaussianBlurConstant),
		Convolve3x3(GaussianBlur, w, GaussianBlurConstant),
    };
    return normalize(ret);

}