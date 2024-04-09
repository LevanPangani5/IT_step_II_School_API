using School_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scool_API.Tests
{
    public class StringFunctionTests
    {
        [Fact]
        public void ConcatTwoStrings_GivenTwoStrings_ReturnsOne()
        {
            StringFunctions strFunc = new();

            string res = strFunc.Concatinate("xe", "xili");

            Assert.Equal("xexili", res);
        }

        [Theory]
        [InlineData("ana",true)]
        [InlineData("xe",false)]
        public void IsPalindrome_GivenString_ReturnsBool(string str, bool exp)
        {
          StringFunctions strFunc = new();
            bool res = strFunc.IsPalindrome(str);

            Assert.Equal(exp, res);
        }
    }
}
