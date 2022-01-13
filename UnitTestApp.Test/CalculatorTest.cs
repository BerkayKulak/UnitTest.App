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
        [InlineData(2, 5, 456)]
        [InlineData(10, 2, 13)]

        public void Add_simpleValues_ReturnTotalValue(int a, int b, int ExpectedTotal)
        {

            mymock.Setup(x => x.add(a, b)).Returns(ExpectedTotal);

            var actualData = Calculator.add(a, b);

            Assert.Equal(ExpectedTotal, actualData);

            //mymock.Verify(x=>x.add(a,b),Times.Once);
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
        [InlineData(3,5, 15)]
        public void Multip_SimpleValues_ReturnsMultipValue(int a, int b,int ExpectedMultip)
        {
            int actualMultip=0;
            mymock.Setup(x => x.multip(It.IsAny<int>(), It.IsAny<int>()))
                .Callback<int, int>((x, y) => actualMultip = x * y);

            Calculator.multip(a, b);

            Assert.Equal(ExpectedMultip,actualMultip);

            Calculator.multip(5, 20);

            Assert.Equal(100,actualMultip);

        }

        [Theory]
        [InlineData(0, 4)]
        public void Multip_ZeroValues_ReturnsException(int a, int b)
        {
            mymock.Setup(x => x.multip(a, b)).Throws(new Exception("a=0 olamaz"));

            Exception exception = Assert.Throws<Exception>(() => Calculator.multip(a, b));

            Assert.Equal("a=0 olamaz",exception.Message);
        }

    }
}
