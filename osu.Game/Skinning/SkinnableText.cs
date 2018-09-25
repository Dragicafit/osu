// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Linq;
using osu.Framework.Graphics;
using OpenTK;
using osu.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.IO.Stores;
using osu.Game.IO;
using static osu.Game.Skinning.LegacySkin;
using osu.Game.Database;
using System.IO;

namespace osu.Game.Skinning
{

    public class SkinnableText
    {
        private readonly OsuSpriteText createDefault;

        private readonly string fontName;

        private readonly bool restrictSize;

        private ISkinSource skin;

        /// <summary>
        ///
        /// </summary>
        /// <param name="name">The namespace-complete resource name for this skinnable element.</param>
        /// <param name="defaultImplementation">A function to create the default skin implementation of this element.</param>
        /// <param name="allowFallback">A conditional to decide whether to allow fallback to the default implementation if a skinned element is not present.</param>
        /// <param name="restrictSize">Whether a user-skin drawable should be limited to the size of our parent.</param>
        public SkinnableText(string name, OsuSpriteText defaultFont)
        {
            fontName = name;
            createDefault = defaultFont;
        }
        
        [BackgroundDependencyLoader]
        private void load(ISkinSource source, FileStore FileStore, SkinManager skinManager)
        {
            SkinInfo skinInfo = skinManager.CurrentSkinInfo.Value;
            IResourceStore<byte[]> storage = FileStore.Store;
            storage.Get("default.png");
            //LegacySkinResourceStore<SkinFileInfo> a = new LegacySkinResourceStore<SkinFileInfo>(skinInfo, storage);
            Stream stream = storage.GetStream($"default-");
            Drawable drawable = skin.GetDrawableComponent(fontName);

            if (drawable != null)
            {
                createDefault.Font = fontName;



            }
        }
    }
}
