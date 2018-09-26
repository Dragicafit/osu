// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics.Sprites;
using OpenTK.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Game.Skinning;
using osu.Framework.Allocation;

namespace osu.Game.Rulesets.Osu.Objects.Drawables.Pieces
{
    public class NumberPiece : Container
    {
        public SpriteText number;

        public string Text = @"1";

        public NumberPiece()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }

        [BackgroundDependencyLoader]
        private void load(ISkinSource skin)
        {

            Children = new Drawable[]
            {
                new SkinnableDrawable("Play/osu/number-glow", name => new CircularContainer
                {
                    Masking = true,
                    Origin = Anchor.Centre,
                    EdgeEffect = new EdgeEffectParameters
                    {
                        Type = EdgeEffectType.Glow,
                        Radius = 60,
                        Colour = Color4.White.Opacity(0.5f),
                    },
                    Child = new Box()
                }, s => s.GetTexture("Play/osu/hitcircle") == null),
                number = new OsuSpriteTextSkinnable
                {
                    Text = Text,
                    Font = @"Venera",
                    UseFullGlyphHeight = false,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    TextSize = 40,
                    Alpha = 1,
                    skin = skin
                }
            };
        }
    }
}
