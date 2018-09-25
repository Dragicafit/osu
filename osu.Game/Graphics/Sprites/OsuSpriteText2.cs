// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.Transforms;
using osu.Framework.IO.Stores;
using osu.Game.IO;
using osu.Game.Skinning;
using System.IO;
using static osu.Game.Skinning.LegacySkin;

namespace osu.Game.Graphics.Sprites
{
    public class OsuSpriteText2 : OsuSpriteText
    {

        public OsuSpriteText2()
        {
        }

        [BackgroundDependencyLoader]
        private void load(ISkinSource skin, FileStore FileStore, SkinManager skinManager)
        {
            SkinInfo skinInfo = skinManager.CurrentSkinInfo.Value;
            IResourceStore<byte[]> storage = FileStore.Store;
            ResourceStore<byte[]> a = new ResourceStore<byte[]>();
        }
    }
    
}
