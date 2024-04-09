using School_API.Data.Model;

namespace Scool_API.Tests
{
    public class CalculatorTests

    {
        [Fact]
        public void Add_WhenGivenTwoInts_ReturnsSum()
        {
            Calculator calc = new();
            int res = calc.Add(3, 5);
            Assert.Equal(8,res);
        }

        [Fact]
        public void Subtract_WhenGivenTwoInts_ReturnsSubtract()
        {
            Calculator calc = new();
            int res = calc.Subtract(8, 5);
            Assert.Equal(3, res);
        }
    }
}