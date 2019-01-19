// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using Android.App;
using Android.Content.PM;
using Android.Content;
using osu.Framework.Android;
using osu.Game;

namespace osu.Android
{
    [IntentFilter(new[] { Intent.ActionView },
                      Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
                      DataScheme = "file",
                      DataMimeType = @"*/*",
                      DataPathPatterns = new string[] { @".*\\.osz", @".*\\..*\\.osz", @".*\\..*\\..*\\.osz", @".*\\..*\\..*\\..*\\.osz", @".*\\..*\\..*\\..*\\..*\\.osz", @".*\\..*\\..*\\..*\\..*\\..*\\.osz", },
                      DataHost = "*")]
    [Activity(Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true, SupportsPictureInPicture = false, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class OsuGameActivity : AndroidGameActivity
    {
        protected override Framework.Game CreateGame()
        {
            var data = Intent?.Data;
            if (data != null)
                return new OsuGame(new string[] { data.Path });
            return new OsuGame();
        }
    }
}
