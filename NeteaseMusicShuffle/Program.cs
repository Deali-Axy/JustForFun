using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using JustForFun.Toolkit.Extension;

namespace NeteaseMusicShuffle {
    /// <summary>
    /// 网易云音乐随机播放算法优化
    /// </summary>
    public static class Program {
        // 选取的音乐数量
        private const int MusicCount = 100;

        // 记录歌曲名和播放次数
        public static readonly Dictionary<string, int> PlayList;

        // 传统算法
        public static TraditionalAlgorithm TraditionalAlgorithm;

        // 播放次数多的优先算法
        public static MoreFirstAlgorithm MoreFirstAlgorithm;

        // 次数少优先算法
        public static LessFirstAlgorithm LessFirstAlgorithm;


        static Program() {
            PlayList = NeteaseMusicShuffleData.Data.ToDictionary(
                key => key, key => 0
            );

            TraditionalAlgorithm = new TraditionalAlgorithm();

            MoreFirstAlgorithm = new MoreFirstAlgorithm();

            LessFirstAlgorithm = new LessFirstAlgorithm();
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
                Console.WriteLine(TraditionalAlgorithm.NextTurn().Dump());
            }
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
    }
}