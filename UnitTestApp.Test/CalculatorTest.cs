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
        [Fact]
        public void AddTest()
        {
            //// Arrange

            //int a = 5;

            //int b = 20;

            //var calculator = new Calculator();


            //// Act

            //var total = calculator.add(a, b);


            //// Assert

            //Assert.Equal<int>(25,total);



            // gerçek ifademde Fatih ismi geçiyorsa doğru çevirir.
            // Assert.Contains("Fatih", "Fatih Çakıroğlu");
            // Assert.DoesNotContain("Emre", "Fatih Çakıroğlu");

            //var names = new List<string>() {"Fatih", "Emre", "Hasan"};
            //Assert.Contains(names,x=> x == "Fatih");

            //Assert.True(5>2);
            //Assert.False(2>5);

            //Assert.True("".GetType()==typeof(string));

            //var regEx = "^dog";
            //Assert.Matches(regEx,"dogbgc");
            //Assert.DoesNotMatch(regEx,"asdfdsaf");

            //Assert.StartsWith("Bir","Bir Masal");
            //Assert.EndsWith("masal","Bir Masal");




            //Assert.Empty(new List<string>());
            //Assert.Empty(new List<string>(){"Fatih"});
            //Assert.NotEmpty(new List<string>(){"Fatih"});


            //Assert.InRange(10,2,20);
            //Assert.NotInRange(25,2,20);


            //Assert.Single(new List<string>() {"Fatih"});
            //Assert.Single(new List<string>() {"Fatih","Berkay"});

            
            //Assert.IsType<string>("fatih");
            //Assert.IsNotType<int>("fatih");

            // List sınıfı IEnumerable implemente ediyor. True döner
            // Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());
            Assert.IsAssignableFrom<object>("berkay");



        }
    }
}
