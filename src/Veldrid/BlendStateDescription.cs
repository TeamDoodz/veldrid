﻿using System;

namespace Veldrid
{
    /// <summary>
    /// A <see cref="Pipeline"/> component describing how values are blended into each individual color target.
    /// </summary>
    public struct BlendStateDescription : IEquatable<BlendStateDescription>
    {
        /// <summary>
        /// A constant blend color used in <see cref="BlendFactor.BlendFactor"/> and <see cref="BlendFactor.InverseBlendFactor"/>,
        /// or otherwise ignored.
        /// </summary>
        public RgbaFloat BlendFactor;
        /// <summary>
        /// An array of <see cref="BlendAttachmentDescription"/> describing how blending is performed for each color target
        /// used in the <see cref="Pipeline"/>.
        /// </summary>
        public BlendAttachmentDescription[] AttachmentStates;

        /// <summary>
        /// Constructs a new <see cref="BlendStateDescription"/>,
        /// </summary>
        /// <param name="blendFactor">The constant blend color.</param>
        /// <param name="attachmentStates">The blend attachment states.</param>
        public BlendStateDescription(RgbaFloat blendFactor, params BlendAttachmentDescription[] attachmentStates)
        {
            BlendFactor = blendFactor;
            AttachmentStates = attachmentStates;
        }

        /// <summary>
        /// Describes a blend state in which a single color target is blended with <see cref="BlendAttachmentDescription.OverrideBlend"/>.
        /// </summary>
        public static readonly BlendStateDescription SingleOverrideBlend = new BlendStateDescription
        {
            AttachmentStates = new BlendAttachmentDescription[] { BlendAttachmentDescription.OverrideBlend }
        };

        /// <summary>
        /// Describes a blend state in which a single color target is blended with <see cref="BlendAttachmentDescription.AlphaBlend"/>.
        /// </summary>
        public static readonly BlendStateDescription SingleAlphaBlend = new BlendStateDescription
        {
            AttachmentStates = new BlendAttachmentDescription[] { BlendAttachmentDescription.AlphaBlend }
        };

        /// <summary>
        /// Describes an empty blend state in which no color targets are used.
        /// </summary>
        public static readonly BlendStateDescription Empty = new BlendStateDescription
        {
            AttachmentStates = Array.Empty<BlendAttachmentDescription>()
        };

        /// <summary>
        /// Element-wise equality.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if all elements and all array elements are equal; false otherswise.</returns>
        public bool Equals(BlendStateDescription other)
        {
            return BlendFactor.Equals(other.BlendFactor)
                && Util.ArrayEqualsEquatable(AttachmentStates, other.AttachmentStates); 
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return HashHelper.Combine(BlendFactor.GetHashCode(), HashHelper.Array(AttachmentStates));
        }
    }
}