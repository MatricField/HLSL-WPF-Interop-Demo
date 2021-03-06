﻿using System.Windows;

namespace HLSLWpfInterop.Effects
{
    internal class GreyScaleConvolution:
        EmbeddedEffect
    {
        // TODO: Find a way to make this work
        #region ConvolutionParam dp


        public ConvolutionParam ConvolutionParam
        {
            get { return (ConvolutionParam)GetValue(ConvolutionParamProperty); }
            set { SetValue(ConvolutionParamProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConvolutionParam.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConvolutionParamProperty =
            DependencyProperty.Register(
                nameof(ConvolutionParam),
                typeof(ConvolutionParam),
                typeof(GreyScaleConvolution),
                new PropertyMetadata(new ConvolutionParam(0,0,0,0,0,0,0,0,0), PixelShaderConstantCallback(1)));


        #endregion

        private const string sourceName = "GreyScaleConvolution.hlsl";
        static GreyScaleConvolution() => RegisterPixelShaderEffectWithName(sourceName);
    }
}
