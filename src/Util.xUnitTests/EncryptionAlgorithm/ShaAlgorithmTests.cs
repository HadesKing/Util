using Xunit;
using Util.EncryptionAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Util.EncryptionAlgorithm.Tests
{
    public class ShaAlgorithmTests
    {
        private string m_original = "我是Chinese!@&123456";

        [Fact()]
        public void Encrypt256Test()
        {
            String ciphertext = ShaAlgorithm.Encrypt256(m_original);

            Assert.NotNull(ciphertext);
            Assert.NotEmpty(ciphertext);
            //Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Encrypt512Test()
        {
            String ciphertext = ShaAlgorithm.Encrypt512(m_original);

            Assert.NotNull(ciphertext);
            Assert.NotEmpty(ciphertext);
            //Assert.True(false, "This test needs an implementation");
        }
    }
}