using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STLHCOMMON.Enum
{
    [AttributeUsage(AttributeTargets.All)]
    public class EnumConfig : Attribute
    {
        private string _text;
        private string _value;

        public EnumConfig(string text, string value)
        {
            this._text = text;
            this._value = value;
        }

        public EnumConfig()
            : this(string.Empty, Guid.Empty.ToString())
        { }

        /// <summary>
        /// 枚举文本
        /// </summary>
        public string Text
        {
            get { return this._text; }
        }

        /// <summary>
        /// 枚举值
        /// </summary>
        public string Value
        {
            get { return this._value; }
            set { this._value = value; }
        }
    }
}
