// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.Transforms;
using osu.Framework.IO.File;
using osu.Framework.IO.Stores;
using osu.Framework.Localisation;
using osu.Game.Database;
using osu.Game.IO;
using osu.Game.Skinning;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace osu.Game.Graphics.Sprites
{
    public class OsuSpriteTextTest : OsuSpriteText
    {

        public OsuSpriteTextTest()
        {
        }
        

        public bool test(ISkinSource skin)
        {
            for (int i = 0; i < 10; i++)
            {
                if (skin.GetTexture($"default-{i}") == null)
                    return false;
            }
            return true;
        }

        public static Stream GenerateStreamFromString()
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@"");
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        [BackgroundDependencyLoader]
        private void load(ISkinSource source, FileStore FileStore, SkinManager skinManager, FontStore fontStore)
        {
            IResourceStore<byte[]> storage = FileStore.Store;
            SkinInfo skinInfo = skinManager.CurrentSkinInfo.Value;
            LegacySkinResourceStore<SkinFileInfo> legacySkinResourceStore = new LegacySkinResourceStore<SkinFileInfo>(skinInfo, storage);

            Stream streamFont = legacySkinResourceStore.GetStream("Venera2.fnt");
            Stream[] streamPng = new Stream[10];

            for (int i = 0; i<10; i++)
                streamPng[i] = legacySkinResourceStore.GetStream("Venera2_0.png");

            StreamRessourceStore streamRessourceStore = new StreamRessourceStore(streamFont, streamPng);
            ResourceStore<byte[]> resourceStore = new ResourceStore<byte[]>(streamRessourceStore);
            GlyphStore glyphStore = new GlyphStore(resourceStore, @"Venera2");
            fontStore.AddStore(glyphStore);
            //fontStore.RemoveStore(glyphStore);
        }
        protected class LegacySkinResourceStore<T> : IResourceStore<byte[]>
            where T : INamedFileInfo
        {
            private readonly IHasFiles<T> source;
            private readonly IResourceStore<byte[]> underlyingStore;

            private string getPathForFile(string filename)
            {
                bool hasExtension = filename.Contains('.');

                string lastPiece = filename.Split('/').Last();

                var file = source.Files.FirstOrDefault(f =>
                    string.Equals(hasExtension ? f.Filename : Path.ChangeExtension(f.Filename, null), lastPiece, StringComparison.InvariantCultureIgnoreCase));
                return file?.FileInfo.StoragePath;
            }

            public LegacySkinResourceStore(IHasFiles<T> source, IResourceStore<byte[]> underlyingStore)
            {
                this.source = source;
                this.underlyingStore = underlyingStore;
            }

            public Stream GetStream(string name)
            {
                string path = getPathForFile(name);
                return path == null ? null : underlyingStore.GetStream(path);
            }

            byte[] IResourceStore<byte[]>.Get(string name) => GetAsync(name).Result;

            public Task<byte[]> GetAsync(string name)
            {
                string path = getPathForFile(name);
                return path == null ? Task.FromResult<byte[]>(null) : underlyingStore.GetAsync(path);
            }

            #region IDisposable Support

            private bool isDisposed;

            protected virtual void Dispose(bool disposing)
            {
                if (!isDisposed)
                {
                    isDisposed = true;
                }
            }

            ~LegacySkinResourceStore()
            {
                Dispose(false);
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            #endregion
        }
    }
}
