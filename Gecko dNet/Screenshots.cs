using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GeckoApp
{
    public enum ScreenshotSizingMode
    {
        None,
        StretchToWidescreen,
        StretchToFullscreen
    }

    public enum ScreenshotFormat
    {
        PNG,
        BMP,
        JPEG,
        TIFF
    }

    class Screenshots
    {
        public static ImageCodecInfo getImageCodec(ScreenshotFormat format)
        {
            ImageCodecInfo[] formats =
                ImageCodecInfo.GetImageDecoders();

            String expectedMime;
            switch (format)
            {
                case ScreenshotFormat.BMP:
                    expectedMime = "image/bmp";
                    break;
                case ScreenshotFormat.JPEG:
                    expectedMime = "image/jpeg";
                    break;
                case ScreenshotFormat.TIFF:
                    expectedMime = "image/tiff";
                    break;
                default:
                    expectedMime = "image/png";
                    break;
            }

            ImageCodecInfo result = null;
            for (int i = 0; i < formats.Length; i++)
            {
                if (formats[i].MimeType.ToLower() == expectedMime)
                {
                    result = formats[i];
                    break;
                }
            }

            return result;
        }

        public static EncoderParameters getParameters(int jpegQuality, ScreenshotFormat format)
        {
            EncoderParameters result;
            switch(format)
            {
                case ScreenshotFormat.BMP:
                    result = new EncoderParameters(1);
                    result.Param[0] = new EncoderParameter(Encoder.ColorDepth, 24);
                    break;
                case ScreenshotFormat.JPEG:
                    result = new EncoderParameters(1);
                    result.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);
                    break;
                case ScreenshotFormat.TIFF:
                    result = new EncoderParameters(2);
                    EncoderParameter parameter = 
                        new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionLZW);
                    result.Param[0] = parameter;
                    parameter = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.LastFrame);
                    result.Param[1] = parameter;
                    break;
                default:
                    result = new EncoderParameters(2);
                    result.Param[0] = new EncoderParameter(Encoder.Compression,(long)EncoderValue.CompressionCCITT4);
                    result.Param[1] = new EncoderParameter(Encoder.ColorDepth, (long)24);
                    break;
            }
            return result;
        }

        public static Image resizeImage(Image imgToResize, ScreenshotSizingMode sizing)
        {
            if(sizing == ScreenshotSizingMode.None)
                return imgToResize;

            int cWidth = imgToResize.Width;
            int cHeight = imgToResize.Height;

            double resize;
            if (sizing == ScreenshotSizingMode.StretchToFullscreen)
                resize = 4.0 / 3.0;
            else
                resize = 16.0 / 9.0;

            double pictureAspect = (double)cWidth / (double)cHeight;

            if (pictureAspect <= resize * 1.02 && pictureAspect >= resize * 0.98)
                return imgToResize;

            int nWidth,nHeight;

            if (resize > pictureAspect)
            {
                nHeight = cHeight;
                nWidth = (int)Math.Round((double)cHeight * resize);
            }
            else
            {
                nWidth = cWidth;
                nHeight = (int)Math.Round((double)cWidth / resize);
            }

            return resizeImageInternal(imgToResize, nWidth, nHeight);
        }

        private static Image resizeImageInternal(Image imgToResize, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, width, height);
            g.Dispose();

            return (Image)b;
        }
    }
}
