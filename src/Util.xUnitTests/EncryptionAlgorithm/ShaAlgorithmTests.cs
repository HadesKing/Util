using Xunit;
using Util.EncryptionAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Util.EncryptionAlgorithm.Tests
{
    public class ShaAlgorithmTests
    {
        //private string m_original = "我是Chinese!@&123456";
        private string m_original = "123456";
        private string m_filePath = @"C:\Users\Administrator\Downloads\example.txt";

        [Fact()]
        public void Encrypt256Test()
        {
            String ciphertext = ShaAlgorithm.Encrypt256(m_original);

            bool result = (ciphertext.ToLower() == "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92");

            Assert.True(result);
            //Assert.NotNull(ciphertext);
            //Assert.NotEmpty(ciphertext);
            //Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Encrypt512Test()
        {
            String ciphertext = ShaAlgorithm.Encrypt512(m_original);

            bool result = (ciphertext.ToLower() == "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413");

            Assert.True(result);
            //Assert.NotNull(ciphertext);
            //Assert.NotEmpty(ciphertext);
            //Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void EncryptFile256Test()
        {
            String ciphertext = ShaAlgorithm.EncryptFile256(m_filePath);
            bool result = (ciphertext.ToLower() == "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92");

            Assert.True(result);
        }

        [Fact()]
        public void EncryptFile512Test()
        {
            String ciphertext = ShaAlgorithm.EncryptFile512(m_filePath);
            bool result = (ciphertext.ToLower() == "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413");

            Assert.True(result);
        }

    }
}