using System;
using System.Collections.Generic;
using System.Linq;
using JustForFun.Toolkit.Extension;

namespace NeteaseMusicShuffle {
    /// <summary>
    /// 次数少优先算法
    /// </summary>
    public class LessFirstAlgorithm : BaseAlgorithm {
        protected override IEnumerable<KeyValuePair<string, int>> Shuffle(
            IDictionary<string, int> musics,
            int turnMusicCount = DefaultEveryTurnMusicCount
        ) {
            var musicList = new List<string>();

            var max = musics.Max((item) => item.Value);

            Console.WriteLine($"max={max}");

            foreach (var (key, value) in musics) {
                for (var i = value; i <= max; i++) {
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