﻿using System;
using Xml;

namespace Svg
{
    [Element("marker")]
    public class SvgMarker : SvgPathBasedElement,
        ISvgCommonAttributes,
        ISvgPresentationAttributes,
        ISvgStylableAttributes,
        ISvgResourcesAttributes
    {
        [Attribute("viewBox", SvgNamespace)]
        public string? ViewBox
        {
            get => this.GetAttribute("viewBox");
            set => this.SetAttribute("viewBox", value);
        }

        [Attribute("preserveAspectRatio", SvgNamespace)]
        public string? AspectRatio
        {
            get => this.GetAttribute("preserveAspectRatio");
            set => this.SetAttribute("preserveAspectRatio", value);
        }

        [Attribute("refX", SvgNamespace)]
        public string? RefX
        {
            get => this.GetAttribute("refX");
            set => this.SetAttribute("refX", value);
        }

        [Attribute("refY", SvgNamespace)]
        public string? RefY
        {
            get => this.GetAttribute("refY");
            set => this.SetAttribute("refY", value);
        }

        [Attribute("markerUnits", SvgNamespace)]
        public string? MarkerUnits
        {
            get => this.GetAttribute("markerUnits");
            set => this.SetAttribute("markerUnits", value);
        }

        [Attribute("markerWidth", SvgNamespace)]
        public string? MarkerWidth
        {
            get => this.GetAttribute("markerWidth");
            set => this.SetAttribute("markerWidth", value);
        }

        [Attribute("markerHeight", SvgNamespace)]
        public string? MarkerHeight
        {
            get => this.GetAttribute("markerHeight");
            set => this.SetAttribute("markerHeight", value);
        }

        [Attribute("orient", SvgNamespace)]
        public string? Orient
        {
            get => this.GetAttribute("orient");
            set => this.SetAttribute("orient", value);
        }

        public override void Print(Action<string> write, string indent)
        {
            base.Print(write, indent);

            if (ViewBox != null)
            {
                write($"{indent}{nameof(ViewBox)}: \"{ViewBox}\"");
            }
            if (AspectRatio != null)
            {
                write($"{indent}{nameof(AspectRatio)}: \"{AspectRatio}\"");
            }
            if (RefX != null)
            {
                write($"{indent}{nameof(RefX)}: \"{RefX}\"");
            }
            if (RefY != null)
            {
                write($"{indent}{nameof(RefY)}: \"{RefY}\"");
            }
            if (MarkerUnits != null)
            {
                write($"{indent}{nameof(MarkerUnits)}: \"{MarkerUnits}\"");
            }
            if (MarkerWidth != null)
            {
                write($"{indent}{nameof(MarkerWidth)}: \"{MarkerWidth}\"");
            }
            if (MarkerHeight != null)
            {
                write($"{indent}{nameof(MarkerHeight)}: \"{MarkerHeight}\"");
            }
            if (Orient != null)
            {
                write($"{indent}{nameof(Orient)}: \"{Orient}\"");
            }
        }
    }
}