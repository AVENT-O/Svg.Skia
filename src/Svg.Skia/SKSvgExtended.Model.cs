using System.Collections.Generic;
using Svg.Model;

namespace Svg.Skia;

public class SKSvgExtended : SKSvg
{
    public Dictionary<string, SvgPath> SvgUnits { get; private set; } = new();

    public Dictionary<string, SvgEllipse> SvgPhotoLocations { get; private set; } = new();

    public Dictionary<string, SvgEllipse> SvgPhotoWater { get; private set; } = new();

    public Dictionary<string, SvgEllipse> SvgPhotoElectricity { get; private set; } = new();

    public Dictionary<string, SvgRectangle> SvgRectZones { get; private set; } = new();

    public Dictionary<string, SvgPath> SvgCampColor { get; private set; } = new();

    public Dictionary<string, SvgPath> SvgSubunits { get; private set; } = new();

    public Dictionary<string, SvgPath> SvgFacilities { get; private set; } = new();

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

            SvgUnits = svgDocument.SvgUnits;
            SvgPhotoLocations = svgDocument.SvgPhotoLocations;
            SvgPhotoWater = svgDocument.SvgPhotoWater;
            SvgPhotoElectricity = svgDocument.SvgPhotoElectricity;
            SvgRectZones = svgDocument.SvgRectZones;
            SvgCampColor = svgDocument.SvgCampColor;
            SvgSubunits = svgDocument.SvgSubunits;
            SvgFacilities = svgDocument.SvgFacilities;

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

        SvgUnits = svgDocument.SvgUnits;
        SvgPhotoLocations = svgDocument.SvgPhotoLocations;
        SvgPhotoWater = svgDocument.SvgPhotoWater;
        SvgPhotoElectricity = svgDocument.SvgPhotoElectricity;
        SvgRectZones = svgDocument.SvgRectZones;
        SvgCampColor = svgDocument.SvgCampColor;
        SvgSubunits = svgDocument.SvgSubunits;
        SvgFacilities = svgDocument.SvgFacilities;

        return Picture;
    }

    private void Reset()
    {
        Picture?.Dispose();
        Picture = null;
    }
}
