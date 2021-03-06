// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Game.Online.API;
using osu.Game.Online.API.Requests;
using osu.Game.Online.API.Requests.Responses;
using osu.Game.Online.Leaderboards;
using osu.Game.Online.Multiplayer;

namespace osu.Game.Screens.Multi.Match.Components
{
    public class MatchLeaderboard : Leaderboard<MatchLeaderboardScope, APIRoomScoreInfo>
    {
        public Action<IEnumerable<APIRoomScoreInfo>> ScoresLoaded;

        private readonly Room room;

        public MatchLeaderboard(Room room)
        {
            this.room = room;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            room.RoomID.BindValueChanged(id =>
            {
                if (id == null)
                    return;

                Scores = null;
                UpdateScores();
            }, true);
        }

        protected override APIRequest FetchScores(Action<IEnumerable<APIRoomScoreInfo>> scoresCallback)
        {
            if (room.RoomID == null)
                return null;

            var req = new GetRoomScoresRequest(room.RoomID.Value ?? 0);

            req.Success += r =>
            {
                scoresCallback?.Invoke(r);
                ScoresLoaded?.Invoke(r);
            };

            return req;
        }

        protected override LeaderboardScore CreateDrawableScore(APIRoomScoreInfo model, int index) => new MatchLeaderboardScore(model, index);
    }

    public enum MatchLeaderboardScope
    {
        Overall
    }
}
