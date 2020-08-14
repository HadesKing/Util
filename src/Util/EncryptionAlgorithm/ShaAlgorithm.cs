using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Util.EncryptionAlgorithm
{
    public class ShaAlgorithm
    {


        public static String Encrypt256(String source)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            byte[] hash = SHA256Managed.Create().ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }

            return builder.ToString();
        }

        public static String Encrypt512(String source)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            byte[] hash = SHA512Managed.Create().ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }

            return builder.ToString();
        }

    }
}
