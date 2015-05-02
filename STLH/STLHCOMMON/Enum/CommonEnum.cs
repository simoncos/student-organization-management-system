using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHCOMMON.Enum
{
    /// <summary>
    /// Cookie保存的时间单位
    /// </summary>
    public enum CookieTime
    {
        /// <summary>
        /// 毫秒
        /// </summary>
        [EnumConfig("毫秒", "0")]
        Milliseconds = 0,
        /// <summary>
        /// 秒
        /// </summary>
        [EnumConfig("秒", "1")]
        Seconds = 1,
        /// <summary>
        /// 分钟
        /// </summary>
        [EnumConfig("分钟", "2")]
        Minutes = 2,
        /// <summary>
        /// 小时
        /// </summary>
        [EnumConfig("小时", "3")]
        Hours = 3,
        /// <summary>
        /// 天
        /// </summary>
        [EnumConfig("天", "4")]
        Days = 4,
        /// <summary>
        /// 月
        /// </summary>
        [EnumConfig("月", "5")]
        Months = 5,
        /// <summary>
        /// 年
        /// </summary>
        [EnumConfig("年", "6")]
        Years = 6
    }

    /// <summary>
    /// 验证码的类型
    /// </summary>
    public enum ValidType
    {
        /// <summary>
        /// 数字
        /// </summary>
        Numeric,
        /// <summary>
        /// 数字和英文字符
        /// </summary>
        NumericAndEnglishChar,
        /// <summary>
        /// 中文字符
        /// </summary>
        ChineseChar
    }
}
