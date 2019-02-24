using System.Runtime.InteropServices;

namespace HLSLWpfInterop.Effects
{
    [StructLayout(LayoutKind.Explicit, Size = 64)]
    public struct ConvolutionParam
    {
        [FieldOffset(0)]
        private readonly float _Constant;

        public float Constant => _Constant;

        [FieldOffset(16)]
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R4, SizeConst = 9)]
        private readonly float[] _Kernal;
        public float[] Kernal => _Kernal;

        public ConvolutionParam(float constant, float[] kernal)
        {
            _Constant = constant;
            _Kernal = kernal;
        }

        public ConvolutionParam(params float[] kernal):
            this(0, kernal)
        {
        }
    }
}
