using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.EncryptionAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Util.EncryptionAlgorithm.Tests
{
    [TestClass()]
    public class Md5AlgorithmTests
    {
        private static string m_sourceString = "我是Chinese!@&1234567012345789012345678901234567890123456789";
        private static string m_sourceString2 = "我是Chinese!@&1234567012asdfasf34578901sadfas234qwe5678901234567890123456789";

        [TestMethod()]
        public void Encrypt16Test()
        {
            string cipherText = Md5Algorithm.Encrypt16(m_sourceString);
            string cipherText2 = Md5Algorithm.Encrypt16(m_sourceString2);
            if (!String.IsNullOrWhiteSpace(cipherText))
            {
                Assert.IsNotNull(cipherText);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void Encrypt32Test()
        {
            string cipherText = Md5Algorithm.Encrypt32(m_sourceString);
            string cipherText2 = Md5Algorithm.Encrypt32(m_sourceString2);
            if (!String.IsNullOrWhiteSpace(cipherText))
            {
                Assert.IsNotNull(cipherText);
            }
            else
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void Encrypt64Test()
        {
            string cipherText = Md5Algorithm.Encrypt64(m_sourceString);
            string cipherText2 = Md5Algorithm.Encrypt64(m_sourceString2);
            if (!String.IsNullOrWhiteSpace(cipherText))
            {
                Assert.IsNotNull(cipherText);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}