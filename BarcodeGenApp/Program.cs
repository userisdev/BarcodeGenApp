
using System.Text.RegularExpressions;
using ZXing.Common;
using ZXing.SkiaSharp;

var barcode = args.FirstOrDefault() ?? string.Empty;

var regex = new Regex(@"^[0-9]{13}$");

var writer = new BarcodeWriter();
writer.Format = ZXing.BarcodeFormat.EAN_13;
writer.Options = new EncodingOptions
{
    Width = 480,
    Height = 270,
};

using var bmp = writer.Write(barcode);
var data = bmp.Encode(SkiaSharp.SKEncodedImageFormat.Png, default);
using var fs = new FileStream("tmp.png", FileMode.CreateNew, FileAccess.Write);
data.SaveTo(fs);    

