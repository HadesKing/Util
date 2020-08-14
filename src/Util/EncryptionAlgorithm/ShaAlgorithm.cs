using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Util.EncryptionAlgorithm
{
    public class ShaAlgorithm
    {
        private static Encoding Encoding => Encoding.UTF8;

        private static byte[] GetBytes(String data)
        {
            return Encoding.GetBytes(data);
        }

        /// <summary>
        /// 将hash byte转换成String
        /// </summary>
        /// <param name="hashBytes"></param>
        /// <returns></returns>
        private static String ConvertToString(byte[] hashBytes)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var t in hashBytes)
            {
                builder.Append(t.ToString("X2"));
            }

            return builder.ToString();
        }

        #region [Encrypt256]
        /// <summary>
        /// SHA 256加密
        /// </summary>
        /// <param name="original">明文</param>
        /// <returns></returns>
        public static String Encrypt256(String original)
        {
            byte[] bytes = GetBytes(original);
            return Encrypt256(bytes);
        }

        /// <summary>
        /// SHA 512加密
        /// </summary>
        /// <param name="bytes">明文转换之后的byte</param>
        /// <returns></returns>
        public static String Encrypt256(byte[] bytes)
        {
            byte[] hashBytes = SHA256Managed.Create().ComputeHash(bytes);

            return ConvertToString(hashBytes);
        }

        public static String EncryptFile256(String filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            FileStream fileStream = fileInfo.Open(FileMode.Open);
            // Be sure it's positioned to the beginning of the stream.
            fileStream.Position = 0;
            // Compute the hash of the fileStream.

            return Encrypt256(fileStream);
        }

        public static String Encrypt256(Stream stream)
        {
            byte[] hashBytes = SHA256Managed.Create().ComputeHash(stream);

            return ConvertToString(hashBytes);
        }

        #endregion

        #region [Encrypt512]
        /// <summary>
        /// SHA 512加密
        /// </summary>
        /// <param name="original">明文</param>
        /// <returns></returns>
        public static String Encrypt512(String original)
        {
            byte[] bytes = GetBytes(original);
            return Encrypt512(bytes);
        }

        /// <summary>
        /// SHA 512加密
        /// </summary>
        /// <param name="bytes">明文转换之后的byte</param>
        /// <returns></returns>
        public static String Encrypt512(byte[] bytes)
        {
            byte[] hashBytes = SHA512Managed.Create().ComputeHash(bytes);

            return ConvertToString(hashBytes);
        }

        public static String EncryptFile512(String filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            FileStream fileStream = fileInfo.Open(FileMode.Open);
            // Be sure it's positioned to the beginning of the stream.
            fileStream.Position = 0;
            // Compute the hash of the fileStream.

            return Encrypt512(fileStream);
        }

        public static String Encrypt512(Stream stream)
        {
            byte[] hashBytes = SHA512Managed.Create().ComputeHash(stream);

            return ConvertToString(hashBytes);
        }


        #endregion

    }
}
