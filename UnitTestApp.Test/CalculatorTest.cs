using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.App;
using Xunit;

namespace UnitTestApp.Test
{
    public class CalculatorTest
    {

        public Calculator Calculator { get; set; }

        public CalculatorTest()
        {
            Calculator = new Calculator();
        }


        [Fact]
        public void AddTest()
        {
            // Arrange

            int a = 5;

            int b = 20;

            // Act

            var total = Calculator.add(a, b);


            // Assert

            Assert.Equal<int>(25, total);

        }

        [Theory]
        [InlineData(2,5,7)]
      
        public void Add_simpleValues_ReturnTotalValue(int a, int b,int ExpectedTotal)
        {

            var actualData = Calculator.add(a, b);

            Assert.Equal(ExpectedTotal, actualData);
        }

    }
}
