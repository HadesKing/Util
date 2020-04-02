using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.EncryptionAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Util.EncryptionAlgorithm.Tests
{
    [TestClass()]
    public class AesAlgorithmTests
    {
        private static string m_sourceString = "我是Chinese!@&";
        [TestMethod()]
        public void EncryptTest()
        {
            string cipherText = AesAlgorithm.Encrypt(m_sourceString);
            if(!String.IsNullOrWhiteSpace(cipherText))
            {
                Assert.IsNotNull(cipherText);
            }
            else
            {
                Assert.Fail();
            }
            
        }

        [TestMethod()]
        public void DecryptTest()
        {
            string cipherText = "jTIXGJHmu4AjzU2dG1mhz4lRVvC8gmi5udHfHO3sovA=";
            string decryptText = AesAlgorithm.Decrypt(cipherText);
            if (!String.IsNullOrWhiteSpace(decryptText))
            {
                Assert.AreEqual(decryptText, m_sourceString);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}