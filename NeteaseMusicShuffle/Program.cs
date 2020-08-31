using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace NeteaseMusicShuffle {
    /// <summary>
    /// 网易云音乐随机播放算法优化
    /// </summary>
    public static class Program {
        // 选取的音乐输了
        private const int MusicCount = 100;

        // 每轮播放的音乐数量
        private const int EveryTurnMusicCount = 10;

        // 记录歌曲名和播放次数
        public static readonly Dictionary<string, int> PlayList;

        public static int CurrentTurn { get; set; }

        static Program() {
            PlayList = NeteaseMusicShuffleData.Data.ToDictionary(
                key => key, key => 0
            );
        }

        static void Main(string[] args) {
            var musicPath = @"E:\Music\Like";

            PlayList.Clear();

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
            for (int i = 0; i < 10; i++) {
                Console.WriteLine(NextTurn().Dump());
            }
        }

        /// <summary>
        /// 开始下一轮播放
        /// </summary>
        public static List<KeyValuePair<string, int>> NextTurn() {
            Console.WriteLine($"开始播放，第{CurrentTurn}轮");
            Console.WriteLine("============================");
            var currentPlayData = Shuffle(PlayList).ToList();
            Console.WriteLine(currentPlayData.Dump());

            CurrentTurn++;

            return currentPlayData;
        }

        /// <summary>
        /// 将歌曲数据输出到Json文件
        /// </summary>
        private static void OutputToJsonFile() {
            var jsonData = JsonSerializer.Serialize(PlayList.Keys.ToList(),
                new JsonSerializerOptions {
                    // 避免中文被编码
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    WriteIndented = true
                });

            File.WriteAllText("music.json", jsonData);
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