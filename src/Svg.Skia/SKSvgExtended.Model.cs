using System.Collections.Generic;
using Svg.Model;

namespace Svg.Skia;

public class SKSvgExtended : SKSvg
{
    public Dictionary<string, SvgPath> SvgPathPitches { get; private set; } = new();

    public Dictionary<string, SvgEllipse> SvgPathPhotoLoc { get; private set; } = new();

    public Dictionary<string, SvgRectangle> SvgRectZones { get; private set; } = new();

    public Dictionary<string, SvgPath> SvgPathCamp { get; private set; } = new();

    public new SkiaSharp.SKPicture? Picture { get; private set; }

    public SKSvgExtended() : base()
    {
    }

    public SkiaSharp.SKPicture? FromSvgExt(string svg)
    {
        var svgDocument = SvgExtensions.FromSvgExt(svg);
        if (svgDocument is { })
        {
            Model = SvgExtensions.ToModel(svgDocument, AssetLoader, out var drawable, out _);
            Drawable = drawable;
            Picture = SkiaModel.ToSKPicture(Model);

            SvgPathPitches = svgDocument.SvgPathPitches;
            SvgPathPhotoLoc = svgDocument.SvgPathPhotoLoc;
            SvgRectZones = svgDocument.SvgRectZones;
            SvgPathCamp = svgDocument.SvgPathCamp;

            return Picture;
        }
        return null;
    }

    public SkiaSharp.SKPicture? LoadExt(System.IO.Stream stream)
    {
        var svgDocument = SvgExtensions.OpenExt(stream);
        if (svgDocument is null)
        {
            return null;
        }

        Model = SvgExtensions.ToModel(svgDocument, AssetLoader, out var drawable, out _);
        Drawable = drawable;
        Picture = SkiaModel.ToSKPicture(Model);

        SvgPathPitches = svgDocument.SvgPathPitches;
        SvgPathPhotoLoc = svgDocument.SvgPathPhotoLoc;
        SvgRectZones = svgDocument.SvgRectZones;
        SvgPathCamp = svgDocument.SvgPathCamp;

        return Picture;
    }

    private void Reset()
    {
        Picture?.Dispose();
        Picture = null;
    }
}
