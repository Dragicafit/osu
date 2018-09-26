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
        public ISkinSource skin;

        protected override Texture GetTextureForCharacter(char c)
        {
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

            return base.GetTextureForCharacter(c);
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
