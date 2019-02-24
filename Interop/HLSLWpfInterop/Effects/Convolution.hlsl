float Convolve3x3(float3x3 kernel, float3x3 mat, float constant = 1)
{
    float3x3 vals = mul(constant, kernel * mat);
    float ret = 0;
    for (int v = 0; v < 3; ++v)
    {
        for (int u = 0; u < 3; ++u)
        {
            ret += vals[u][v];
        }
    }
    return constant * ret;
}

void GetComponents3x3(in float4 data[9], out float3x3 x, out float3x3 y, out float3x3 z, out float3x3 w)
{
    for (int v = 0; v < 3; ++v)
    {
        for (int u = 0; u < 3; ++u)
        {
            x[u][v] = data[v * 3 + u].x;
            y[u][v] = data[v * 3 + u].y;
            z[u][v] = data[v * 3 + u].z;
            w[u][v] = data[v * 3 + u].w;
        }
    }
}