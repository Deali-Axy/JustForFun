﻿using System;

namespace JustForFun.Web.ToolKits {
    public static class RandomHelper {
        /// <summary>
        /// 获取随机小数
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="length">小数点保留位数</param>
        /// <returns></returns>
        public static double GetRandomDouble(double minimum, double maximum, int length = 2) {
            Random random = new Random();
            return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, length);
        }
    }
}