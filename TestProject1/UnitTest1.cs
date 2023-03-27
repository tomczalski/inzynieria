using Bogus;
using Bogus.DataSets;
using System;
using Xunit;
using TestProject1.Models;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Faker<UserAddress> addressBogus = new Faker<UserAddress>();
            addressBogus.RuleFor(x => x.Description, y => y.Address.FullAddress());
            addressBogus.RuleFor(x => x.Number, y => y.Address.CountryCode());
            Faker<UserCompany> companyBogus = new Faker<UserCompany>();
            companyBogus.RuleFor(x => x.CompanySuffix, y => y.Company.CompanySuffix());
            companyBogus.RuleFor(x => x.CompanyName, y => y.Company.CompanyName());
            var personBogus = new Faker<Models.Person>();
            personBogus.RuleFor(x => x.Name, y => y.Person.FirstName);
            personBogus.RuleFor(x => x.Surname, y => y.Person.LastName);
            personBogus.RuleFor(x => x.Birthday, y => y.Person.DateOfBirth);
            personBogus.RuleFor(x => x.Address, y => addressBogus.Generate());
            personBogus.RuleFor(x => x.Company, y => companyBogus.Generate());
            var hundredPpl = personBogus.Generate(100);

        }
    }

    public class CalculatorTest
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(10, 20, 30)]
        [InlineData(150, 250, 400)]

        public void add_two_numbers(int a, int b, int result)
        {
            Calculator calcObj1 = new Calculator();
            var added = calcObj1.Add(a, b);
            Assert.Equal(result, added);
        }

        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(30, 10, 20)]
        [InlineData(200, 50, 150)]

        public void subtract_two_numbers(int a, int b, int result)
        {
            Calculator calcObj2 = new Calculator();
            var subtracted = calcObj2.Subtract(a, b);
            Assert.Equal(result, subtracted);
        }

        [Theory]
        [InlineData(3, 2, 6)]
        [InlineData(30, 10, 300)]
        [InlineData(200, 2, 400)]

        public void multiply_two_numbers(int a, int b, int result)
        {
            Calculator calcObj3 = new Calculator();
            var multiplied = calcObj3.Multiply(a, b);
            Assert.Equal(result, multiplied);
        }

        [Fact]

        public void divide_by_0_Exception_method() 
        {
            Assert.Throws(typeof(Exception),
                () =>
                {
                    Calculator calcObj4 = new Calculator();

                    var x = calcObj4.Divide(4, 0);
                });
        }

    }
}
