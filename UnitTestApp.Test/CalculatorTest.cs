using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using UnitTest.App;
using Xunit;

namespace UnitTestApp.Test
{
    public class CalculatorTest
    {

        public Calculator Calculator { get; set; }
        private Mock<ICalculatorService> mymock { get; set; }

        public CalculatorTest()
        {
            mymock = new Mock<ICalculatorService>();

            Calculator = new Calculator(mymock.Object);
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
        [InlineData(2, 5, 7)]
        [InlineData(10, 2, 12)]

        public void Add_simpleValues_ReturnTotalValue(int a, int b, int ExpectedTotal)
        {

            mymock.Setup(x => x.add(a, b)).Returns(ExpectedTotal);

            var actualData = Calculator.add(a, b);

            Assert.Equal(ExpectedTotal, actualData);

            mymock.Verify(x=>x.add(a,b),Times.Once);
        }

        [Theory]
        [InlineData(0, 5, 0)]
        [InlineData(10, 0, 0)]

        public void Add_zeroValues_ReturnTotalValue(int a, int b, int ExpectedTotal)
        {

            var actualData = Calculator.add(a, b);

            Assert.Equal(ExpectedTotal, actualData);
        }


        [Theory]
        [InlineData(5, 4, 20)]
        public void Multip_SimpleValues_ReturnsMultipValue(int a, int b,int ExpectedMultip)
        {
            mymock.Setup(x => x.multip(a, b)).Returns(ExpectedMultip);

            Assert.Equal(ExpectedMultip,Calculator.multip(a,b));
        }

    }
}
