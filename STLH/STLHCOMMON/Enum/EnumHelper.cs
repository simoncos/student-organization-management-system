using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI.WebControls;


namespace STLHCOMMON.Enum
{
    public class EnumHelper
    {
        /// <summary>
        /// 将Enum数据绑定到DropDownList
        /// </summary>
        /// <param name="control">DropDownList控件</param>
        /// <param name="enumType">枚举类型</param>
        public static void BindEnumToDropDownList(DropDownList control, Type enumType)
        {
            EnumConfig[] dictInfos = GetEnumConfigCollection(enumType);
            if (dictInfos.Length == 0)
                return;
            foreach (EnumConfig item in dictInfos)
            {
                control.Items.Add(new ListItem(item.Text, item.Value.ToString()));
            }
        }

        /// <summary>
        /// 获取枚举配置项Text值
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="enumType">枚举类型</param>
        /// <returns></returns>
        public static string GetEnumConfigDictionaryItemText(string value, Type enumType)
        {
            Dictionary<string, string> dict = GetEnumConfigDictionary(enumType);
            if (!dict.ContainsKey(value))
            {
                return string.Empty;
            }
            return dict[value];
        }

        /// <summary>
        /// 将值转换为枚举名称
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        public static string ConvertValueToText(Type enumType, string value)
        {
            string result = string.Empty;
            EnumConfig[] piCol = GetEnumConfigCollection(enumType);
            if (piCol == null)
                return result;
            foreach (EnumConfig item in piCol)
            {
                if (item.Value == value)
                {
                    result = item.Text;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        ///  获取枚举的Enum配置项集合字典
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns>键为EnumConfig Value，值为EnumConfig Text</returns>
        public static Dictionary<string, string> GetEnumConfigDictionary(Type enumType)
        {
            EnumConfig[] cfgs = GetEnumConfigCollection(enumType);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (EnumConfig cfg in cfgs)
            {
                dictionary.Add(cfg.Value, cfg.Text);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取枚举的Enum配置项集合
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns></returns>
        public static EnumConfig[] GetEnumConfigCollection(Type enumType)
        {
            string cacheKey = enumType.Name;
            List<EnumConfig> result = System.Web.HttpRuntime.Cache[cacheKey] as List<EnumConfig>;
            if (result == null)
            {
                result = new List<EnumConfig>();
                FieldInfo[] fiInfos = GetFieldInfos(enumType);
                if (fiInfos == null || fiInfos.Length == 0)
                    return null;
                EnumConfig dict = null;
                foreach (FieldInfo item in fiInfos)
                {
                    dict = GetEnumConfigProperty(item);
                    if (dict == null)
                        continue;
                    result.Add(dict);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// 获取枚举所有FieldInfo集合信息
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        private static FieldInfo[] GetFieldInfos(Type tp)
        {
            if (!tp.IsEnum)
                return null;
            return tp.GetFields();
        }

        /// <summary>
        /// 获取枚举属性的自定义EnumConfig对象
        /// </summary>
        /// <param name="pi">属性信息</param>
        /// <returns></returns>
        private static EnumConfig GetEnumConfigProperty(FieldInfo pi)
        {
            if (pi == null)
                return null;

            object[] obj = pi.GetCustomAttributes(false);
            if (obj == null || obj.Length == 0)
                return null;

            EnumConfig ed = obj[0] as EnumConfig;
            if (ed == null)
                return null;
            return ed;
        }
    }
}
