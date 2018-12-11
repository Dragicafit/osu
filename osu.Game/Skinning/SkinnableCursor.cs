using System;
using System.Collections.Generic;
using System.Text;

namespace osu.Game.Skinning
{
    public class SkinnableCursor : SkinReloadableDrawable
    {
        public bool CursorExpand { get; set; } = true;

        protected override void SkinChanged(ISkinSource skin, bool allowFallback)
        {
            CursorExpand = skin.GetValue<SkinConfiguration, bool>(s => s.CursorExpand) ?? true;
        }
    }
}
