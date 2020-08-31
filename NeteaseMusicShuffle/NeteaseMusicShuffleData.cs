using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using NeteaseMusicShuffle.Models;

namespace NeteaseMusicShuffle {
    public static class NeteaseMusicShuffleData {
        public static string JsonData { get; set; }
        public static List<string> Data { get; set; }

        public static List<SimpleMusic> DataList {
            get {
                var tempList = new List<SimpleMusic>();

                return Data.Select((string item, int index) => new SimpleMusic {
                    Id = index,
                    Title = item
                }).ToList();
            }
        }

        static NeteaseMusicShuffleData() {
            JsonData = File.ReadAllText(Path.Combine(
                Environment.CurrentDirectory,
                "wwwroot", "data", "NeteaseMusicShuffle", "music.json"
            ));
            Data = JsonSerializer.Deserialize<List<string>>(JsonData);
        }
    }
}