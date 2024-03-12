using ShimSkiaSharp;
using Svg.Pathing;

namespace Svg.Model;

public static partial class SvgExtensions
{
    public static SKColor GetColorExt(SvgColourServer svgColourServer)
    {
        return new SKColor(svgColourServer.Colour.R, svgColourServer.Colour.G, svgColourServer.Colour.B, svgColourServer.Colour.A);
    }

    public static SKColor GetColorExt(SvgColourServer svgColourServer, float opacity, DrawAttributes ignoreAttributes)
    {
        return GetColor(svgColourServer, opacity, ignoreAttributes);
    }

    public static SKPath? ToPathExt(this SvgPathSegmentList? svgPathSegmentList, SvgFillRule svgFillRule)
    {
        return ToPath(svgPathSegmentList, svgFillRule);
    }

    public static SKPath? ToPathExt(this SvgEllipse svgEllipse, SvgFillRule svgFillRule, SKRect skViewport)
    {
        return ToPath(svgEllipse, svgFillRule, skViewport);
    }

    public static SKPath? ToPathExt(this SvgEllipse svgEllipse, SvgFillRule svgFillRule)
    {
        var fillType = svgFillRule == SvgFillRule.EvenOdd ? SKPathFillType.EvenOdd : SKPathFillType.Winding;
        var skPath = new SKPath
        {
            FillType = fillType
        };

        var skRectBoundsCreate = new SKRect(svgEllipse.CenterX.Value - svgEllipse.RadiusX.Value, svgEllipse.CenterY.Value - svgEllipse.RadiusY.Value, svgEllipse.CenterX.Value + svgEllipse.RadiusX.Value, svgEllipse.CenterX.Value + svgEllipse.RadiusY.Value);

        var cx = svgEllipse.CenterX.ToDeviceValue(UnitRenderingType.Horizontal, svgEllipse, skRectBoundsCreate);
        var cy = svgEllipse.CenterY.ToDeviceValue(UnitRenderingType.Vertical, svgEllipse, skRectBoundsCreate);
        var rx = svgEllipse.RadiusX.ToDeviceValue(UnitRenderingType.Other, svgEllipse, skRectBoundsCreate);
        var ry = svgEllipse.RadiusY.ToDeviceValue(UnitRenderingType.Other, svgEllipse, skRectBoundsCreate);

        if (rx <= 0f || ry <= 0f)
        {
            return default;
        }

        var skRectBounds = SKRect.Create(cx - 2 * rx, cy - 2 * ry, rx + 3 * rx, ry + 3 * ry);

        skPath.AddOval(skRectBounds);

        return skPath;
    }
}
