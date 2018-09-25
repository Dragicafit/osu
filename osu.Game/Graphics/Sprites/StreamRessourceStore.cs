using osu.Framework.IO.Stores;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace osu.Game.Graphics.Sprites
{
    public class StreamRessourceStore : IResourceStore<byte[]>
    {
        private readonly Stream streamFont;
        private readonly Stream[] streamPng;

        public StreamRessourceStore(Stream streamFont, Stream[] streamPng)
        {
            this.streamPng = streamPng;
            this.streamFont = streamFont;
        }

        public byte[] Get(string name)
        {
            using (Stream input = GetStream(name))
            {
                if (input == null)
                    return null;

                byte[] buffer = new byte[input.Length];
                input.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        public virtual async Task<byte[]> GetAsync(string name)
        {
            using (Stream input = GetStream(name))
            {
                if (input == null)
                    return null;

                byte[] buffer = new byte[input.Length];
                await input.ReadAsync(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        public Stream GetStream(string name)
        {
            if (name.EndsWith(".fnt"))
                return streamFont;
            else if (name.EndsWith(".png"))
                return streamPng[name[name.LastIndexOf('.')-1] - '0'];
            return null;
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

        ~StreamRessourceStore()
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
