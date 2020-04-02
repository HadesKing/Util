using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Util.EncryptionAlgorithm
{
    /// <summary>
    /// AES 算法
    /// </summary>
    /// <author>刘迪</author>
    /// <createDate>2020-04-02</createDate>
    /// <modifiedBy></modifiedBy>
    /// <modifiedDate></modifiedDate>
    /// <modifiedContent></modifiedContent>
    public sealed class AesAlgorithm
    {
        /// <summary>
        /// 默认密钥
        /// 说明：
        ///     一般情况下密钥不允许进行变更
        /// </summary>
        private const string m_key = "myaes@!#&123";
        /// <summary>
        /// 默认初始向量
        /// </summary>
        private static readonly string m_defaultIV = "012！49671";

        #region [Encrypt（加密）]

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="argOriginal">原文</param>
        /// <param name="argIV">初始向量，如不填写，则使用默认值</param>
        /// <returns></returns>
        public static string Encrypt(string argOriginal, string argIV = null)
        {
            // Check arguments.
            if (argOriginal == null || argOriginal.Length <= 0)
                throw new ArgumentNullException("argOriginal");
            if (argIV == null || argIV.Length <= 0)
                argIV = m_defaultIV;

            return AesBase64(argOriginal, m_key, argIV, OperationType.Encrypt);
        }


        #endregion

        #region [Decrypt（解密）]

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="argCipherText">密文</param>
        /// <param name="argIV">初始向量，如不填写，则使用默认值</param>
        /// <returns></returns>
        public static string Decrypt(string argCipherText, string argIV = null)
        {
            if (argCipherText == null || argCipherText.Length <= 0)
                throw new ArgumentNullException("argCipherText");
            if (argIV == null || argIV.Length <= 0)
                argIV = m_defaultIV;

            return AesBase64(argCipherText, m_key, argIV, OperationType.Decrypt);
        }

        #endregion

        /// <summary>
        /// 编码格式
        /// </summary>
        private static Encoding Encoding => Encoding.UTF8;

        /// <summary>
        /// 加/解密（非对称式）
        /// </summary>
        /// <param name="argSourceString">源字符串，需要加/解密的字符串</param>
        /// <param name="argKey">密钥</param>
        /// <param name="argIV"></param>
        /// <param name="operationType">操作类型，默认是加密</param>
        /// <returns></returns>
        private static string AesBase64(
            string argSourceString
            , string argKey, string argIV
            , OperationType operationType = OperationType.Encrypt)
        {
            string result = null;

            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] key = sha256.ComputeHash(Encoding.GetBytes(argKey));
            byte[] iv = md5.ComputeHash(Encoding.GetBytes(argIV));      //使用md5 64位加密方式加密
            aes.Key = key;
            aes.IV = iv;

            /**
             * 思路：
             *     加密：源字符串转换成字节（byte）之后加密写入内存，返回密文字节，然后用base64返回字符串
             *     解密：使用base64解密字符串，获得密文字节（byte），解密之后得到源字符串的字节，字节再转换为源字符串
             */
            byte[] dataByteArray = null;
            ICryptoTransform cryptoTransform = null;
            switch (operationType)
            {
                case OperationType.Decrypt: //解密
                    dataByteArray = Convert.FromBase64String(argSourceString);
                    cryptoTransform = aes.CreateDecryptor();
                    break;
                default:    //默认是加密
                    dataByteArray = Encoding.GetBytes(argSourceString);
                    cryptoTransform = aes.CreateEncryptor();
                    break;
            }

            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
            {
                cs.Write(dataByteArray, 0, dataByteArray.Length);
                cs.FlushFinalBlock();
                switch (operationType)
                {
                    case OperationType.Decrypt: //解密
                        result = Encoding.GetString(ms.ToArray());
                        break;
                    default:    //默认是加密
                        result = Convert.ToBase64String(ms.ToArray());
                        break;
                }
            }

            return result;
        }

    }



}
