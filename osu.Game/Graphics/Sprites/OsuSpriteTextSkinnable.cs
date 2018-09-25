// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using OpenTK;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.Transforms;
using osu.Framework.IO.Stores;
using osu.Game.IO;
using osu.Game.Skinning;

namespace osu.Game.Graphics.Sprites
{
    public class OsuSpriteTextSkinnable : OsuSpriteText
    {
        private string font;
        public FontStore store;
        public ISkinSource skin;

        public OsuSpriteTextSkinnable(string Text, string font)
        {
            this.font = font;
            Font = "";
            this.Text = inc(Text);
        }

        public string inc(string text)
        {
            string textCode = "";
            foreach (char c in text)
            {
                textCode += (char)(c + 10000);
            }
            return textCode;
        }

        protected override Texture GetFallbackTextureForCharacter(char charCode)
        {
            char c = (char)(charCode - 10000);
            if (hasNumberSkinHd())
            {
                Scale = new Vector2(0.02f);
                return skin.GetTexture($"default-{c}@2x");
            }
            if (hasNumberSkin())
            {
                Scale = new Vector2(0.04f);
                return skin.GetTexture($"default-{c}");
            }

            return store.GetCharacter(font, c) ?? store.GetCharacter(null, c) ?? GetTextureForCharacter('?');
        }

        public bool hasNumberSkin()
        {
            for (int i = 0; i < 10; i++)
            {
                if (skin.GetTexture($"default-{i}") == null)
                    return false;
            }
            return true;
        }

        public bool hasNumberSkinHd()
        {
            for (int i = 0; i < 10; i++)
            {
                if (skin.GetTexture($"default-{i}@2x") == null)
                    return false;
            }
            return true;
        }
    }
}
