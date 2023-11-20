using Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services.Utils
{
    public class PasswordUtilsTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(150)]
        [InlineData(200)]

        public void ShouldCreateAPasswordWithSpecificLength(int length)
        {
            var password = PasswordUtils.GeneratePassword(length);

            Assert.Equal(length, password.Length);
        }

        [Fact]
        public void ShouldThrowAnErrorWhenPassAEmptyPasswordStringToCryptPassword()
        {
            Assert.Throws<ArgumentException>(() => PasswordUtils.CryptPassword(""));
        }

    }
}
