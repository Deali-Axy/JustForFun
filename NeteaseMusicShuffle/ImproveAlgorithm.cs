using System;
using System.Collections.Generic;
using System.Linq;
using JustForFun.Toolkit.Extension;

namespace NeteaseMusicShuffle {
    public class ImproveAlgorithm {
        // 每轮播放的音乐数量
        private const int EveryTurnMusicCount = 10;

        // 记录歌曲名和播放次数
        public readonly Dictionary<string, int> PlayList;

        public int CurrentTurn { get; set; }

        public ImproveAlgorithm() {
            PlayList = NeteaseMusicShuffleData.Data.ToDictionary(
                key => key, key => 0
            );
        }

        /// <summary>
        /// 开始下一轮播放
        /// </summary>
        public List<KeyValuePair<string, int>> NextTurn() {
            Console.WriteLine($"开始播放，第{CurrentTurn}轮");
            Console.WriteLine("============================");
            var currentPlayData = Shuffle(PlayList).ToList();
            Console.WriteLine(currentPlayData.Dump());

            CurrentTurn++;

            return currentPlayData;
        }

        private static IEnumerable<KeyValuePair<string, int>> Shuffle(IDictionary<string, int> musics,
            int turnMusicCount = EveryTurnMusicCount) {
            var musicList = new List<string>();

            foreach (var (key, value) in musics) {
                for (var i = 0; i < (value == 0 ? 1 : value); i++) {
                    musicList.Add(key);
                }
            }

            var sampleList = musicList.Sample(turnMusicCount);

            var finalList = new List<KeyValuePair<string, int>>();

            foreach (var item in sampleList) {
                musics[item]++;
                finalList.Add(new KeyValuePair<string, int>(item, musics[item]));
            }

            return finalList;
        }
    }
}