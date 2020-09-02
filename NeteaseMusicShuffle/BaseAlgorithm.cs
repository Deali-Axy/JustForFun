using System;
using System.Collections.Generic;
using System.Linq;
using JustForFun.Toolkit.Extension;

namespace NeteaseMusicShuffle {
    public abstract class BaseAlgorithm {
        protected const int DefaultEveryTurnMusicCount = 10;

        // 每轮播放的音乐数量
        public int EveryTurnMusicCount { get; set; }

        // 记录歌曲名和播放次数
        public readonly Dictionary<string, int> PlayList;

        public int CurrentTurn { get; set; }

        protected BaseAlgorithm() {
            EveryTurnMusicCount = DefaultEveryTurnMusicCount;
            
            PlayList = NeteaseMusicShuffleData.Data.ToDictionary(
                key => key, key => 0
            );
        }

        /// <summary>
        /// 开始下一轮播放
        /// </summary>
        public List<KeyValuePair<string, int>> NextTurn() {
            // Console.WriteLine($"开始播放，第{CurrentTurn}轮");
            // Console.WriteLine("============================");
            var currentPlayData = Shuffle(PlayList).ToList();
            // Console.WriteLine(currentPlayData.Dump());

            CurrentTurn++;

            return currentPlayData;
        }

        protected abstract IEnumerable<KeyValuePair<string, int>> Shuffle(
            IDictionary<string, int> musics,
            int turnMusicCount = DefaultEveryTurnMusicCount
        );
    }
}