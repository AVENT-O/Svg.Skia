namespace Svg.Model;

public static partial class SvgExtensions
{
    public static SvgDocumentExt? FromSvgExt(string svg)
    {
        return SvgDocumentExt.FromSvgExt<SvgDocumentExt>(svg);
    }

    public static SvgDocumentExt? OpenExt(System.IO.Stream stream)
    {
        return SvgDocumentExt.OpenExt<SvgDocumentExt>(stream, null);
    }
}
