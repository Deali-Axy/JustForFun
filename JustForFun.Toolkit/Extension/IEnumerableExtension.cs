using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustForFun.Toolkit.Extension {
    public static class IEnumerableExtension {
        /// <summary>
        /// 将字典内容转换为字符串展示
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <returns></returns>
        public static string Dump<T, K>(this IEnumerable<KeyValuePair<T, K>> data) {
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
        public static IEnumerable<T> Sample<T>(this IEnumerable<T> data, int count) {
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