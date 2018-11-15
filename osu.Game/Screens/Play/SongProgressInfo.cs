// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Timing;
using osu.Game.Graphics;
using osu.Game.Graphics.Sprites;
using osu.Game.Skinning;
using System;

namespace osu.Game.Screens.Play
{
    public class SongProgressInfo : Container
    {
        private SkinnableSpriteText timeCurrent;
        private SkinnableSpriteText timeLeft;
        private SkinnableSpriteText progress;

        private double startTime;
        private double endTime;

        private int? previousPercent;
        private int? previousSecond;

        private double songLength => endTime - startTime;

        private const int margin = 10;

        public IClock AudioClock;

        public double StartTime { set { startTime = value; } }
        public double EndTime { set { endTime = value; } }

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            Children = new Drawable[]
            {
                timeCurrent = new SkinnableSpriteText("Play/osu/score-text", _ => new OsuSpriteText
                {
                    Colour = colours.BlueLighter,
                    Font = @"Venera",
                }, restrictSize: false)
                {
                    Origin = Anchor.BottomLeft,
                    Anchor = Anchor.BottomLeft,
                    Margin = new MarginPadding
                    {
                        Left = margin,
                    },
                },
                progress = new SkinnableSpriteText("Play/osu/score-text", _ => new OsuSpriteText
                {
                    Colour = colours.BlueLighter,
                    Font = @"Venera",
                }, restrictSize: false)
                {
                    Origin = Anchor.BottomCentre,
                    Anchor = Anchor.BottomCentre,
                },
                timeLeft = new SkinnableSpriteText("Play/osu/score-text", _ => new OsuSpriteText
                {
                    Colour = colours.BlueLighter,
                    Font = @"Venera",
                }, restrictSize: false)
                {
                    Origin = Anchor.BottomRight,
                    Anchor = Anchor.BottomRight,
                    Margin = new MarginPadding
                    {
                        Right = margin,
                    },
                }
            };
        }

        protected override void Update()
        {
            base.Update();

            double songCurrentTime = AudioClock.CurrentTime - startTime;
            int currentPercent = Math.Max(0, Math.Min(100, (int)(songCurrentTime / songLength * 100)));
            int currentSecond = (int)Math.Floor(songCurrentTime / 1000.0);

            if (currentPercent != previousPercent)
            {
                progress.Text = currentPercent.ToString() + @"%";
                previousPercent = currentPercent;
            }

            if (currentSecond != previousSecond && songCurrentTime < songLength)
            {
                timeCurrent.Text = formatTime(TimeSpan.FromSeconds(currentSecond));
                timeLeft.Text = formatTime(TimeSpan.FromMilliseconds(endTime - AudioClock.CurrentTime));

                previousSecond = currentSecond;
            }
        }

        private string formatTime(TimeSpan timeSpan) => $"{(timeSpan < TimeSpan.Zero ? "-" : "")}{Math.Floor(timeSpan.Duration().TotalMinutes)}:{timeSpan.Duration().Seconds:D2}";
    }
}
