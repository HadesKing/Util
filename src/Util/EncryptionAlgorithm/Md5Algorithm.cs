using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Util.EncryptionAlgorithm
{
    public sealed class Md5Algorithm
    {
        /// <summary>
        /// 编码格式
        /// </summary>
        private static Encoding Encoding => Encoding.UTF8;

        /// <summary>
        /// 16位MD5加密
        /// </summary>
        /// <param name="argSourceString">源文</param>
        /// <returns>密文</returns>
        public static string Encrypt16(String argSourceString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] sourceStringBytes = Encoding.GetBytes(argSourceString);
            byte[] cipherTextBytes = md5.ComputeHash(sourceStringBytes);
            string cipherText = BitConverter.ToString(cipherTextBytes, 4, 8);
            cipherText = cipherText.Replace("-", "");
            return cipherText;
        }

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="argSourceString">源文</param>
        /// <returns>密文</returns>
        public static string Encrypt32(string argSourceString)
        {
            StringBuilder sbCipherText = new StringBuilder();
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] sourceStringBytes = Encoding.GetBytes(argSourceString);
            byte[] cipherTextBytes = md5.ComputeHash(sourceStringBytes);
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < cipherTextBytes.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                sbCipherText.Append(cipherTextBytes[i].ToString("X"));
            }
            return sbCipherText.ToString();
        }

        /// <summary>
        /// 64位md5加密
        /// </summary>
        /// <param name="argSourceString">源文</param>
        /// <returns></returns>
        public static string Encrypt64(string argSourceString)
        {
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] sourceStringBytes = Encoding.GetBytes(argSourceString);
            byte[] cipherTextBytes = md5.ComputeHash(sourceStringBytes);
            return Convert.ToBase64String(cipherTextBytes);
        }

    }
}
