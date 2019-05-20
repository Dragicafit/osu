// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Graphics.Sprites;

namespace osu.Game.Skinning
{
    public class SkinnableSpriteText : SkinnableDrawable<SpriteText>, IHasText
    {
        public SkinnableSpriteText(string name, Func<string, SpriteText> defaultImplementation, Func<ISkinSource, bool> allowFallback = null, bool restrictSize = true, float size = 16)
            : base(name, defaultImplementation, allowFallback, restrictSize)
        {
            TextSize = size;
        }

        protected override void SkinChanged(ISkinSource skin, bool allowFallback)
        {
            base.SkinChanged(skin, allowFallback);

            if (Drawable is IHasText textDrawable)
                textDrawable.Text = Text;

            if (Drawable is SpriteText spriteTextDrawable)
                spriteTextDrawable.Font = spriteTextDrawable.Font.With(size: textSize);
        }

        private string text;

        public string Text
        {
            get => text;
            set
            {
                if (text == value)
                    return;

                text = value;

                if (Drawable is IHasText textDrawable)
                    textDrawable.Text = value;
            }
        }

        private float textSize;

        public float TextSize
        {
            get => textSize;
            set
            {
                if (textSize == value)
                    return;
                textSize = value;

                if (Drawable is SpriteText textDrawable)
                    textDrawable.Font = textDrawable.Font.With(size: textSize);
            }
        }
    }
}
