using System;
using System.Collections.Generic;
using System.Linq;
using JustForFun.Toolkit.Extension;

namespace NeteaseMusicShuffle {
    /// <summary>
    /// 播放次数多的优先算法
    /// </summary>
    public class MoreFirstAlgorithm : BaseAlgorithm {
        protected override IEnumerable<KeyValuePair<string, int>> Shuffle(
            IDictionary<string, int> musics,
            int turnMusicCount = DefaultEveryTurnMusicCount
        ) {
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