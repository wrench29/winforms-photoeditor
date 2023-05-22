using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photoeditor
{
    public static class ColorOperations
    {
        public static RGBf ColorToRGBf(Color color)
        {
            float r = ((float)color.R / 256);
            float g = ((float)color.G / 256);
            float b = ((float)color.B / 256);

            return new RGBf(r, g, b);
        }

        public static YIQ RGBtoYIQ(Color rgbColor)
        {
            var rgbf = ColorToRGBf(rgbColor);
            
            float y = 0.299f * rgbf.R + 0.587f * rgbf.G + 0.114f * rgbf.B;
            float i = 0.596f * rgbf.R - 0.274f * rgbf.G - 0.322f * rgbf.B;
            float q = 0.211f * rgbf.R - 0.522f * rgbf.G + 0.311f * rgbf.B;

            return new YIQ(y, i, q);
        }

        public static Color RGBfToRGB(RGBf rgbf)
        {
            return Color.FromArgb(
                (int)(rgbf.R * 256), 
                (int)(rgbf.G * 256), 
                (int)(rgbf.B * 256)
            );
        }

        public static Color YIQtoRGB(YIQ yiqColor) 
        {
            float r = yiqColor.Y + 0.956f * yiqColor.I + 0.623f * yiqColor.Q;
            float g = yiqColor.Y - 0.272f * yiqColor.I - 0.648f * yiqColor.Q;
            float b = yiqColor.Y - 1.105f * yiqColor.I + 1.705f * yiqColor.Q;

            return RGBfToRGB(new RGBf(r, g, b));
        }

        public record class RGBf(float R, float G, float B);
        public record class RGBi(int R, int G, int B);
        public record class YIQ(float Y, float I, float Q);
    }
}
