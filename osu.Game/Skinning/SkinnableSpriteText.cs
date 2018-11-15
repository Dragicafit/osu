// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Framework.Graphics.Sprites;

namespace osu.Game.Skinning
{
    public class SkinnableSpriteText : SkinnableDrawable<SpriteText>, IHasText
    {
        public const float FONT_SIZE = 16;

        public SkinnableSpriteText(string name, Func<string, SpriteText> defaultImplementation, Func<ISkinSource, bool> allowFallback = null, bool restrictSize = true)
            : base(name, defaultImplementation, allowFallback, restrictSize)
        {
            TextSize = FONT_SIZE;
        }

        protected override void SkinChanged(ISkinSource skin, bool allowFallback)
        {
            base.SkinChanged(skin, allowFallback);

            if (Drawable is IHasText textDrawable)
                textDrawable.Text = Text;

            if (Drawable is SpriteText spriteTextDrawable)
                spriteTextDrawable.TextSize = TextSize;
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
                    textDrawable.TextSize = TextSize;
            }
        }
    }
}
