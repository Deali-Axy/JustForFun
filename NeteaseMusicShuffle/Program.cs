using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NeteaseMusicShuffle {
    /// <summary>
    /// 网易云音乐随机播放算法优化
    /// </summary>
    static class Program {
        // 选取的音乐输了
        private const int MusicCount = 100;

        // 每轮播放的音乐数量
        private const int EveryTurnMusicCount = 10;

        // 记录歌曲名和播放次数
        private static readonly Dictionary<string, int> PlayList = new Dictionary<string, int>();

        static void Main(string[] args) {
            var musicPath = @"E:\Music\Like";

            foreach (var filePath in Directory.GetFiles(musicPath)) {
                if (filePath.EndsWith("mp3")) {
                    var musicName = Path.GetFileNameWithoutExtension(filePath);
                    if (!PlayList.ContainsKey(musicName) && PlayList.Count < MusicCount) {
                        // 初始化播放列表，顺带去重
                        PlayList.Add(musicName, 0);
                    }
                }
            }

            Console.WriteLine(PlayList.Count);

            // 开始播放
            for (var turn = 0; turn < 100; turn++) {
                Console.WriteLine($"开始播放，第{turn}轮");
                Console.WriteLine("============================");
                Console.WriteLine(Shuffle(PlayList).Dump());
                // Console.WriteLine("\n");
                Console.Read();
            }
        }

        private static IEnumerable<KeyValuePair<string, int>> Shuffle(Dictionary<string, int> musics,
            int turnMusicCount = EveryTurnMusicCount) {
            // todo shuffle musics
            var musicList = musics.Keys.ToList();
            var sampleList = musicList.Sample(turnMusicCount);
            var finalList = new List<KeyValuePair<string, int>>();

            foreach (var item in sampleList) {
                musics[item]++;
                finalList.Add(new KeyValuePair<string, int>(item, musics[item]));
            }

            return finalList;
        }

        private static string Dump(this IEnumerable<KeyValuePair<string, int>> data) {
            var builder = new StringBuilder();

            foreach (var (key, value) in data) {
                builder.AppendLine($"{key} - {value}");
            }

            return builder.ToString();
        }

        /// <summary>
        /// 从列表中随机抽取指定数量元素
        /// </summary>
        /// <param name="data"></param>
        /// <param name="count">数量</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static IEnumerable<T> Sample<T>(this IEnumerable<T> data, int count) {
            var random = new Random(DateTime.Now.Millisecond);
            var rawList = data.ToList();
            var newList = new List<T>();
            for (var i = 0; i < count; i++) {
                var randomIndex = random.Next(0, rawList.Count);
                newList.Add(rawList[randomIndex]);
                rawList.RemoveAt(randomIndex);
            }

            return newList;
        }
    }
}