using ShimSkiaSharp;
using Svg.Model.Services;   // v5.1.x: ToPath (PathingService) + ToDeviceValue (TransformsService) live here — internal, reachable in-assembly only
using Svg.Pathing;

namespace Svg.Model;

// aRento camp-map shim — the ONLY divergence from upstream Svg.Model (v5.1.1).
//
// Why this lives inside the Svg.Model assembly (not the app): PathingService.ToPath is
// `internal`, and only code compiled into Svg.Model can call it. That single delegating
// method (ToPathExt over SvgPathSegmentList) is the entire justification for the source fork.
// The other three helpers are self-contained and could move app-side if you ever want
// Svg.Model as a pure NuGet.
public static partial class SvgExtensions
{
    /// <summary>Self-contained: SvgColourServer -> model SKColor. No internal dependency.</summary>
    public static SKColor GetColorExt(SvgColourServer svgColourServer)
    {
        return new SKColor(svgColourServer.Colour.R, svgColourServer.Colour.G, svgColourServer.Colour.B, svgColourServer.Colour.A);
    }

    /// <summary>Needs internal PathingService.ToPath — the one reason this file must be in-assembly.</summary>
    public static SKPath? ToPathExt(this SvgPathSegmentList? svgPathSegmentList, SvgFillRule svgFillRule)
    {
        return svgPathSegmentList.ToPath(svgFillRule);
    }

    /// <summary>Self-contained: enlarged (2x radius) oval for photo-location tap targets.</summary>
    public static SKPath? ToPathBigExt(this SvgEllipse svgEllipse, SvgFillRule svgFillRule)
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

    /// <summary>Self-contained: normal-size oval for water/electricity markers.</summary>
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

        var skRectBounds = SKRect.Create(cx - rx, cy - ry, rx + rx, ry + ry);

        skPath.AddOval(skRectBounds);

        return skPath;
    }
}
