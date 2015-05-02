using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace STLHCOMMON
{
    /// <summary>
    /// 加密解密管理类
    /// </summary>
    public class EncryptHandler
    {
        /// <summary>
        /// 全局密钥
        /// </summary>
        public static readonly string key = "127.0.0.1";

        /// <summary>
        /// 通过哈希算法加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="hash">加密的类型Enum(Clear SHA1 MD5)</param>
        /// <returns>加密后的字符串</returns>
        public static string HashEncrypt(string str, string hash)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, hash).ToUpper();
        }

        /// <summary>
        /// 使用散列方式加密 MD5加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5Encrypts(string str)
        {
            string result = string.Empty;
            //先将要加密的字符串转换成byte数组
            byte[] inputData = System.Text.Encoding.Default.GetBytes(str);
            //在通过MD5类加密，并得到加密后的byte[]类型
            byte[] data = System.Security.Cryptography.MD5.Create().ComputeHash(inputData);

            StringBuilder strBuild = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                //将每个byte数据转换成16进制。"X":表示大写16进制；"X2"：表示大写16进制保留2位；"x"：表示小写16进制
                strBuild.Append(data[i].ToString("X2"));
            }
            result = strBuild.ToString();
            return result.ToUpper();
        }

        /// <summary>
        /// 使用对称算法加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="encryptKey">密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string SymmetricEncrypts(string str, string encryptKey)
        {
            string result = string.Empty;
            byte[] inputData = Encoding.UTF8.GetBytes(str);
            byte[] IV = { 0x77, 0x70, 0x50, 0xD9, 0xE1, 0x7F, 0x23, 0x13, 0x7A, 0xB3, 0xC7, 0xA7, 0x48, 0x2A, 0x4B, 0x39 };
            try
            {
                byte[] byKey = Encoding.UTF8.GetBytes(encryptKey);
                //如需指定加密算法，可在Create()参数中指定字符串
                //Create()方法中的参数可以是：DES、RC2 AES、Rijndael、TripleDES等
                //采用不同的实现类对IV向量的要求不一样(可以用GenerateIV()方法生成)，无参数表示用Rijndael
                SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create();//产生一种加密算法
                MemoryStream msTarget = new MemoryStream();
                //定义将数据流链接到加密转换的流
                CryptoStream encStream = new CryptoStream(msTarget, Algorithm.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                encStream.Write(inputData, 0, inputData.Length);
                encStream.FlushFinalBlock();
                result = Convert.ToBase64String(msTarget.ToArray());
            }
            catch (Exception)
            {
                return null;
            }
            return result;
        }

        /// <summary>
        /// 使用对称算法解密
        /// </summary>
        /// <param name="encryptStr">加密的字符串</param>
        /// <param name="encryptKey">密钥</param>
        /// <returns>解密后的字符串</returns>
        public static string SymmectricDecrypts(string encryptStr, string encryptKey)
        {
            string result = string.Empty;
            try
            {
                //加密时使用的是Convert.ToBase64String(),解密时必须使用Convert.FromBase64String()
                byte[] encryptData = Convert.FromBase64String(encryptStr);
                byte[] byKey = Encoding.UTF8.GetBytes(encryptKey);
                byte[] IV = { 0x77, 0x70, 0x50, 0xD9, 0xE1, 0x7F, 0x23, 0x13, 0x7A, 0xB3, 0xC7, 0xA7, 0x48, 0x2A, 0x4B, 0x39 };
                SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create();
                MemoryStream msTarget = new MemoryStream();
                CryptoStream decStream = new CryptoStream(msTarget, Algorithm.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                decStream.Write(encryptData, 0, encryptData.Length);
                decStream.FlushFinalBlock();
                result = Encoding.UTF8.GetString(msTarget.ToArray());
            }
            catch (Exception)
            {
                return null;
            }
            return result;
        }


        /// <summary>
        /// 非对称加密，产生“公钥”和“私钥”
        /// </summary>
        public static void GeneratePrivateKey(string privatekey, string publicKey)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            privatekey = RSA.ToXmlString(true);//产生私钥.表示同时包含 RSA 公钥和私钥
            publicKey = RSA.ToXmlString(false);//产生公钥.表示仅包含公钥
        }
        /// <summary>
        /// 非对称加密
        /// </summary>
        /// <param name="str">要加密的数据</param>
        /// <param name="publicKey">公钥</param>
        /// <returns>加密结果</returns>
        public static string AsymmectricEncrypts(string str, string publicKey)
        {
            
            string result = string.Empty;

            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(publicKey);
            byte[] btResult = RSA.Encrypt( Encoding.UTF8.GetBytes(str), false);
            result = Convert.ToBase64String(btResult);
            return result;
        }

        /// <summary>
        /// 非对称解密
        /// </summary>
        /// <param name="strcode">加密后的字符串</param>
        /// <param name="privateKey">密钥（私钥）</param>
        /// <returns>解密后的结果</returns>
        public static string AsymmectricDecrypts(string strcode, string privateKey)
        {
            string result = string.Empty;
            byte[] bydata = Convert.FromBase64String(strcode);
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(privateKey);
            byte[] byR = RSA.Decrypt(bydata, false);
            result = System.Text.Encoding.UTF8.GetString(byR);
            return result;
        }
    }
}
